using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
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
            windowBackground = Color.Gray;

            window = new Canvas();
            window.Size = new Size((int)screenSize.x, (int)screenSize.y);
            window.Text = this.title;
            window.BackColor = windowBackground;
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

            foreach (Shape shape in renderStack) // TODO: For Each of Loop. FF cheken met nieuwste c# versie
            {
                if (shape.Tag == requiredTag) shapesWithTag.Add(shape);
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
            graphics.Clear(Color.White);

            List<Shape> render = new List<Shape>(renderStack); // TODO: make render list go backwards so earlier created shapes have higher layer

            foreach (Shape shape in render)
            {
                graphics.FillRectangle(
                    new SolidBrush(shape.Color), 
                    (int)shape.Position.x, 
                    (int)shape.Position.y, 
                    (int)shape.Scale.x, 
                    (int)shape.Scale.y);
            }
        }

        private void GetInput()
        {
            // TODO: Fix input
            W = ((Keyboard.GetKeyStates(Key.W) & KeyStates.Down) > 0) ? true : false;
            A = ((Keyboard.GetKeyStates(Key.A) & KeyStates.Down) > 0) ? true : false;
            S = ((Keyboard.GetKeyStates(Key.S) & KeyStates.Down) > 0) ? true : false;
            D = ((Keyboard.GetKeyStates(Key.D) & KeyStates.Down) > 0) ? true : false;
        }

        public abstract void OnLoad();
        public abstract void OnUpdate();
    }
}
