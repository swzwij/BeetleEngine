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

        GameObject player;

        int playerSpeed = 4;
        Vector2 testVec = new Vector2(5 ,10);

        List<GameObject> gravityObjects = new List<GameObject>();
        int gravityForce = 1;

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

            List<Vector2> players = Room.GetTiles("p");
            for (int i = 0; i < players.Count; i++)
            {
                player = new GameObject(players[i], new Vector2(50, 50), Color.Blue, "player", true);

                if (player.HasGravity) gravityObjects.Add(player);
            }

            List<Vector2> wallTiles = Room.GetTiles("w");
            for (int i = 0; i < wallTiles.Count; i++)
            {
                new GameObject(wallTiles[i], new Vector2(50, 50), Color.Black, "wall");
            }

            List<Vector2> enemies = Room.GetTiles("e");
            for (int i = 0; i < enemies.Count; i++)
            {
                GameObject newEnemy = new GameObject(enemies[i], new Vector2(50, 50), Color.Red, "enemy", true);
                if (newEnemy.HasGravity) gravityObjects.Add(newEnemy);
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

            foreach (GameObject gravityObject in gravityObjects)
            {
                gravityObject.Position += new Vector2(0, gravityForce);
            }
        }
    }
}
