﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherEmployee : MovableEntities
    {
        public DishWasherEmployee()
        { }

        public void TakeAndDeposite(string type, int number)
        {
            Kitchen kitchen = Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
            switch (type)
            {
                case "Cockery":
                    {
                        exchangeDesk.WaitingDirtyCrockery -= number;
                        kitchen.DishMachine.DirtyCrockeryStack += number;
                        break;
                    }
                case "TableCloth":
                    {
                        exchangeDesk.WaitingDirtyTableClothes -= number;
                        kitchen.WashingMachine.DirtyTableClothStacks += number;
                        break;
                    }
                case "Napkin":
                    {
                        exchangeDesk.WaitingDirtyCrockery -= number;
                        kitchen.WashingMachine.DirtyNapkinStacks += number;
                        break;
                    }
            }
        }
    }
}