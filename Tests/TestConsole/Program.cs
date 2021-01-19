using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)//Ctrl+K,D
        {
            //Player player0 = null;
            //Player player1 = new Player();
            //player1.Name = "Иванов";
            //player1.Birthday = new DateTime(1977, 03, 23, 9, 0, 0);
            Console.Write("Введите фамилию >");
            var surname = Console.ReadLine();

            Player player1 = new Player(surname, new DateTime(1977, 03, 23, 9, 0, 0));

            Console.WriteLine(player1.GetName());
            Console.ReadLine();
        }
    }

    class Player
    {
        private string _Name;
        private DateTime _Birthday;
        public Player()
        {

        }
        public Player(string Name)
        {
            this._Name = Name;
            _Birthday = DateTime.Now;
        }
        public Player(string Name, DateTime Birthday) : this(Name)
        {
            //this.Name = Name;
            this._Birthday = Birthday;
        }

        public string GetName()
        {
            return _Name;
        }

        public void SetName(string Name)
        {
            _Name = Name;
        }

    }
}
