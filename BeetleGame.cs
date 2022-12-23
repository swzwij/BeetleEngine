using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeetleEngine
{
    class BeetleGame : BeetleEngine
    {
        public BeetleGame() : base(new Vector2(800, 400), "Beetle Game") { }

        Shape player;
        Shape enemy;
        Shape enemy2;
        Shape enemy3;

        int playerSpeed = 4;

        public override void OnLoad()
        {
            enemy = new Shape(new Vector2(600, 200), new Vector2(50, 50), Color.Red, "enemy");
            enemy2 = new Shape(new Vector2(500, 100), new Vector2(50, 50), Color.Red, "enemy");
            enemy3 = new Shape(new Vector2(400, 50), new Vector2(50, 50), Color.Red, "enemy");
            player = new Shape(new Vector2(200, 200), new Vector2(50, 50), Color.Blue, "player");
        }

        public override void OnUpdate()
        {
            // TODO: Fix input
            if (W) player.Position.y -= playerSpeed;
            if (S) player.Position.y += playerSpeed;
            if (A) player.Position.x -= playerSpeed;
            if (D) player.Position.x += playerSpeed;

            if (player.IsCollided(player, "enemy"))
            {
                Console.WriteLine("Collision");
                player.Color = Color.Green;
            }
            else
            {
                player.Color = Color.Blue;
            }
        }
    }
}
