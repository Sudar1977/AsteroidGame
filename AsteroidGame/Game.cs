using AsteroidGame.VisualObjects;
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
    internal class Game
    {
        /// <summary> Интервал времени таймера кадра игры    </summary>
        private const int __TimerInterval = 20;

        /// <summary> Task 4 Lesson 3 Добавить подсчет очков за сбитые астероиды./// </summary>
        public static int _Counter = 0;

        public const int asteroid_count = 10;
        public const int asteroid_size = 50;
        public const int asteroid_max_speed = 20;

        public const int enemy_count = 10;
        public const int enemy_size = 50;
        public const int enemy_max_speed = 20;

        private BufferedGraphicsContext __Context;
        private BufferedGraphics __Buffer;

        private VisualObject[] _GameObjects;

        public static SpaceShip __SpaceShip;

        private Timer __Timer;
        private Button __ButtonNewGame;

        private readonly Random _Rnd = new Random();
        private readonly LoadScens _LoadScens = new LoadScens();
        private SpaceShipController _SpaceShipController;
        private readonly CollisionCotroller _CollisionCotroller = new CollisionCotroller();
        private readonly BulletCollisionController _BulletCollisionController = new BulletCollisionController();
        private BulletsList _BulletsList;// = new BulletsList();

        private readonly TextureBrush _BackGroundTexture = new TextureBrush(Properties.Resources.DeathStar);
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


            _BulletsList = new BulletsList();
            __SpaceShip = new SpaceShip(new Point(20, 400), new Point(10, 10));
            _SpaceShipController = new SpaceShipController(__SpaceShip);
            __SpaceShip.Destoyed += OnSheepDestroyed;
            __SpaceShip.BulletShoot += _BulletsList.OnBulletShoot;

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
            __SpaceShip.EnergyRestore();
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
            g.FillRectangle(_BackGroundTexture, new RectangleF(0, 0, _BackGroundTexture.Image.Width, _BackGroundTexture.Image.Height));
            g.DrawString($"{_Counter}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 10);
            g.DrawString($"{__SpaceShip.Energy}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 35);
            foreach (var game_object in _GameObjects)
                game_object?.Draw(g);
            __SpaceShip.Draw(g);
            //__Bullets.ForEach(bullet => bullet.Draw(g));
            _BulletsList.Draw(g);
            if (!__Timer.Enabled)
                return;
            __Buffer.Render();
        }

        public void Load()
        {
            _GameObjects = _LoadScens.LoadSceneObjects(_Rnd);
        }

        private void OnSheepDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            var g = __Buffer.Graphics;
            __ButtonNewGame.Visible = true;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            __Buffer.Render();
        }

        public void Update()
        {
            foreach (var game_object in _GameObjects)
            {
                game_object?.Update();
            }
            _BulletsList.Update();
            _CollisionCotroller.CollisionVisualObjects(_GameObjects, _Rnd);
            _BulletCollisionController.Collision(_GameObjects, _Rnd, _BulletsList);
        }
    }
}
