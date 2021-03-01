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

        private BufferedGraphicsContext _Context;
        private BufferedGraphics _Buffer;

        private VisualObject[] _GameObjects;
        private Timer _Timer;
        private Button _ButtonNewGame;

        private readonly Random _Rnd = new Random();
        private readonly LoadScens _LoadScens = new LoadScens();

        private SpaceShip _SpaceShip;
        private SpaceShipController _SpaceShipController;
        private SpaceShipCollisionController _SpaceShipCollisionController;

        private BulletsList _BulletsList;
        private BulletCollisionController _BulletCollisionController;
        

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
            _Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            _Buffer = _Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            _Timer = new Timer { Interval = __TimerInterval };
            _Timer.Tick += OnTimerTick;
            _Timer.Start();


            _BulletsList = new BulletsList();
            _BulletCollisionController = new BulletCollisionController(_BulletsList);
            _SpaceShip = new SpaceShip(new Point(20, 400), new Point(10, 10),SpaceShipTypes.X_Wing);
            _SpaceShipController = new SpaceShipController(_SpaceShip);
            _SpaceShipCollisionController = new SpaceShipCollisionController(_SpaceShip);
            _SpaceShip.Destoyed += OnSheepDestroyed;
            _SpaceShip.BulletShoot += _BulletsList.OnBulletShoot;

            form.KeyDown += _SpaceShipController.OnFormKeyDown;
            form.MouseMove += _SpaceShipController.MouseEvent;//https://www.youtube.com/watch?v=onMsYF9-HCg&list=PLqzmfPe9NPAkWg17LqEYCqXydTwShErLf
            form.MouseClick += _SpaceShipController.MouseClick;
            //form.KeyPress += OnFormKeyPress;

            _ButtonNewGame = new Button();
            _ButtonNewGame.Width = 200;
            _ButtonNewGame.Height = 30;
            _ButtonNewGame.Text = "New GAME!!!";
            _ButtonNewGame.Left = 20;
            _ButtonNewGame.Top = 30;
            _ButtonNewGame.Click += OnTestButtonClicked;
            _ButtonNewGame.Visible = false;
            form.Controls.Add(_ButtonNewGame);


            //test_button
        }

        private void OnTestButtonClicked(object Sender, EventArgs e)
        {
            //MessageBox.Show("Just do it!!!!");
            _ButtonNewGame.Visible = false;
            _SpaceShip.EnergyRestore();
            //Music.MissionImpossible();
            _Timer.Start();
        }

        private void OnTimerTick(object Sender, EventArgs e)
        {
            Update();
            this.Draw();
        }
        public void Draw()
        {
            Graphics g = _Buffer.Graphics;
            g.Clear(Color.Black);
            g.FillRectangle(_BackGroundTexture, new RectangleF(0, 0, _BackGroundTexture.Image.Width, _BackGroundTexture.Image.Height));
            g.DrawString($"{_Counter}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 10);
            g.DrawString($"{_SpaceShip.Energy}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 35);
            foreach (var game_object in _GameObjects)
                game_object?.Draw(g);
            _SpaceShip.Draw(g);
            //__Bullets.ForEach(bullet => bullet.Draw(g));
            _BulletsList.Draw(g);
            if (!_Timer.Enabled)
                return;
            _Buffer.Render();
        }

        public void Load()
        {
            _GameObjects = _LoadScens.LoadSceneObjects(_Rnd);
        }

        private void OnSheepDestroyed(object sender, EventArgs e)
        {
            _Timer.Stop();
            var g = _Buffer.Graphics;
            _ButtonNewGame.Visible = true;
            g.Clear(Color.DarkBlue);
            g.DrawString("Game over!!!", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 200, 100);
            _Buffer.Render();
        }

        public void Update()
        {
            foreach (var game_object in _GameObjects)
            {
                game_object?.Update();
            }
            _BulletsList.Update();
            _BulletCollisionController.Collision(_GameObjects, _Rnd);
            //_BulletCollisionController.Collision(_Rnd);
            _SpaceShipCollisionController.Collision(_GameObjects, _Rnd);
        }
    }
}
