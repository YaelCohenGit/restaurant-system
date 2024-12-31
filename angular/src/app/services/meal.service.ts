import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class MealService {
  constructor(private http: HttpService) { }

  getMealsByCategoryCode(categoryCode: number) {
    return this.http.get('api/Meal/getMealListByCategory/' + categoryCode);
  }
  getPriceByMealCode(mealCode: number) {
    return this.http.get('api/Meal/getPriceByMealCode/' + mealCode);
  }
  getAllMealsByCharacter(char: string, categoryCode: number) {
    return this.http.get('api/Meal/getAllMealsByCharacter/' + char + '/' + categoryCode);
  }
  getMealByMealCode(mealCode: number) {
    return this.http.get('api/Meal/getMealByMealCode/' + mealCode);
  }
  getMealByMealName(mealName: string) {
    return this.http.get('api/Meal/getMealByMealName/' + mealName);
  }
  getAllMeals() {
    return this.http.get('api/Meal/getAllMeals');
  }
}
