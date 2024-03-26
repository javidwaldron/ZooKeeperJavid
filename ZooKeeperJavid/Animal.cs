using System;
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
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.down, targetAnimal))
            {
                Game.Attack(this, Direction.down);
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.left, targetAnimal))
            {
                Game.Attack(this, Direction.left);
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.right, targetAnimal))
            {
                Game.Attack(this, Direction.right);
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.up, targetAnimal2))
            {
                Game.Attack(this, Direction.up);
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.down, targetAnimal2))
            {
                Game.Attack(this, Direction.down);
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.left, targetAnimal2))
            {
                Game.Attack(this, Direction.left);
                Game.filledspaces--;
            }
            if (Game.Seek(location.x, location.y, Direction.right, targetAnimal2))
            {
                Game.Attack(this, Direction.right);
                Game.filledspaces--;
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

        }

    }
