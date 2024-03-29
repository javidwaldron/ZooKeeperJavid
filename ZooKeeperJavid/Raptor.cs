using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperJavid
{
    public class Raptor : Bird, Animal.IPredator
    {
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = 1;

        }

        public override void Activate()
        {

            base.Activate();
            Console.WriteLine("I am a raptor. Rawr.");

            string targetAnimal = "mouse";
            string targetAnimal2 = "cat";

            Hunt(targetAnimal, targetAnimal2);
        }
    }
}
