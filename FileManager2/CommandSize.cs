using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandSize
    {
        private long _size;
        public long FileSize(string source)
        {
            FileInfo info = new FileInfo(source);
            return info.Length;
        }
        public long DirSize(string source, bool lastDir)
        {
            var dir = new DirectoryInfo(source); // Создаем новую объект класса типа DirectoryInfo
            DirectoryInfo[] dirs = dir.GetDirectories(); // Добавляем в массив все поддиректории в исходной директории
            foreach (FileInfo file in dir.GetFiles())  
            {
                _size += file.Length;
            }
            if (lastDir) // Рекурсивно вызываем данный метод для всех поддиректорий
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    DirSize(subDir.FullName, true);
                }
            }
            return _size;
        }
    }
}
