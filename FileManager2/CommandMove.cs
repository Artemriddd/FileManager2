using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandMove
    {
        public void MoveFile(string soursePath, string targerPath)
        {
            File.Move(soursePath, targerPath);
        }
        public void MoveDir(string sourse, string targer)
        {
            Directory.Move(sourse, targer);
        }
    }
}
