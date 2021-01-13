import { Ingredient } from "./ingredient.model";

export class Recipe {
  id: number;
  Name: string;
  UserId: string;
  DateCreated: string;
  isActive: boolean;
  ingredients: Ingredient[]
}
