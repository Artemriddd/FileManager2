using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandDelete
    {
        public void FileDelete(string targer)
        {
            File.Delete(targer);
        }
        public void DeleteDirectory(string source, bool lastDir)
        {
            var dir = new DirectoryInfo(source); // Создаем новую объект класса типа DirectoryInfo          
            DirectoryInfo[] dirs = dir.GetDirectories(); // Добавляем в массив все поддиректории в исходной директории 
            foreach (FileInfo file in dir.GetFiles())  // Удаляем все файлы из исходной папки
            {
                file.Delete();
            }
            if (lastDir) // Рекурсивно вызываем данный метод для всех поддиректорий
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    DeleteDirectory(subDir.FullName, true);
                }
                Directory.Delete(source);
            }
        }
    }
}
