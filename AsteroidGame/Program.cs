using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread] 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form game_form = new Form();

            //const int game_form_width = 800;
            //const int game_form_height = 600;

            const int game_form_width = 1024;
            const int game_form_height = 768;

            //const int game_form_width = 1280;
            //const int game_form_height = 1024;

#if false
            game_form.Width = Screen.PrimaryScreen.WorkingArea.Width;
            game_form.Height = Screen.PrimaryScreen.WorkingArea.Height;
#else
            game_form.Width = game_form_width;
            game_form.Height = game_form_height;
#endif
            game_form.Show();
            Game.Initialize(game_form);
            Game.Load();
            Game.Draw();

            //System.Threading.Thread.Sleep(2000);
            Application.Run(game_form);
        }
    }
}
