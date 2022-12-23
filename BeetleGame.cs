using BugEngine;
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
        public BeetleGame() : base(new Vector2(1000, 750), "Beetle Game") { }

        Shape player;

        bool playerIsColliding;
        int playerSpeed = 4;

        public override void OnLoad()
        {
            string[,] map = new string[10, 10]
            {
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "e" , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "p" , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "w" , "w" , "w" , "w" , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
            };

            Room.AddRoom(map);

            foreach (Vector2 i in Room.GetTiles("w"))
            {
                new Shape(i, new Vector2(50, 50), Color.Black, "wall");
            }

            foreach (Vector2 i in Room.GetTiles("p"))
            {
                player = new Shape(i, new Vector2(50, 50), Color.Blue, "player");
            }

            foreach (Vector2 i in Room.GetTiles("e"))
            {
                new Shape(i, new Vector2(50, 50), Color.Red, "enemy");
            }
        }

        public override void OnUpdate()
        {
            // TODO: Fix input
            if (W) player.Position.y -= playerSpeed;
            if (S) player.Position.y += playerSpeed;
            if (A) player.Position.x -= playerSpeed;
            if (D) player.Position.x += playerSpeed;

            if (player.IsCollided(player, "enemy") || player.IsCollided(player, "wall"))
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
