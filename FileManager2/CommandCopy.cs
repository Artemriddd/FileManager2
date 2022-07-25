using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandCopy
    {
        public void FileCopy(string source, string targer)
        {
            File.Copy(source, targer);
        }
        public void CopyDirectory(string source, string target, bool lastDir)
        {
            var dir = new DirectoryInfo(source); // Создаем новую объект класса типа DirectoryInfo          
            DirectoryInfo[] dirs = dir.GetDirectories(); // Добавляем в массив все поддиректории в исходной директории
            Directory.CreateDirectory(target); // Создаем новую папку, куда идет копирование
            foreach (FileInfo file in dir.GetFiles())  // Копируем все файлы из исходной папки
            {
                string targetFilePath = Path.Combine(target, file.Name);
                file.CopyTo(targetFilePath);
            }
            if (lastDir) // Рекурсивно вызываем данный метод для всех поддиректорий
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(target, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
    }
}
