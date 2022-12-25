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
        public BeetleGame() : base(new Vector2(1050, 575), "Beetle Game") { }

        GameObject player;

        int playerSpeed = 4;
        Vector2 testVec = new Vector2(5 ,10);

        List<GameObject> enemyObjects = new List<GameObject>();
        List<GameObject> gravityObjects = new List<GameObject>();
        int gravityForce = 1;

        public override void OnLoad()
        {
            string[,] map = new string[12, 20]
            {
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "e" , "." , "e" , "." ,},
                { "w" , "." , "e" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "e" , "." , "." , "." , "e" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "w" , "." , "." , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "w" , "w" , "w" , "." , "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "w" , "w" , "w" ,},
                { "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "." , "." , "." , "w" , "w" , "." , "." , "w" , "w" , "w" , "w" , "w" ,},
                { "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" , "w" ,},
                { "." , "p" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
            };

            Room.AddRoom(map);

            List<Vector2> players = Room.GetTiles("p");
            for (int i = 0; i < players.Count; i++)
            {
                Transform playerPosition = new Transform(players[i], new Vector2(50, 50));
                player = new GameObject(playerPosition, Color.Blue, "player", true);

                if (player.HasGravity) gravityObjects.Add(player);
            }

            List<Vector2> wallTiles = Room.GetTiles("w");
            for (int i = 0; i < wallTiles.Count; i++)
            {
                Transform wallPosition = new Transform(wallTiles[i], new Vector2(50, 50));
                new GameObject(wallPosition, Color.Black, "wall");
            }

            List<Vector2> enemies = Room.GetTiles("e");
            for (int i = 0; i < enemies.Count; i++)
            {
                Transform enemyPosition = new Transform(enemies[i], new Vector2(50, 50));
                GameObject newEnemy = new GameObject(enemyPosition, Color.Red, "enemy", true);
                enemyObjects.Add(newEnemy);
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
            if (W) player.Transform.Position.y -= playerSpeed;
            if (S) player.Transform.Position.y += playerSpeed;
            if (A) player.Transform.Position.x -= playerSpeed;
            if (D) player.Transform.Position.x += playerSpeed;

            if (player.IsColliding("enemy") || player.IsColliding("wall"))
            {
                Console.WriteLine("Collision");
                player.Color = Color.Green;
                player.HasGravity = false;
                gravityObjects.Remove(player);
            }
            else player.Color = Color.Blue;

            foreach (GameObject enemy in enemyObjects)
            {
                if(enemy.IsColliding("wall"))
                {
                    enemy.Color = Color.Green;
                    enemy.HasGravity = false;
                    gravityObjects.Remove(enemy);
                }
            }

            foreach (GameObject gravityObject in gravityObjects)
            {
                gravityObject.Transform.Position += new Vector2(0, gravityForce);
            }
        }
    }
}
