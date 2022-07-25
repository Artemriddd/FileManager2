using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    public class CommandHelp
    {
        public static void Help()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("Для выхода наберите quit");
            Console.WriteLine("Для вызова справки наберите help");
            Console.WriteLine("Для вызова каталога наберите cd path");
            Console.WriteLine("Для вызова каталога логических дисков наберите cd ..");
            Console.WriteLine("Для копирования файла/каталога наберите cp pathSourse pathTarget");
            Console.WriteLine("Для создания файла наберите crfile path");
            Console.WriteLine("Для создания каталога наберите crdir path");
            Console.WriteLine("Для перемещения файла наберите movefile pathSourse pathTarget");
            Console.WriteLine("Для перемещения каталога наберите movedir pathSourse pathTarget");
            Console.WriteLine("Для переименования файла наберите rnfile pathSourse pathTarget");
            Console.WriteLine("Для переименования каталога наберите rndir pathSourse pathTarget");
            Console.WriteLine("Для удаление файла/каталога наберите rm path");
            Console.WriteLine("Для вызова размера файла/каталога наберите filesize path/dirsize path");
            Console.WriteLine("Для изменения аттрибута \"только чтение\" наберите isreadonly path / isnonreadonly path");
            Console.WriteLine("Для изменения аттрибута \"скрытый\" наберите ishidden path / isnonhidden path");
            Console.WriteLine("Для поиска по маске наберите search path \"*.test\"");
            Console.WriteLine("Для вызова информации о текстовом файле наберите textinfo path");
        }
    }
}
