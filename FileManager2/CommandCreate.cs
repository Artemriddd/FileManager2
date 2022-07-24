using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandCreate
    {
        public void FileCreate(string targerPath)
        {
            File.Create(targerPath);
        }
        public void CreateDirectory(string targerPath)
        {
            Directory.CreateDirectory(targerPath);
        }
    }
}
