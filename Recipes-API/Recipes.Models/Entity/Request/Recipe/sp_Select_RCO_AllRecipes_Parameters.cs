﻿namespace Recipes.Models.Entity.Request.Recipe
{
    public class sp_Select_RCO_AllRecipes_Parameters
    {
        public int rco_Id { get; set; }
        public string rco_RecipeName { get; set; }
        public string rco_Image { get; set; }
        public string rco_Description { get; set; }
        public string rco_Author { get; set; }
        public DateTime rco_CreatedOn { get; set; }
    }
}
