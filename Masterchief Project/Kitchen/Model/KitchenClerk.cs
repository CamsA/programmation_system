﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class KitchenClerk : MovableEntities
    {

        public void Peel(string vegetable, Utensils utensils)
        {
            // todo with vegetable
            utensils.IsClean = false;

        }

        public void GetIngredients()
        {
            //todo requete sql avec camille
        }

        public void BringMeals()
        {

        }
    }
}