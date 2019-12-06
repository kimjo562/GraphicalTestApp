using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1280, 768, "Yes.YeetYeet");

            Actor root = new Actor();
            game.Root = root;

            Pilot pilot = new Pilot(300, 300, "pilot.png");
            root.AddChild(pilot);

            //## Set up game here ##//

            game.Run();
        }
    }
}
