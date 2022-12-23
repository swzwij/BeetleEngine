using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BugEngine
{
    public static class Room
    {
        public static List<string[,]> Rooms = new List<string[,]>();
        public static int CurrentRoom = 0;

        public static void AddRoom(string[,] room)
        {
            Rooms.Add(room);
        }

        public static string[,] GetCurrentRoom()
        {
            return Rooms[CurrentRoom];
        }

        public static List<Vector2> GetTiles(string tileName)
        {
            List<Vector2> v = new List<Vector2>();

            for (int x = 0; x < GetCurrentRoom().GetLength(1); x++)
            {
                for (int y = 0; y < GetCurrentRoom().GetLength(0); y++)
                {
                    if (GetCurrentRoom()[y,x] == tileName)
                    {
                        v.Add(new Vector2(x * 50, y * 50));
                    }
                }
            }
            return v;
        }
    }
}
