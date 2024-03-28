﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ZooKeeperJavid
{
   

    public static class Game
    {
        static public int numCellsX = 6;
        static public int numCellsY = 6;

        static public int clickx;
        static public int clicky;

        //These two variables created to mark when a space is filled and when all the grids are filled, this will trigger game over via amount.
        static public int gameover = numCellsX * numCellsY;
        static public int filledspaces = 0;

        static public List<List<Zone>> animalZones = new List<List<Zone>>();
        static public List<Animal> animals = new List<Animal>();
        static public List<Zone> holdingzones = new List<Zone>();
        static public Zone holdingPen;
        static public Zone holdingPen2;
        static public Zone holdingPen3;
        static public Zone holderzone;
        static public Zone swapzone;
        static public Zone holderzone2;

        static public bool tobeswapped = false;
        

        static public void SetUpGame()
        {



            //Begins with jays code to create a grid based on numscells

            for (var y = 0; y < numCellsY; y++)
            {
                List<Zone> rowList = new List<Zone>();
                
                for (var x = 0; x < numCellsX; x++) rowList.Add(new Zone(x, y, null));
                animalZones.Add(rowList);
            }

            //Placement on map and adding to zone list, may delete later
            holdingPen = new Zone(-1, -1, null, ((MainWindow)Application.Current.MainWindow).HoldingPenA);
            holdingzones.Add(holdingPen);
            holdingPen2 = new Zone(-1, -2, null, ((MainWindow)Application.Current.MainWindow).HoldingPenB);
            holdingzones.Add(holdingPen2);
            holdingPen3 = new Zone(-1, -3, null, ((MainWindow)Application.Current.MainWindow).HoldingPenC);
            holdingzones.Add(holdingPen3);
            holderzone = new Zone(-1, -4, null, ((MainWindow)Application.Current.MainWindow).HoldingPenD);
            holdingzones.Add(holderzone);
            holderzone2 = new Zone(-1, -5, null, ((MainWindow)Application.Current.MainWindow).HoldingPenF);
            holdingzones.Add(holderzone2);

            //Custom method which generates a random animal into each holding pen zone
            AnimalRandomGenerator();


        }



        static public void ZoneClick(Zone clickedZone)
        {
           

            //Split this down by either its empty or not
            if (clickedZone.occupant == null)
            {
               
                //If its empty but the holding area I have for adding new animals isnt, adds animals and emptys hold zone
                if(holderzone.occupant != null)
                {
                    clickedZone.occupant = holderzone.occupant;                
                    holderzone.occupant = null;
                    holderzone.UpdateZoneImage();
                    UpdateBoard();
                    ActivateAnimals();

                    //If the clicked zone happens to be one of the swap space occupants it triggers the randomizer
                    if (clickedZone.occupant == holdingPen.occupant)
                    {
                        holdingPen.occupant = null;
                        AnimalRandomGenerator();

                    }
                    if (clickedZone.occupant == holdingPen2.occupant)
                    {
                        holdingPen2.occupant = null;
                        AnimalRandomGenerator();

                    }
                    if (clickedZone.occupant == holdingPen3.occupant)
                    {
                        holdingPen3.occupant = null;
                        AnimalRandomGenerator();

                    }

                }

                //If the second holding zone isnt empty but space clicking is, drops animal there
                if(holderzone2.occupant!= null)
                {
                    clickedZone.occupant = holderzone2.occupant;
                    holderzone2.occupant = null;
                    clickedZone.UpdateZoneImage();
                    holderzone2.UpdateZoneImage();
                    UpdateBoard();
                    ActivateAnimals();
                    tobeswapped = false;
                   
                    animalZones[clicky][clickx].occupant = null;
                    animalZones[clicky][clickx].UpdateZoneImage();
                }



            }
            //Part two of the original split, its either empty or its not/ and not equal to the swap pens for good measure
            else if(clickedZone.occupant != null && clickedZone.occupant != holdingPen.occupant && clickedZone.occupant != holdingPen2.occupant && clickedZone.occupant != holdingPen3.occupant)
            {
                clickedZone.occupant.ReportLocation();
                clickx = clickedZone.location.x;
                clicky = clickedZone.location.y;


                //if you click and its not empty, turns on trigger and saves click zone to holderzone 2
                if (holderzone2.occupant == null)
                {

                    holderzone2.occupant = clickedZone.occupant;
                    holderzone2.UpdateZoneImage();
                    

                    Debug.WriteLine("" + clickx.ToString() + "");
                    Debug.WriteLine("" + clicky.ToString() + "");

                    tobeswapped = true;

                }
                 //if you click and its not empty and you have something saved in holderzone 2
                else if(holderzone2.occupant != null)
                {

                        
                    
                        clickedZone.occupant = holderzone2.occupant;
                        holderzone2.occupant = null;
                        holderzone2.UpdateZoneImage();
                        clickedZone.UpdateZoneImage();
                        tobeswapped= false;

                        

                }
                    





            }

        }


            static public void ActivateAnimals()
        {
            for (var r = 1; r < 11; r++) // reaction times from 1 to 10
            {
                for (var y = 0; y < numCellsY; y++)
                {
                    for (var x = 0; x < numCellsX; x++)
                    {
                        var zone = animalZones[y][x];
                        if (zone.occupant != null && zone.occupant.reactionTime == r)
                        {
                            zone.occupant.Activate();
                        }
                    }
                }
            }
        }

        static public bool Seek(int x, int y, Direction d, string target)
        {
            switch (d)
            {
                case Direction.up:
                    y--;
                    break;
                case Direction.down:
                    y++;
                    break;
                case Direction.left:
                    x--;
                    break;
                case Direction.right:
                    x++;
                    break;
            }
            if (y < 0 || x < 0 || y > numCellsY - 1 || x > numCellsX - 1) return false;
            if (animalZones[y][x].occupant == null) return false;
            if (animalZones[y][x].occupant.species == target)
            {
                return true;
            }
            return false;
        }


        static public void Attack(Animal attacker, Direction d)
        {
            Console.WriteLine($"{attacker.name} is attacking {d.ToString()}");
            int x = attacker.location.x;
            int y = attacker.location.y;

            switch (d)
            {
                case Direction.up:
                    animalZones[y - 1][x].occupant = attacker;
                    break;
                case Direction.down:
                    animalZones[y + 1][x].occupant = attacker;
                    break;
                case Direction.left:
                    animalZones[y][x - 1].occupant = attacker;
                    break;
                case Direction.right:
                    animalZones[y][x + 1].occupant = attacker;
                    break;
            }
            animalZones[y][x].occupant = null;
        }


        static public bool Retreat(Animal runner, Direction d)
        {
            Console.WriteLine($"{runner.name} is retreating {d.ToString()}");
            int x = runner.location.x;
            int y = runner.location.y;

            switch (d)
            {
                case Direction.up:
                  
                    if (y > 0 && animalZones[y - 1][x].occupant == null)
                    {
                        animalZones[y - 1][x].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true; 
                    }
                    return false; 
               
                case Direction.down:
                    if (y < numCellsY - 1 && animalZones[y + 1][x].occupant == null)
                    {
                        animalZones[y + 1][x].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.left:
                    if (x > 0 && animalZones[y][x - 1].occupant == null)
                    {
                        animalZones[y][x - 1].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
                case Direction.right:
                    if (x < numCellsX - 1 && animalZones[y][x + 1].occupant == null)
                    {
                        animalZones[y][x + 1].occupant = runner;
                        animalZones[y][x].occupant = null;
                        return true;
                    }
                    return false;
            }
            return false; 
        }

        static public void UpdateBoard()
        {
            for (var y = 0; y < numCellsY; y++)
            {
                for (var x = 0; x < numCellsX; x++)
                {
                    var zone = animalZones[y][x];
                    zone.UpdateZoneImage();
                }
            }
        }
    
    
    //Creates a list and sets up integers to randomly display animals

    static public void AnimalRandomGenerator()
        {
            int animalIndex1;
            int animalIndex2;
            int animalIndex3;

            Chick chick = new Chick(null);
            animals.Add(chick);
            Mouse mouse = new Mouse(null);
            animals.Add(mouse);
            Cat cat = new Cat(null);
            animals.Add(cat);
            Raptor raptor = new Raptor(null);
            animals.Add(raptor);

            Random random = new Random();

            animalIndex1 = random.Next(0, animals.Count);
            animalIndex2 = random.Next(0, animals.Count);
            animalIndex3 = random.Next(0, animals.Count);

            if(holdingPen.occupant == null)
            {
                holdingPen.occupant = animals[animalIndex1];
                holdingPen.UpdateZoneImage();
            }
            
            if(holdingPen2.occupant == null)
            {
                holdingPen2.occupant = animals[animalIndex2];
                holdingPen2.UpdateZoneImage();
            }
            
            if(holdingPen3.occupant == null)
            {
                holdingPen3.occupant = animals[animalIndex3];
                holdingPen3.UpdateZoneImage();
            }
           

        }
        

        
    
    
    
    }
}
