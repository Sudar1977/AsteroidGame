using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    /// <summary> Класс игровой логики </summary>
    internal static class Game
    {
        /// <summary> Интервал времени таймера кадра игры    </summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;
        /// <summary> Высота игрового поля </summary>
        public static int Width { get; private set; }
        /// <summary> Ширина игрового поля </summary>
        public static int Height { get; private set; }
        /// <summary> Инициализация игровой логики </summary>
        /// <param name="form"> Игровая форма </param>
        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;
            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = __TimerInterval };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object Sender, EventArgs e)
        {
            Update();
            Draw();
        }
        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));
            foreach (var game_object in __GameObjects)
                game_object.Draw(g);

            __Buffer.Render();

        }

        public static void Load()
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            //__GameObjects = new VisualObject[30];

            //for (var i = 0; i < 30; i++) //1:26:47
            //{
            //    game_objects.Add( 
            //        new VisualObject(
            //            new Point(600, i * 20), 
            //            new Point(15 - i, 20 - i), 
            //            new Size(20, 20)));
            //}
            for (var i = 0; i < 10; i++)
            {
                game_objects.Add(
                    new Star(
                        new Point(600, (int)(i / 2.0 * 20)),
                        new Point(-i, 0),
                        10));
            }
            __GameObjects = game_objects.ToArray();//1:23:23 
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.Update();
        }


    }
}
