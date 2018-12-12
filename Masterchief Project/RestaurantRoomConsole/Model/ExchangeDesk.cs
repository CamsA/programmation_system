﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantRoomConsole.Model
{
    public class ExchangeDesk
    {
        // Static instance to create the Singleton
        private static ExchangeDesk instance = null;
        private static readonly object padlock = new object();

        // Various stacks of equipments and meals ready to be carried by the waiter
        private int cleanTableClothes;
        private int cleanNapkins;
        private List<int> preparedMeals = new List<int>();

        // Getters and Setters
        public int CleanTableClothes { get => cleanTableClothes; set => cleanTableClothes = value; }
        public int CleanNapkins { get => cleanNapkins; set => cleanNapkins = value; }
        internal List<int> PreparedMeals { get => preparedMeals; set => preparedMeals = value; }

        // Private constructor
        private ExchangeDesk()
        { }

        // Instanciation and transmission of the instance via a Singleton
        public static ExchangeDesk GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ExchangeDesk();
                    }
                    return instance;
                }
            }
        }

        // Add a meal on the desk
        public void AddPreparedMeal(int idMeal)
        {
            this.preparedMeals.Add(idMeal);
        }

        // Add a clean equipment on the desk
        public void AddCleanObject(string type, int quantity)
        {
            switch (type)
            {
                case "TableClothes":
                    this.CleanTableClothes += quantity;
                    break;
                case "Napkins":
                    this.CleanNapkins += quantity;
                    break;
                default:
                    Console.WriteLine("Error : Cannot add clean object to the stack in restaurant room");
                    break;
            }
        }

        // Send dirty equipment to the kitchen
        public void SendDirtyObject(string type, int quantity)
        {
            switch(type)
            {
                case "Napkins":
                    RestaurantClientSocket.SendMessage("DN:" + quantity);
                    break;
                case "TableClothes":
                    RestaurantClientSocket.SendMessage("DTC:" + quantity);
                    break;
                case "Crockery":
                    RestaurantClientSocket.SendMessage("DC:" + quantity);
                    break;
                default:
                    Console.WriteLine("Error : Cannot recognize object sent from the restaurant room : " + type);
                    break;
            }
        }

        // Send an order to the kitchen
        public void SendOrder(int idMeal)
        {
            RestaurantClientSocket.SendMessage("NO:" + idMeal);
        }

        // Send a list of orders to the kitchen
        public void SendOrders(List<int> listOrders)
        {
            foreach(int idMeal in listOrders)
            {
                this.SendOrder(idMeal);
            }
        }
    }
}