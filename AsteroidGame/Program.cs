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
#if false
            game_form.Width = Screen.PrimaryScreen.WorkingArea.Width;
            game_form.Height = Screen.PrimaryScreen.WorkingArea.Height;
#else
            game_form.Width = 800;
            game_form.Height = 600;
#endif
            game_form.Show();
            Game.Initialize(game_form);
            Game.Draw();

            //System.Threading.Thread.Sleep(2000);
            Application.Run(game_form);
        }
    }
}
