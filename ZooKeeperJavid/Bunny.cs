using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperJavid
{
    public class Bunny : Animal , Animal.IPrey
    {

        public Bunny(string name) 
        {
            emoji = "🐇";
            species = "bunny";
            this.name = name;
            reactionTime = new Random().Next(1, 10);


        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a bunny.You ever see watership down?");
            string predatorAnimal = "raptor";
            string predatorAnimal2 = null;

            Flee(predatorAnimal, predatorAnimal2);
        }




    }
}
