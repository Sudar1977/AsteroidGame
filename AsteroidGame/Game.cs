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
    internal static class Game
    {
        /// <summary> Интервал времени таймера кадра игры    </summary>
        private const int __TimerInterval = 20;

        /// <summary> Task 4 Lesson 3 Добавить подсчет очков за сбитые астероиды./// </summary>
        private static int _Counter = 0;

        const int asteroid_count = 10;
        public const int asteroid_size = 50;
        public const int asteroid_max_speed = 20;

        const int enemy_count = 10;
        const int enemy_size = 50;
        const int enemy_max_speed = 20;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;
        //private static Bullet      __Bullet;
        private static List <Bullet> __Bullets = new List<Bullet>();
        private static SpaceShip __SpaceShip;

        private static  Random __Rnd;

        private static Timer  __Timer;
        private static Button __ButtonNewGame;

        private static IEnemyFactory __Factory = new AsteroidFactory();

        private static readonly TextureBrush _Texture1 = new TextureBrush(Properties.Resources.DeathStar);


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

            __Rnd = new Random();

            form.KeyDown += OnFormKeyDown;
            form.MouseMove += new MouseEventHandler(mouseEvent);
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

        private static void mouseEvent(object sender, MouseEventArgs e)
        {
            __SpaceShip.SetPostion(Cursor.Position.X,Cursor.Position.Y);
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
                      __Bullets.Add(new Bullet(__SpaceShip.Rect.X+__SpaceShip.Rect.Width, __SpaceShip.Rect.Y+__SpaceShip.Rect.Height/2));
                    //Console.Beep(300, 50);
                    break;

                case Keys.Up:
                case Keys.W:
                    __SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                case Keys.S:
                    __SpaceShip.MoveDown();
                    break;

                case Keys.Right:
                case Keys.D:
                    __SpaceShip.MoveForward();
                    break;

                case Keys.Left:
                case Keys.A:
                    __SpaceShip.MoveBack();
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
            g.FillRectangle(_Texture1, new RectangleF(0, 0, _Texture1.Image.Width, _Texture1.Image.Height));
            g.DrawString($"{_Counter}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 10);
            foreach (var game_object in __GameObjects)
                game_object?.Draw(g);

            __SpaceShip.Draw(g);
            __Bullets.ForEach(bullet => bullet.Draw(g));
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

            for(var i = 0; i < asteroid_count; i++)
            {
                game_objects.Add(__Factory.Create(__Rnd));
                    //new Asteroid(
                    //    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    //    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                    //    asteroid_size));
            }

            for (var i = 0; i < enemy_count; i++)
            {
                game_objects.Add(
                    new EnemySheep(
                        new Point(__Rnd.Next(0, Width), __Rnd.Next(0, Height)),
                        new Point(-__Rnd.Next(0, enemy_max_speed), 0),
                        enemy_size));
            }

            game_objects.Add(new Asteroid(new Point(Width / 2, 200), new Point(-asteroid_max_speed, 0), asteroid_size));
         
            __GameObjects = game_objects.ToArray();//1:23:23 

            __SpaceShip = new SpaceShip(
                new Point(20, 400),
                new Point(10, 10),
                50);

            __SpaceShip.Destoyed += OnSheepDestroyed;
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
            //__Bullet?.Update();
            __Bullets.ForEach(bullet => bullet.Update());

            foreach (var bullet_to_remove in __Bullets.Where(b => b.Rect.Left > Width).ToArray())
                __Bullets.Remove(bullet_to_remove);

            for(var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if(obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    __SpaceShip.CheckCollision(collision_object);
                    foreach (var bullet in __Bullets.ToArray())
                    {

                        if (bullet.CheckCollision(collision_object))
                        {
                            _Counter++;
                            __Bullets.Remove(bullet);
                            //bullet = null;
                            if (collision_object is Asteroid)
                                __GameObjects[i] = __Factory.Create(__Rnd);/* new Asteroid( 
                                                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                                                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                                                    asteroid_size);*/
                            if (collision_object is EnemySheep)
                                __GameObjects[i] = new EnemySheep(
                                                     new Point(__Rnd.Next(0, Width), __Rnd.Next(0, Height)),
                                                     new Point(-__Rnd.Next(0, enemy_max_speed), 0),
                                                     enemy_size);
                            Console.Beep(250, 100);
                        }
                    }
                }
            }
        }
    }
}
