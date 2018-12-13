﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kitchen.Model
{
    public class DishWasherEmployee
    {
        public DishWasherEmployee()
        { }

        public void MoveDirtyObjects()
        {
            Kitchen kitchen = Kitchen.GetInstance;
            ExchangeDesk exchangeDesk = ExchangeDesk.GetInstance;
           
            if(exchangeDesk.WaitingDirtyCrockery != 0)
            {
                int quantityMovedCrockery = exchangeDesk.WaitingDirtyCrockery;

                exchangeDesk.WaitingDirtyCrockery = 0;
                kitchen.DishwasherMachine.DirtyCrockeryStack += quantityMovedCrockery;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedCrockery + " plat(s) sale(s) pour le(s) mettre dans le lave-vaisselle", false, true, ConsoleColor.White);
            }

            if (exchangeDesk.WaitingDirtyTableClothes != 0)
            {
                int quantityMovedTableClothes = exchangeDesk.WaitingDirtyTableClothes;

                exchangeDesk.WaitingDirtyTableClothes = 0;
                kitchen.WashingMachine.DirtyTableClothesStacks += quantityMovedTableClothes;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedTableClothes + " nappes pour les mettre au lave-linge", false, true, ConsoleColor.White);
            }

            if (exchangeDesk.WaitingDirtyNapkins != 0)
            {
                int quantityMovedNapkins = exchangeDesk.WaitingDirtyNapkins;

                exchangeDesk.WaitingDirtyNapkins = 0;
                kitchen.WashingMachine.DirtyNapkinsStacks += quantityMovedNapkins;
                View.Display.DisplayMsg("Le plongeur a pris " + quantityMovedNapkins + " serviette pour les mettre au lave-linge", false, true, ConsoleColor.White);
            }     
        }

        public void Work()
        {
            while(true)
            {
                this.MoveDirtyObjects();

                Thread.Sleep(100);
            }
        }
    }
}
