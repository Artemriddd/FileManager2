using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandTreeView
    {  
        public void Execute(DirectoryInfo dir)
        {
            Console.WriteLine("Каталог: {0}", dir);
            FileInfo[] subFiles = dir.GetFiles();
            foreach (var s in subFiles)
            {
                Console.WriteLine(s.Name);
            }
            DirectoryInfo[] subDirects = dir.GetDirectories();
            foreach (var s in subDirects)
            {
                Console.WriteLine(s.Name);
            }
        }
        public void Update() 
        {
            if (Directory.Exists(InputCommand._currentDir)) // Если каталог есть, то вызываем метод по выводу каталога на экран
            {
                Console.Clear();
                Console.SetCursorPosition(0, 3);
                Execute(new DirectoryInfo(InputCommand._currentDir));
            }
        }
        

}
}
