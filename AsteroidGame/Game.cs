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
    internal  class Game
    {
        /// <summary> Интервал времени таймера кадра игры    </summary>
        private const int __TimerInterval = 20;

        /// <summary> Task 4 Lesson 3 Добавить подсчет очков за сбитые астероиды./// </summary>
        private static int _Counter = 0;

        public const int asteroid_count = 10;
        public const int asteroid_size = 50;
        public const int asteroid_max_speed = 20;

        public const int enemy_count = 10;
        public const int enemy_size = 50;
        public const int enemy_max_speed = 20;

        private  BufferedGraphicsContext __Context;
        private  BufferedGraphics __Buffer;

        private VisualObject[] _GameObjects;
        //private static Bullet      __Bullet;
        public static List <Bullet> __Bullets = new List<Bullet>();
        public static  SpaceShip __SpaceShip;
        private SpaceShipController _SpaceShipController = new SpaceShipController();


        private Timer  __Timer;
        private Button __ButtonNewGame;

        private readonly Random _Rnd = new Random();
        private readonly IEnemyFactory _AsteroidFactory = new AsteroidFactory();
        private readonly IEnemyFactory _EnemyShipFactory = new EnemySheepFactory();
        private readonly LoadScens _LoadScens = new LoadScens();

        private readonly TextureBrush _Texture1 = new TextureBrush(Properties.Resources.DeathStar);
        //private static readonly TextureBrush _Texture1 = new TextureBrush(Properties.Resources.StarDestroyer3);
        //private static readonly TextureBrush _Texture1 = new TextureBrush(Properties.Resources.StarWars);


        /// <summary> Высота игрового поля </summary>
        public static int Width { get; private set; }
        /// <summary> Ширина игрового поля </summary>
        public static int Height { get; private set; }
        /// <summary> Инициализация игровой логики </summary>
        /// <param name="form"> Игровая форма </param>
        public void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;
            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            __Timer = new Timer { Interval = __TimerInterval };
            __Timer.Tick += OnTimerTick;
            __Timer.Start();

            form.KeyDown += _SpaceShipController.OnFormKeyDown;
            form.MouseMove += _SpaceShipController.MouseEvent;//https://www.youtube.com/watch?v=onMsYF9-HCg&list=PLqzmfPe9NPAkWg17LqEYCqXydTwShErLf
            form.MouseClick += _SpaceShipController.MouseClick;
            //form.KeyPress += OnFormKeyPress;

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

        private void OnTestButtonClicked(object Sender, EventArgs e)
        {
            //MessageBox.Show("Just do it!!!!");
            __ButtonNewGame.Visible = false;
            //Music.MissionImpossible();
            __Timer.Start();
        }

        private void OnTimerTick(object Sender, EventArgs e)
        {
            Update();
            this.Draw();
        }
        public void Draw()
        {
            Graphics g = __Buffer.Graphics;
            g.Clear(Color.Black);
            g.FillRectangle(_Texture1, new RectangleF(0, 0, _Texture1.Image.Width, _Texture1.Image.Height));
            g.DrawString($"{_Counter}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 10);
            g.DrawString($"{__SpaceShip.Energy}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 35);
            foreach (var game_object in _GameObjects)
                game_object?.Draw(g);
            __SpaceShip.Draw(g);
            __Bullets.ForEach(bullet => bullet.Draw(g));
            if (!__Timer.Enabled)
                return;
            __Buffer.Render();
        }

        public void Load()
        {
            __SpaceShip = new SpaceShip(new Point(20, 400), new Point(10, 10));
            __SpaceShip.Destoyed += OnSheepDestroyed;
            _GameObjects = _LoadScens.LoadSceneObjects(_Rnd);
        }

        private void OnSheepDestroyed(object sender,EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            __ButtonNewGame.Visible = true;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif,60,FontStyle.Bold),Brushes.Red,200,100);
            __Buffer.Render();
        }


        public void Update()
        {
            foreach (var game_object in _GameObjects)
                game_object?.Update();
            //__Bullet?.Update();
            __Bullets.ForEach(bullet => bullet.Update());

            foreach (var bullet_to_remove in __Bullets.Where(b => b.Rect.Left > Width).ToArray())
                __Bullets.Remove(bullet_to_remove);

            for(var i = 0; i < _GameObjects.Length; i++)
            {
                var obj = _GameObjects[i];
                if(obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    if(__SpaceShip.CheckCollision(collision_object))
                    {

                    }
                    foreach (var bullet in __Bullets.ToArray())
                    {

                        if (bullet.CheckCollision(collision_object))
                        {
                            _Counter++;
                            __Bullets.Remove(bullet);
                            //bullet = null;
                            if (collision_object is Asteroid)
                               _GameObjects[i] = (Asteroid)_AsteroidFactory.Create(_Rnd);
                               // obj  = (Asteroid)__AsteroidFactory.Create(__Rnd);
                            if (collision_object is EnemySheep)
                                _GameObjects[i] = (EnemySheep)_EnemyShipFactory.Create(_Rnd);
                            Console.Beep(250, 100);
                        }
                    }
                }
            }
        }
    }
}
