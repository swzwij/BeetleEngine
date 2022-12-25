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

        public static bool W, A, S, D;

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
                    (int)currentGameObject.Position.x,
                    (int)currentGameObject.Position.y,
                    (int)currentGameObject.Scale.x,
                    (int)currentGameObject.Scale.y);
            }
        }

        private void GetInput()
        {
            W = ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0) ? true : false;
            A = ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0) ? true : false;
            S = ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0) ? true : false;
            D = ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0) ? true : false;
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
    }
}
