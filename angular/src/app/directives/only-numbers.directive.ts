import { Directive, ElementRef, HostListener, Input } from '@angular/core';

@Directive({
  selector: '[appOnlyNumbers]'
})
export class OnlyNumbersDirective {
  @Input() appOnlyNumbers;
  s: string;
  constructor(private element: ElementRef) { }
  @HostListener('change') onMouseleave() {
    this.s = this.element.nativeElement.value;
    const numbersRegex = /^\d+$/;
    if (!this.appOnlyNumbers.value.match(numbersRegex)) {
      this.appOnlyNumbers.value = '';
      // this.appOnlyNumbers.value = undefined;
    }
  }
}
