using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Chick : Bird
    {
        private int turnsAlive;
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 11); //reaction time of 6 to 10
            turnsAlive = 0;
        }
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a chick. Peep.");
            Flee();
        }
        //n 
        public override void Mature(Board board)
        {
            TurnsOnBoard++;

            if (TurnsOnBoard == 4)// check if Chick has been on the board for 3 turns
            {
                Raptor raptor = new Raptor(string);
                board.ReplaceAnimal(this,raptor);//replace chick with new Raptor 
            }
        }

        private void Flee()
        {
            if (Game.Seek(location.x, location.y, Direction.up, "cat"))
            {
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.down, "cat"))
            {
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.left, "cat"))
            {
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Game.Seek(location.x, location.y, Direction.right, "cat"))
            {
                if (Game.Retreat(this, Direction.left)) return;
            }
        }

    }

}
