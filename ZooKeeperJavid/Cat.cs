using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperJavid
{
    public class Cat : Animal, Animal.ICat
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

        

       

    }
}
