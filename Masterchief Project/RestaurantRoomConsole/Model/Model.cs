﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestaurantRoomConsole.Controler;
using RestaurantRoomConsole.Model;
using RestaurantRoomConsole.View;
namespace RestaurantRoomConsole.Model
{
    public class Modell
    {

        public static List<Thread> listThreads;
        private static bool suspend;
        //default constructor
        public static int loopCount = 0;

        public Modell()
        {
            suspend = false;
            listThreads = new List<Thread>();


            // Création du restaurant
            Restaurant restaurant = new Restaurant();


            // Création d'un maitre d'hotel
            MaitreHotel mh = new MaitreHotel("MaitreHotel1");


            // Création des serveurs en fonctions des infos, assigné à la ligne 1 2 3 et 4
            foreach(List<String> wtr in Parameters.listWaitersBegin)
            {
                Waiter waiter = new Waiter(wtr[0], int.Parse(wtr[1]));
                waiter.lpWaiter.Start();
                listThreads.Add(waiter.lpWaiter);
            }

            foreach (List<String> cdr in Parameters.listCdrBegin)
            {
                ChefDeRang CDR = new ChefDeRang(cdr[0], int.Parse(cdr[1]));
                CDR.lpChefDeRang.Start();
                listThreads.Add(CDR.lpChefDeRang);
            }

            

            mh.thmh.Start();

            

            Thread lpgenClient = new Thread(LoopGenClient);
            lpgenClient.Start();

            listThreads.Add(mh.thmh);
            listThreads.Add(lpgenClient);
        }

        

        public void FirstLoop()
        {

            while (true)
            {
                Display.DisplayTables();
                Thread.Sleep(1000);
            }
        }
        
        public static void pauseThread()
        {
            if (!suspend)
            {
                /*foreach (Thread th in listThreads)
                {
                    th.Suspend();
                }*/
                suspend = true;
            }
            else
            {
                /*foreach (Thread th in listThreads)
                {
                    th.Resume();
                }*/
                suspend = false;
            }


            
        }

        // Générer les clients aléatoirement
        public void LoopGenClient()
        {
            while (true)
            {
                loopCount ++;
                Random rnd = new Random();
                int nbrClients = rnd.Next(2, 6);



                GroupClient group = new GroupClient("group" + loopCount, nbrClients, false);
                group.theat.Start();
                listThreads.Add(group.theat);

            Display.DisplayMsg("*** Nouveaux clients ! group"+loopCount+" vient d'arriver (" + nbrClients + " clients) ***", false, true, ConsoleColor.Green);
            
            Thread.Sleep(rnd.Next(Parameters.timeSpawnMin, Parameters.timeSpawnMax));
            }
           
        }
    }
}

