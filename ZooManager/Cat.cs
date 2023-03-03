using System;
using System.Collections.Generic;

namespace ZooManager
{
    public class Cat : Animal
    {
        private List<string> preys = new List<string>(){"chick", "mouse"};
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            if (Flee())
            {
                return;
            }
            Hunt();
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
        private bool Flee()
        {
            foreach (string prey in preys)
            {
                if (Game.Seek(location.x, location.y, Direction.up, "raptor"))
                {
                    if (Game.Seek(location.x, location.y, Direction.down, prey))
                    {
                        Game.Attack(this, Direction.down);
                        return true;
                    }
                    
                    if (Game.Retreat(this, Direction.down)) return true;
                }
                if (Game.Seek(location.x, location.y, Direction.down, "raptor"))
                {
                    if (Game.Seek(location.x, location.y, Direction.up, prey))
                    {
                        Game.Attack(this, Direction.up);
                        return true;
                    }
                    if (Game.Retreat(this, Direction.up)) return true;
                }
                if (Game.Seek(location.x, location.y, Direction.left, "raptor"))
                {
                    if (Game.Seek(location.x, location.y, Direction.right, prey))
                    {
                        Game.Attack(this, Direction.right);
                        return true;
                    }
                    if (Game.Retreat(this, Direction.right)) return true;
                }
                if (Game.Seek(location.x, location.y, Direction.right, "raptor"))
                {
                    if (Game.Seek(location.x, location.y, Direction.left, prey))
                    {
                        Game.Attack(this, Direction.left);
                        return true;
                    }
                    if (Game.Retreat(this, Direction.left)) return true;
                }
            }
            
            return false;//no flee
        }

        /*public void Hunt()
        {
            foreach (string prey in preys)
            {
                if (Game.Seek(location.x, location.y, Direction.up, prey))
                {
                    Game.Attack(this, Direction.up);
                }
                else if (Game.Seek(location.x, location.y, Direction.down, prey))
                {
                    Game.Attack(this, Direction.down);
                }
                else if (Game.Seek(location.x, location.y, Direction.left, prey))
                {
                    Game.Attack(this, Direction.left);
                }
                else if (Game.Seek(location.x, location.y, Direction.right, prey))
                {
                    Game.Attack(this, Direction.right);
                }
            }
        }*/
    }
}

