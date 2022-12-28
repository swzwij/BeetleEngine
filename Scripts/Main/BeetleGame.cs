using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BeetleEngine
{
    class BeetleGame : BeetleEngine
    {
        public BeetleGame() : base(new Vector2(1050, 575), "Beetle Game") { }

        GameObject player;
        GameObject mouseObj;

        float cameraSpeed = 3f;
        readonly Vector2 gravityForce = new Vector2(0, 2);
        List<GameObject> gameObjects = new List<GameObject>();

        public override void OnLoad()
        {
            string[,] map = new string[18, 20]
            {
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
                {".",".",".",".",".",".",".",".",".",".",".",".",".","e",".",".",".",".",".",".",},
                {".",".",".","e",".",".",".",".",".",".",".",".",".",".",".",".",".",".","e",".",},
                {".",".",".",".",".",".",".",".",".","e",".",".",".",".",".",".",".",".",".",".",},
                {".",".",".",".",".","e",".",".",".",".",".",".",".",".","e",".",".",".",".",".",},
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".","e",".",".",".",},
                {".",".","e",".",".",".",".","e",".",".",".",".","e",".",".",".",".",".",".",".",},
                {".",".",".",".",".",".",".",".",".",".",".","e",".",".",".",".",".",".",".",".",},
                {".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w",},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w",},
                {"w","w","w","w","w","w",".",".",".","w","w","w","w","w","w","w","w","w","w","w",},
                {"w","w","w","w","w",".",".","w","w","w","w","w","w","w","w","w","w","w","w","w",},
                {"w","w","w","w","w",".",".",".",".","w","w","w","w","w","w","w","w","w","w","w",},
                {"w","w","w","w","w","w",".","w",".","w","w","w","w","w","w","w","w","w","w","w",},
                {"w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w","w",},
                {"p",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",".",},
            };

            Room.AddRoom(map);

            Transform mousePosition = new Transform(new Vector2(0, 0), new Vector2(50, 50));
            mouseObj = new GameObject("Mouse", mousePosition, Color.Orange, "mouse");

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
            debug.Log("AAHAHA");
            debug.Error("Nullrefenen rence");
            debug.Warning("unreachable code");

            mouseObj.Transform.Position = mouseInput.MousePosition - new Vector2(25, 50);
            Vector2 camerPositon = new Vector2(0, 0);

            if (keyInput.Up) camerPositon.y += cameraSpeed;
            if (keyInput.Down) camerPositon.y -= cameraSpeed;
            if (keyInput.Left) camerPositon.x += cameraSpeed;
            if (keyInput.Right) camerPositon.x -= cameraSpeed;
            
            for (int i = 0; i < renderStack.Count; i++)
            {
                renderStack[i].Transform.Position += camerPositon;
            }
            
            if(keyInput.Plus)
            {
                cameraSpeed += 1;
            }
            if (keyInput.Minus)
            {
                cameraSpeed -= 1;
            }

            if(keyInput.Esc)
            {
                if (System.Windows.Forms.Application.MessageLoop) System.Windows.Forms.Application.Exit();
                else Environment.Exit(1);
            }

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
