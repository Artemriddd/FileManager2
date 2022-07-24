using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class InputCommand
    {
        public static string _currentDir = Directory.GetCurrentDirectory();
        public void InCommand() // Метод для ввода команд в консоли, который после обращается в класса по "распознаванию команд",
                                // который в свою очередь при нахождении нужной команды, обращается в нужный класс с методом по выполнению команды....
        {
            bool work = true;
            while (work == true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(">");
                string command = Console.ReadLine(); // Вводим строку которая потот уйдут в парсер команд
                if(command == "quit")
                    {
                        break;
                    }
                ParseCommand parseCommand = new();
                parseCommand.ParseCommandString(command);
            }
        }
        
    }
}
