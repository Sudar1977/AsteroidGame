﻿using AsteroidGame.VisualObjects;
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
        private const int __TimerInterval = 20;

        const int asteroid_count = 10;
        const int asteroid_size = 50;
        const int asteroid_max_speed = 20;

        const int enemy_count = 10;
        const int enemy_size = 50;
        const int enemy_max_speed = 20;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;
        private static Bullet      __Bullet;
        private static SpaceSheep __SpaceSheep;

        private static Random rnd;

        private static Timer  __Timer;
        private static Button __ButtonNewGame;


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

            __Timer = new Timer { Interval = __TimerInterval };
            __Timer.Tick += OnTimerTick;
            __Timer.Start();

            rnd = new Random();

            form.KeyDown += OnFormKeyDown;

            __ButtonNewGame = new Button();
            __ButtonNewGame.Width = 200;
            __ButtonNewGame.Height = 30;
            __ButtonNewGame.Text = "New GAME!!!";
            __ButtonNewGame.Left = 20;
            __ButtonNewGame.Top = 30;
            __ButtonNewGame.Click += OnTestButtonClicked;
            __ButtonNewGame.Visible = false;
            form.Controls.Add(__ButtonNewGame);
            //test_button
        }

        private static void OnTestButtonClicked(object Sender, EventArgs e)
        {
            //MessageBox.Show("Just do it!!!!");
            __ButtonNewGame.Visible = false;
            //Music.MissionImpossible();
            __Timer.Start();
        }
        private static void OnFormKeyDown(object Sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                case Keys.Space:
                    __Bullet = new Bullet(__SpaceSheep.Rect.Y);
                    break;

                case Keys.Up:
                case Keys.W:
                    __SpaceSheep.MoveUp();
                    break;

                case Keys.Down:
                case Keys.S:
                    __SpaceSheep.MoveDown();
                    break;
            }
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
                game_object?.Draw(g);

            __SpaceSheep.Draw(g);
            __Bullet?.Draw(g);
            if (!__Timer.Enabled)
                return;
            __Buffer.Render();

        }

        public static void Load()
        {
            List<VisualObject> game_objects = new List<VisualObject>();

            for (var i = 0; i < 10; i++)
            {
                game_objects.Add(
                    new Star(
                        new Point(600, (int)(i / 2.0 * 20)),
                        new Point(-i, 0),
                        10));
            }

            //var rnd = new Random();

            for(var i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(
                    new Asteroid(
                        new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                        new Point(-rnd.Next(0, asteroid_max_speed), 0),
                        asteroid_size));
            }

            for (var i = 0; i < enemy_count; i++)
            {
                game_objects.Add(
                    new EnemySheep(
                        new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                        new Point(-rnd.Next(0, enemy_max_speed), 0),
                        enemy_size));
            }

            game_objects.Add(new Asteroid(new Point(Width / 2, 200), new Point(-asteroid_max_speed, 0), asteroid_size));

            __Bullet = new Bullet(200);
             
            __GameObjects = game_objects.ToArray();//1:23:23 

            __SpaceSheep = new SpaceSheep(new Point(10,400),new Point(5,5),new Size(10,10));
            __SpaceSheep.Destoyed += OnSheepDestroyed;
        }

        private static void OnSheepDestroyed(object sender,EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            __ButtonNewGame.Visible = true;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif,60,FontStyle.Bold),Brushes.Red,200,100);
            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object?.Update();
            __Bullet?.Update();

            for(var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if(obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    __SpaceSheep.CheckCollision(collision_object);
                    if (__Bullet != null)
                    {
                        if (__Bullet.CheckCollision(collision_object))
                        {
                            __Bullet = null;
                            if (collision_object is Asteroid)
                                __GameObjects[i] = new Asteroid(
                                                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                                                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                                                    asteroid_size);
                            if (collision_object is EnemySheep)
                                __GameObjects[i] = new EnemySheep(
                                                     new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                                                     new Point(-rnd.Next(0, enemy_max_speed), 0),
                                                     enemy_size);
                            Console.Beep(250, 100);
                        }
                    }
                }
            }
        }
    }
}
