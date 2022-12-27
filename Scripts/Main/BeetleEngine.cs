using BeetleEngine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace BeetleEngine
{
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }

    public abstract class BeetleEngine
    {
        public static Vector2 screenSize = new Vector2(500, 500);
        public string title;
        public Canvas window;
        public Color windowBackground;
        private readonly Thread gameLoopThread;
        public static List<GameObject> renderStack = new List<GameObject>();

        public Input input = new Input();

        public BeetleEngine(Vector2 newScreenSize, string newTitle)
        {
            screenSize = newScreenSize;
            this.title = newTitle;
            windowBackground = Color.White;

            window = new Canvas
            {
                Size = new Size((int)screenSize.x, (int)screenSize.y),
                Text = this.title,
                Opacity = 1
            };
            window.Paint += Renderer;

            gameLoopThread = new Thread(GameLoop);
            gameLoopThread.SetApartmentState(ApartmentState.STA);
            gameLoopThread.Start();

            

            Application.Run(window);
        }

        public static void RegisterGameObject(GameObject newGameObject)
        {
            if (newGameObject == null) return;

            renderStack.Add(newGameObject);
        }

        public static List<GameObject> GetGameObjectsWithTag(string requiredTag)
        {
            List<GameObject> gameObjectsWithTag = new List<GameObject>();
            for (int i = 0; i < renderStack.Count; i++)
            {
                GameObject currentGameObject = renderStack[i];
                if (currentGameObject.Tag == requiredTag) gameObjectsWithTag.Add(currentGameObject);
            }
            return gameObjectsWithTag;
        }
        
        private void GameLoop()
        {
            OnLoad();
            while(true)
            {
                try
                {
                    GetInput();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch (Exception)
                {

                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(windowBackground);

            List<GameObject> render = new List<GameObject>(renderStack);
            for (int i = renderStack.Count - 1; i >= 0; i--)
            {
                GameObject currentGameObject = renderStack[i];

                graphics.FillRectangle(
                    new SolidBrush(currentGameObject.Color),
                    (int)currentGameObject.Transform.Position.x,
                    (int)currentGameObject.Transform.Position.y,
                    (int)currentGameObject.Transform.Scale.x,
                    (int)currentGameObject.Transform.Scale.y);
            }
        }

        private void GetInput()
        {
            input.Up = ((Keyboard.GetKeyStates(Key.Up) & KeyStates.Down) > 0) ? true : false;
            input.Down = ((Keyboard.GetKeyStates(Key.Down) & KeyStates.Down) > 0) ? true : false;
            input.Left = ((Keyboard.GetKeyStates(Key.Left) & KeyStates.Down) > 0) ? true : false;
            input.Right = ((Keyboard.GetKeyStates(Key.Right) & KeyStates.Down) > 0) ? true : false;
            input.Plus = ((Keyboard.GetKeyStates(Key.P) & KeyStates.Down) > 0) ? true : false;
            input.Minus = ((Keyboard.GetKeyStates(Key.O) & KeyStates.Down) > 0) ? true : false;

            System.Drawing.Point mousePoint = System.Windows.Forms.Control.MousePosition;
            input.MousePos = new Vector2(mousePoint.X, mousePoint.Y);
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
    }
}
