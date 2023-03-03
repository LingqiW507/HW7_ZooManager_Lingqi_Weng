using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Chick : Bird
    {
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 11); //reaction time of 6 to 10
            
        }
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick. Peep.");
            Flee();
            Mature();
        }
        //n.each Chick grows up after three turns.
        public void Mature()
        {

            if (TurnsOnBoard == 4)// check if Chick has been on the board for 3 turns.
            {//when it is the fourth turns of this chick...
                Raptor raptor = new Raptor("Cruel");
                Game.ReplaceAnimal(this, raptor);//replace chick with new Raptor 
            }
        }

        private void Flee()
        {
            if (Seek(location.x, location.y, Direction.up, "cat"))
            {
                if (Retreat(this, Direction.down)) return;
            }
            if (Seek(location.x, location.y, Direction.down, "cat"))
            {
                if (Retreat(this, Direction.up)) return;
            }
            if (Seek(location.x, location.y, Direction.left, "cat"))
            {
                if (Retreat(this, Direction.right)) return;
            }
            if (Seek(location.x, location.y, Direction.right, "cat"))
            {
                if (Retreat(this, Direction.left)) return;
            }
        }

    }

}
