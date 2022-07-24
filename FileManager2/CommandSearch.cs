using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandSearch
    {
        public void Search(string source, string pattern, bool lastDir)
        {
            var dir = new DirectoryInfo(source); // Создаем новую объект класса типа DirectoryInfo
            DirectoryInfo[] dirs = dir.GetDirectories(); // Добавляем в массив все поддиректории в исходной директории
            foreach (FileInfo file in dir.GetFiles(pattern))  
            {
                Console.WriteLine(file.Name);
            }
            if (lastDir) // Рекурсивно вызываем данный метод для всех поддиректорий
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    Search(subDir.FullName, pattern, true);
                }
            }
        }
    }
}
