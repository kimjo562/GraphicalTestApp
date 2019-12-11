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

            EnemyTank enemy = new EnemyTank(1000, 500, "ufoRed.png");
            root.AddChild(enemy);

            EnemyTank enemy2 = new EnemyTank(450, 600, "ufoRed.png");
            root.AddChild(enemy2);

            EnemyTank enemy3 = new EnemyTank(600, 300, "ufoRed.png");
            root.AddChild(enemy3);

            //## Set up game here ##//

            game.Run();
        }
    }
}
