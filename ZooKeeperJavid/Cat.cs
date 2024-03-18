using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperJavid
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6);
        }

        public override void Activate()
        {

            base.Activate();
            Console.WriteLine("I am a cat. Meow.");

            string targetAnimal = "mouse";
            string targetAnimal2 = "chick";
            string predatorAnimal = "raptor";

            CatsAreSoFnWeird(targetAnimal, targetAnimal2, predatorAnimal);
        }

        // A combination of flee and hunt, I think answers question e to the best of my ability. If statement prioritizes raptor flee movements before hunt movements

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

    }
}
