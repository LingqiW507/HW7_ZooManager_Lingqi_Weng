using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Raptor : Bird
    {
        private List<string> preys = new List<string>(){"cat","mouse"};
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = 1;
        }
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a Raptor. Screech.");
            Hunt(preys);
        }

        private void Hunt(List<string> preys)
        {
            foreach (string prey in preys)
            {
                    if (Seek(location.x, location.y, Direction.up, prey))
                    {
                        Attack(this, Direction.up);
                    }
                    else if (Seek(location.x, location.y, Direction.down, prey))
                    {
                        Attack(this, Direction.down);
                    }
                    else if (Seek(location.x, location.y, Direction.left, prey))
                    {
                        Attack(this, Direction.left);
                    }
                    else if (Seek(location.x, location.y, Direction.right, prey))
                    {
                        Attack(this, Direction.right);
                    }
                
            }
            
        }
        
    }
}