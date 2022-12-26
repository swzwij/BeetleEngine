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

        readonly int playerSpeed = 4;
        readonly Vector2 gravityForce = new Vector2(0, 2);
        List<GameObject> gameObjects = new List<GameObject>();

        public override void OnLoad()
        {
            string[,] map = new string[12, 20]
            {
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "e" , "." , "." , "." ,},
                { "w" , "." , "e" , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "e" , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." , "." ,},
                { "w" , "." , "." , "." , "." , "." , "." , "w" , "." , "e" , "." , "." , "." , "." , "e" , "." , "." , "." , "." , "." ,},
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
                player = new GameObject("player", playerPosition, Color.Blue, "player", true);
            }

            List<Vector2> wallTiles = Room.GetTiles("w");
            for (int i = 0; i < wallTiles.Count; i++)
            {
                Transform wallPosition = new Transform(wallTiles[i], new Vector2(50, 50));
                new GameObject("Wall " + i, wallPosition, Color.Black, "wall");
            }

            List<Vector2> enemies = Room.GetTiles("e");
            for (int i = 0; i < enemies.Count; i++)
            {
                Transform enemyPosition = new Transform(enemies[i], new Vector2(50, 50));
                new GameObject("Enemy " + i, enemyPosition, Color.Red, "enemy", true);
            }
        }

        public override void OnUpdate()
        {
            if (W) player.Transform.Position.y -= playerSpeed;
            if (S) player.Transform.Position.y += playerSpeed;
            if (A) player.Transform.Position.x -= playerSpeed;
            if (D) player.Transform.Position.x += playerSpeed;

            int l = renderStack.Count;
            for (int i = 0; i < l; i++)
            {
                GameObject currentObject = renderStack[i];

                if (!currentObject.HasGravity) continue;
                
                currentObject.Transform.Position += gravityForce;

                if (!currentObject.IsColliding("wall")) continue;

                currentObject.HasGravity = false;
                currentObject.Transform.Position -= gravityForce;
                currentObject.Color = Color.Green;
            }
        }
    }
}
