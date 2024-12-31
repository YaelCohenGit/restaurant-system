import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CheckEmployeeService } from '../services/check-employee.service';
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { ElementRef } from '@angular/core';
import { OrderService } from '../services/order.service';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Employee } from '../models/employee';
import { Role } from '../models/role';
import { RoleService } from '../services/role.service';
import { Employment } from '../models/Employment';
import { EmploymentService } from '../services/employment.service';
import { MessageService } from 'primeng/api';
import { WorkingHoursService } from '../services/working-hours.service';
import { OrderDetailsService } from '../services/order-details.service';

@Component({
  selector: 'app-manager-area',
  templateUrl: './manager-area.component.html',
  styleUrls: ['./manager-area.component.css'],
  providers: [NgbModalConfig, NgbModal, FormsModule, ReactiveFormsModule, MessageService]
})
export class ManagerAreaComponent implements OnInit {
  validatingForm: FormGroup;
  selectedRole: boolean;
  selectedEmployment: boolean;
  myDate: any;
  date = new Date();
  dateTimeWord: string;
  @ViewChild('modal') public modalRef: TemplateRef<any>;
  employeeName = localStorage.getItem('globalName');
  employeePassword = localStorage.getItem('globalPassword');
  income = 0;
  isDisplayIncome = false;
  allRoles: Role[] = [];
  allEmployments: Employment[] = [];
  addPressed = false;
  formComplete = false;
  soldMealsAmount = 0;
  IsManager;
  // tslint:disable-next-line: max-line-length
  constructor(private messageService: MessageService, private router: Router, private workingHoursService: WorkingHoursService, private employeeService: CheckEmployeeService, private orderService: OrderService, config: NgbModalConfig, private modalService: NgbModal, private roleService: RoleService, private employmentService: EmploymentService, private orderDetailsService: OrderDetailsService) {
    config.backdrop = 'static';
    config.keyboard = false;
    setInterval(() => {
      this.myDate = new Date();
    }, 1000);
    this.dateTimeWord = this.employeeService.initDateTime(this.date);
    this.orderService.getTotalIncomeToDay().subscribe(result => {
      this.income = result;
      //this.orderDetailsService.getSoldMealsAmount().subscribe(res => {
        //this.soldMealsAmount = res;
        this.roleService.getRoles().subscribe(roleResult => {
          this.allRoles = roleResult;
          this.employmentService.getEmployments().subscribe(employmentResult => {
            this.allEmployments = employmentResult;
          });
        });
      //});
    });
  }
  @ViewChild('content', { static: true }) cont: ElementRef;
  ngOnInit() :void {
    if(localStorage.getItem('globalRole') !== null &&
      localStorage.getItem('globalRole').toUpperCase() === "MANAGER"){
      this.IsManager = true;
    } else{
      this.IsManager = false;
    }
    this.addPressed = false;
    this.selectedRole = false;
    this.selectedEmployment = false;
    this.validatingForm = new FormGroup({
      contactFormModalName: new FormControl('', Validators.required),
      contactFormModalID: new FormControl('', Validators.required),
      contactFormModalBaseSalary: new FormControl('', Validators.required),
      contactFormModalSalaryTip: new FormControl('', Validators.required),
      contactFormModalRole: new FormControl('Choose role', Validators.required),
      contactFormModalEmployment: new FormControl('Choose employment', Validators.required)
    });
  }
  closeDialog() {
    this.modalService.dismissAll();
    this.selectedRole = false;
    this.selectedEmployment = false;
    this.addPressed = false;
  }
  workingHoursRouter() {
    this.router.navigate(['/working-hours']);
    this.closeDialog();
  }
  kitchenRouter() {
    this.router.navigate(['/chefs-area']);
    this.closeDialog();
  }
  onlineRouter() {
    localStorage.setItem('password', '');
    this.router.navigate(['/online-map']);
    this.closeDialog();
  }
  displayIncome() {
    this.isDisplayIncome = true;
  }
  showSuccess(employeeCode: number) {
    this.messageService.add({ key: 'bc', severity: 'success', summary: 'Success', detail: 'Your code is:  ' + employeeCode });
  }
  showError() {
    this.messageService.add({ key: 'bc', severity: 'error', summary: 'Error', detail: 'Sorry... One or more details dont match' });
  }
  get contactFormModalName() {
    return this.validatingForm.get('contactFormModalName');
  }
  get contactFormModalID() {
    return this.validatingForm.get('contactFormModalID');
  }
  get contactFormModalBaseSalary() {
    return this.validatingForm.get('contactFormModalBaseSalary');
  }
  get contactFormModalSalaryTip() {
    return this.validatingForm.get('contactFormModalSalaryTip');
  }
  get contactFormModalRole() {
    return this.validatingForm.get('contactFormModalRole');
  }
  get contactFormModalEmployment() {
    return this.validatingForm.get('contactFormModalEmployment');
  }
  onRoleChange() {
    if (this.contactFormModalRole.value !== 'Choose role' && this.contactFormModalRole.value !== '') {
      this.selectedRole = true;
    }
    else {
      this.selectedRole = false;
    }
  }
  onEmploymentChange() {
    if (this.contactFormModalEmployment.value !== 'Choose employment' && this.contactFormModalEmployment.value !== '') {
      this.selectedEmployment = true;
    }
    else {
      this.selectedEmployment = false;
    }
  }
  onFormComplete() {
    if (this.selectedEmployment === true && this.selectedRole === true &&
      this.contactFormModalBaseSalary.value !== null && this.contactFormModalBaseSalary.value !== '' &&
      this.contactFormModalSalaryTip.value !== null && this.contactFormModalSalaryTip.value !== '' &&
      Number(this.contactFormModalID.value) >= 100000000 && Number(this.contactFormModalID.value) <= 999999999 &&
      this.contactFormModalName.value !== null && this.contactFormModalName.value !== ''
    ) {
      this.formComplete = true;
    } else {
      this.formComplete = false;
    }
  }
  onAddEmployee() {
    this.addPressed = true;
    this.onEmploymentChange();
    this.onRoleChange();
    const addEmployee = new Employee();
    addEmployee.employeeId = Number(this.contactFormModalID.value);
    addEmployee.employeeFirstName = this.contactFormModalName.value.toString().split(' ')[0];
    addEmployee.employeeLastName = this.contactFormModalName.value.toString().split(' ')[1];
    addEmployee.baseSalary = this.contactFormModalBaseSalary.value;
    addEmployee.salaryTip = this.contactFormModalSalaryTip.value;
    addEmployee.startingDate = new Date();
    addEmployee.roleCode = this.allRoles.find(r => r.roleName === this.contactFormModalRole.value).roleCode;
    addEmployee.employmentCode = this.allEmployments.find(e => e.employmentName === this.contactFormModalEmployment.value).employmentCode;
    this.employeeService.addEmployee(addEmployee).subscribe(res => {
      addEmployee.employeeCode = res;
      if (addEmployee.employeeCode !== -1) {
        this.showSuccess(addEmployee.employeeCode);
        return;
      }
      this.showError();
    });
  }
  exit() {
    this.workingHoursService.updateExitTimeAndTotalHours(Number(localStorage.getItem('workingHoursCode'))).subscribe(() => { });
  }// ‏
}
