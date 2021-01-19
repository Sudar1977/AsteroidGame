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
            Console.WriteLine(player1.Name);
            Console.ReadLine();
        }
    }
}
