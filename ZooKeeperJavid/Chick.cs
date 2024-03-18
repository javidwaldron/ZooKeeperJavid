using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperJavid
{
    public class Chick : Bird
    {
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 11);

        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick. Cheep.");

            string predatorAnimal = "cat";
            string predatorAnimal2 = null;

            Flee(predatorAnimal, predatorAnimal2);
        }





    }
}
