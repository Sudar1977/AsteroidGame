using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class Student : ILogger //1:51:16 //2:02:06
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int GroupId { get; set; }

        public void Log(string Message)
        {
            Console.WriteLine("Студент {0} пишет в журнал:{1}",Name,Message);
        }
    }
}
