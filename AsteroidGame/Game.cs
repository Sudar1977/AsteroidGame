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

        public static EnemyShipTypes __EnemyShipType = EnemyShipTypes.Tie;

        public const int asteroid_size = 50;
        public const int asteroid_max_speed = 20;

        public const int enemy_size = 50;
        public const int enemy_max_speed = 20;

        private BufferedGraphicsContext _Context;
        private BufferedGraphics _Buffer;

        private VisualObject[] _GameObjects;
        private Timer _Timer;
        private Button _ButtonNewGame;

        public static readonly Random _Rnd = new Random();

        private IEnemyFactory _AsteroidFactory;// = new AsteroidFactory();
        private IEnemyFactory _EnemyShipFactory;// = new EnemySheepFactory();

        private LoadScens _LoadScens;// = new LoadScens();
        //private LoadScensController _LoadScensController;
        private SpaceShip _SpaceShip;
        private SpaceShipController _SpaceShipController;
        private SpaceShipCollisionController _SpaceShipCollisionController;

        private BulletsList _BulletsList;
        private BulletCollisionController _BulletCollisionController;
        

        private readonly TextureBrush _BackGroundTexture = new TextureBrush(Properties.Resources.DeathStar);
        private readonly TextureBrush _BackGroundTexturePause = new TextureBrush(Properties.Resources.StarWars);
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

            _AsteroidFactory = new AsteroidFactory();
            _EnemyShipFactory= new EnemySheepFactory();

            _BulletsList = new BulletsList();
            _BulletCollisionController = new BulletCollisionController(_BulletsList,_AsteroidFactory,_EnemyShipFactory);
            _SpaceShip = new SpaceShip(new Point(20, 400), new Point(10, 10),SpaceShipTypes.SnowSpeeder);
            _SpaceShipController = new SpaceShipController(_SpaceShip);
            _SpaceShipCollisionController = new SpaceShipCollisionController(_SpaceShip,_AsteroidFactory,_EnemyShipFactory);
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

            _LoadScens = new LoadScens(_AsteroidFactory,_EnemyShipFactory);
            //_LoadScensController = new LoadScensController(_LoadScens);
            form.KeyDown += OnFormKeyDown;

            //test_button
        }

        private void OnTestButtonClicked(object Sender, EventArgs e)
        {
            //MessageBox.Show("Just do it!!!!");
            _ButtonNewGame.Visible = false;
            _SpaceShip.EnergyRestore();
            __EnemyShipType = EnemyShipTypes.Tie;
            _SpaceShip.ChangeType(SpaceShipTypes.SnowSpeeder);
            _GameObjects = _LoadScens.LoadSceneObjects(_Rnd);
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
            g.DrawString("Сhange SpaceShip <T>, Change Enemy <E>", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 70);
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
            //g.Clear(Color.DarkBlue);
            g.Clear(Color.Black);
            g.FillRectangle(_BackGroundTexturePause, new RectangleF(0, 0, _BackGroundTexturePause.Image.Width, _BackGroundTexturePause.Image.Height));
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
        public void OnFormKeyDown(object Sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.E:
                case Keys.R:
                    switch (Game.__EnemyShipType)
                    {
                        case EnemyShipTypes.Tie:
                            Game.__EnemyShipType = EnemyShipTypes.Bomber;
                            break;
                        case EnemyShipTypes.Bomber:
                            Game.__EnemyShipType = EnemyShipTypes.BomberRot;
                            break;
                        case EnemyShipTypes.BomberRot:
                            Game.__EnemyShipType = EnemyShipTypes.StarDestroyerDown;
                            break;
                        case EnemyShipTypes.StarDestroyerDown:
                            Game.__EnemyShipType = EnemyShipTypes.StarDestroyerLeft;
                            break;
                        case EnemyShipTypes.StarDestroyerLeft:
                            Game.__EnemyShipType = EnemyShipTypes.StarDestroyerRebel;
                            break;
                        case EnemyShipTypes.StarDestroyerRebel:
                            Game.__EnemyShipType = EnemyShipTypes.Tie;
                            break;
                    }
                    break;
                case Keys.D0:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 0,_SpaceShip);
                    break;
                case Keys.D1:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 1, _SpaceShip);
                    break;
                case Keys.D2:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 2, _SpaceShip);
                    break;
                case Keys.D3:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 3, _SpaceShip);
                    break;
                case Keys.D4:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 4, _SpaceShip);
                    break;
                case Keys.D5:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 5, _SpaceShip);
                    break;
                case Keys.D6:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 6, _SpaceShip);
                    break;
                case Keys.D7:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 7, _SpaceShip);
                    break;
                case Keys.D8:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 8, _SpaceShip);
                    break;
                case Keys.D9:
                    _GameObjects = _LoadScens.LoadSceneObjects(Game._Rnd, 9, _SpaceShip);
                    break;
            }
        }

    }
}
