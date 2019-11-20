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
            Game game = new Game(1280, 960, "Yes.YeetYeet");

            Actor root = new Actor();
            game.Root = root;

            TankBody bodyTank = new TankBody(150, 150, "tankBlue.png");
            root.AddChild(bodyTank);


            //## Set up game here ##//

            game.Run();
        }
    }
}
