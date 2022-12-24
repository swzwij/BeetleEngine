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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Canvas));
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }
    }

    public abstract class BeetleEngine
    {
        public static Vector2 screenSize = new Vector2(500, 500);
        public string title;
        public Canvas window;
        public Color windowBackground;
        private Thread _gameLoopThread;
        public static List<Shape> renderStack = new List<Shape>();

        public static bool W, A, S, D;

        public BeetleEngine(Vector2 newScreenSize, string newTitle)
        {
            screenSize = newScreenSize;
            this.title = newTitle;
            windowBackground = Color.White;

            window = new Canvas();
            window.Size = new Size((int)screenSize.x, (int)screenSize.y);
            window.Text = this.title;
            window.Opacity = 1;
            window.Paint += Renderer;

            _gameLoopThread = new Thread(GameLoop);
            _gameLoopThread.SetApartmentState(ApartmentState.STA);
            _gameLoopThread.Start();

            

            Application.Run(window);
        }

        public static void RegisterShape(Shape newShape)
        {
            if (newShape == null) return;

            renderStack.Add(newShape);
        }

        public static List<Shape> GetShapesWithTag(string requiredTag)
        {
            List<Shape> shapesWithTag = new List<Shape>();
            for (int i = 0; i < renderStack.Count; i++)
            {
                Shape currentShape = renderStack[i];
                if (currentShape.Tag == requiredTag) shapesWithTag.Add(currentShape);
            }
            return shapesWithTag;
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

            List<Shape> render = new List<Shape>(renderStack);
            for (int i = renderStack.Count - 1; i >= 0; i--)
            {
                Shape currentShape = renderStack[i];

                graphics.FillRectangle(
                    new SolidBrush(currentShape.Color),
                    (int)currentShape.Position.x,
                    (int)currentShape.Position.y,
                    (int)currentShape.Scale.x,
                    (int)currentShape.Scale.y);
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
