using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FileManager2
{
    class CommandTextData
    {
        public int GetTextLines(string source) // Количество строк
        {
            string[] fileText = File.ReadAllLines(source);
            return fileText.Length;
        }
        public int GetTextWords(string source) // Количество слов
        {
            string fileText = File.ReadAllText(source);
            string[] words = fileText.Split(' ');
            return words.Length;
        }
        public int GetTextSymbol(string source) // Количество символов
        {
            string fileText = File.ReadAllText(source);
            char[] words = fileText.ToCharArray();
            return words.Length;
        }
        public int GetTextParagraph(string source) // Количество параграфов. Я ее нагуглил и помоему она вообще не работает, и тупо возвращает строки,
                                                   // ибо разницы строки и абзаца для txt-файла я не нашел
        {
            string fileText = File.ReadAllText(source);
            fileText = Regex.Replace(fileText, "(\n|\r\n)+", "\n");
            return fileText.Split('\n').Length;
        }
    }
}
