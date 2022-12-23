using BeetleEngine;
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

        int playerSpeed = 4;
        Vector2 testVec = new Vector2(5 ,10);

        public override void OnLoad()
        {
            string[,] map = new string[20, 10]
            {
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "e" , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "p" , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "e" , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "w" , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "e" , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
            };

            Room.AddRoom(map);

            foreach (Vector2 i in Room.GetTiles("w"))
            {
                new Shape(i, new Vector2(50, 50), Color.Black, "wall");
            }

            foreach (Vector2 i in Room.GetTiles("e"))
            {
                new Shape(i, new Vector2(50, 50), Color.Red, "enemy");
            }

            foreach (Vector2 i in Room.GetTiles("p"))
            {
                player = new Shape(i, new Vector2(50, 50), Color.Blue, "player");
            }

            double mag = testVec.Magnitude();
            Vector2 norm = testVec.Normalized();

            Console.WriteLine(testVec.x + " " + testVec.y);
            Console.WriteLine(mag);
            Console.WriteLine(norm.x + " " + norm.y);
            Console.WriteLine(" ");
        }

        public override void OnUpdate()
        {
            // TODO: Fix input

            if (W) player.Position.y -= playerSpeed;
            if (S) player.Position.y += playerSpeed;
            if (A) player.Position.x -= playerSpeed;
            if (D) player.Position.x += playerSpeed;

            if (player.IsColliding("enemy") || player.IsColliding("wall"))
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
