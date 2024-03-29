using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooKeeperJavid
{
    public class Elephant : Animal, Animal.IPrey
    {


        public Elephant(string name)
        {
            emoji = "🐘";
            species = "elephant";
            this.name = name;
            reactionTime = new Random().Next(1, 3);


        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a elephant. SCREAM.");
            string predatorAnimal = "mouse";
            string predatorAnimal2 = null;

            Flee(predatorAnimal, predatorAnimal2);
        }




    }



    
}
