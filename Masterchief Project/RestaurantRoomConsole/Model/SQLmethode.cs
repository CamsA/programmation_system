﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantRoomConsole.Model

{

    //This class contains all requests needed for RestaurantRoom

    public static class SQLmethode
    {
        public static string rq_sql;

        //Accessor
        public static string Rq_sql { get => rq_sql; set => rq_sql = value; }


        //public static string SelectAllFromTable(string table)
        //{
        //    return Rq_sql = "SELECT * FROM " + table;
        //}

        public static string SelectRecepiesByType(int category)
        {
            return Rq_sql = "SELECT IDRecette, NomRecette FROM Recette WHERE Categorie = " + category;
        }

        //public static string SelectIngredientsAndQuantitiesByRecipes(int recipe)
        //{
        //    return Rq_sql = "SELECT IDIngredient, QuantiteIngredient FROM Compose WHERE IDRecette =" + recipe;
        //}

        //public static string UpdateIngredientStockByRecipe(int recipe)
        //{
        //    return Rq_sql = "EXEC SelectRecette @Recette = " + recipe;
        //}

        //public static string UpdateArrivalDayIngredientStockByRecipe(int recipe)
        //{
        //    return Rq_sql = "UPDATE StockCuisine SET JourArrivé = JourArrivé + 1 WHERE IDStock = " + recipe;
        //}

        public static string InsertIntoScenario(String path)
        {
            return Rq_sql = "INSERT INTO Scenario( CheminRacine, Date ) VALUES('" + path + "', GETDATE()); ";
        }

        //public static string SelectTimeTasksByRecipes(int recipe)
        //{
        //    return Rq_sql = "SELECT Tache.DureeTache FROM Tache LEFT JOIN Necessite On Necessite.IDTache = Tache.IDTache WHERE Necessite.IDRecette = " + recipe;
        //}
    }
}
