using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class CommandChangeAttributs
    {
        public void ReadOnly(string source)
        {
            File.SetAttributes(source, File.GetAttributes(source) | FileAttributes.ReadOnly);
        }
        public void NonReadOnly(string source)
        {
            File.SetAttributes(source, File.GetAttributes(source) & ~FileAttributes.ReadOnly);
        }
        public void Hidden(string source)
        {
            File.SetAttributes(source, File.GetAttributes(source) | FileAttributes.Hidden);
        }
        public void NonHidden(string source)
        {
            File.SetAttributes(source, File.GetAttributes(source) & ~FileAttributes.Hidden);
        }
    }
}
