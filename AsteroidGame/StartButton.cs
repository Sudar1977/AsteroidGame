using System.Windows.Forms;

namespace AsteroidGame
{
    internal class StartButton
    {
        public  Button _ButtonNewGame;
//        public Button Button => _ButtonNewGame;

        public StartButton()
        {
            _ButtonNewGame = new Button();
            _ButtonNewGame.Width = 200;
            _ButtonNewGame.Height = 30;
            _ButtonNewGame.Text = "New GAME!!!";
            _ButtonNewGame.Left = 20;
            _ButtonNewGame.Top = 30;
            //_ButtonNewGame.Click += OnTestButtonClicked;
            _ButtonNewGame.Visible = false;
            _ButtonNewGame.Enabled = false;

            //this.SetStyle(ControlStyles.Selectable, false);
        }
    }
}
