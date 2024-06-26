﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZooKeeperJavid
{
    public class Animal
    {
        public string emoji;
        public string species;
        public string name;

        public int reactionTime = 5;

        public Point location;

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
        }


        //Edited the Hunt Method to take two string arguments and expanded the if statements

        public void Hunt(string targetAnimal, string targetAnimal2)
        {


            if (Game.Seek(location.x, location.y, Direction.up, targetAnimal))
            {
                Game.Attack(this, Direction.up);
                
            }
            if (Game.Seek(location.x, location.y, Direction.down, targetAnimal))
            {
                Game.Attack(this, Direction.down);
                
            }
            if (Game.Seek(location.x, location.y, Direction.left, targetAnimal))
            {
                Game.Attack(this, Direction.left);
                
            }
            if (Game.Seek(location.x, location.y, Direction.right, targetAnimal))
            {
                Game.Attack(this, Direction.right);
                
            }
            if (Game.Seek(location.x, location.y, Direction.up, targetAnimal2))
            {
                Game.Attack(this, Direction.up);
                
            }
            if (Game.Seek(location.x, location.y, Direction.down, targetAnimal2))
            {
                Game.Attack(this, Direction.down);
                
            }
            if (Game.Seek(location.x, location.y, Direction.left, targetAnimal2))
            {
                Game.Attack(this, Direction.left);
                
            }
            if (Game.Seek(location.x, location.y, Direction.right, targetAnimal2))
            {
                Game.Attack(this, Direction.right);
                
            }

        }

        //Edited the Flee Method to take two string arguments and expanded the if statements


        public void Flee(string predatorAnimal, string predatorAnimal2)
        {
            if (Game.Seek(location.x, location.y, Direction.up, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.down, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.left, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.right, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.left)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.up, predatorAnimal2))
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.down, predatorAnimal2))
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.left, predatorAnimal2))
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.right, predatorAnimal2))
            {
                if (Game.Retreat(this, Direction.left)) return;
            }


        }

        // A combination of flee and hunt, I think answers the question to the best of my ability. If statement prioritizes raptor flee movements before hunt movements
        public void CatsAreSoFnWeird(string targetAnimal, string targetAnimal2, string predatorAnimal)
        {

            if (Game.Seek(location.x, location.y, Direction.up, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.up, targetAnimal))
            {
                Game.Attack(this, Direction.up);
                
            }
            if (Game.Seek(location.x, location.y, Direction.up, targetAnimal2))
            {
                Game.Attack(this, Direction.up);
                
            }
            if (Game.Seek(location.x, location.y, Direction.down, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.down, targetAnimal))
            {
                Game.Attack(this, Direction.down);
                
            }
            if (Game.Seek(location.x, location.y, Direction.down, targetAnimal2))
            {
                Game.Attack(this, Direction.down);
                
            }
            if (Game.Seek(location.x, location.y, Direction.left, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.left, targetAnimal))
            {
                Game.Attack(this, Direction.left);
                
            }
            if (Game.Seek(location.x, location.y, Direction.left, targetAnimal2))
            {
                Game.Attack(this, Direction.left);
                
            }
            if (Game.Seek(location.x, location.y, Direction.right, predatorAnimal))
            {
                if (Game.Retreat(this, Direction.left)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.right, targetAnimal))
            {
                Game.Attack(this, Direction.right);
                
            }


        }


        // Did not stipulate on interface because game solving took so long, bare bones answer to prove I know how it works, sorry
        public interface IPrey
        {
            void Flee(string predatorAnimal, string predatorAnimal2);
        }

        public interface IPredator
        {
            void Hunt(string targetAnimal, string targetAnimal2);
            
        }
        public interface ICat
        {
            void CatsAreSoFnWeird(string targetAnimal, string targetAnimal2, string predatorAnimal);


        }



    }

    }
