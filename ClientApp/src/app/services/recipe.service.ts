import { Injectable, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Recipe } from '../models/recipe.model';
import { Ingredient } from '../models/ingredient.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {}

  public createRecipe(recipe: Recipe) {
    return this.httpClient.post(`/Recipe/SetUserRecipe`, recipe);
  }

  public updateRecipeIngredient(ownsbool: boolean, recipeIngredientIdNum: number) {
    console.log(ownsbool + " " + recipeIngredientIdNum);
    return this.httpClient.post(`/Recipe/setOwns`, { owns: ownsbool, recipeIngredientId: recipeIngredientIdNum});
  }

  public getRecipeIngredientsByRecipeId(recipeId: number) {
    return this.httpClient.get(`/Ingredient/GetIngredientsByRecipe/${recipeId}`);
  }

  public getRecipes() {
    return this.httpClient.get<Recipe[]>('/Recipe/GetUserRecipes')
  }
}
