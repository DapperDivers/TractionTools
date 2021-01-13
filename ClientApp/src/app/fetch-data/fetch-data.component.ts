import { Component, Inject, OnInit } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { Recipe } from '../models/recipe.model';
import { RecipeService } from '../services/recipe.service';
import { FormGroup, FormControl, FormArray, FormBuilder } from '@angular/forms'

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public recipes: Recipe[];
  public recipeService: RecipeService;

  public newRecipe: Recipe;

  recipeForm: FormGroup;


  constructor(recipeService: RecipeService, private fb: FormBuilder, @Inject(DOCUMENT) private document: Document) {
    recipeService.getRecipes().subscribe(result => {
      this.recipes = result;
    }, error => console.error(error));

    this.recipeForm = this.fb.group({
      name: '',
      recipeIngredients: this.fb.array([]),
      isActive: true
    });
    this.recipeService = recipeService;
  }

  recipeIngredients(): FormArray {
    return this.recipeForm.get("recipeIngredients") as FormArray
  }

  newIngredient(): FormGroup {
    return this.fb.group({
      ingredient: this.fb.group({
        name: ''
      })
    })
  }

  addIngredient() {
    this.recipeIngredients().push(this.newIngredient());
  }

  removeIngredient(i: number) {
    this.recipeIngredients().removeAt(i);
  }

  onSubmit() {
    //create recipe object
    this.recipeService.createRecipe(this.recipeForm.value).subscribe(result => {
      this.document.location.reload();
    }, error => console.error(error));

  }
  OnIngredientClicked(isChecked: boolean, recipeIngredientID: number) {
    this.recipeService.updateRecipeIngredient(isChecked, recipeIngredientID).subscribe(result => {
      console.log(isChecked + " " + recipeIngredientID);
    }, error => console.error(error));

  }
}
