using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager2
{
    class ParseCommand
    {
        public void ParseCommandString(string command) // Приняли на вход срочку из ввода командр
        {
            CommandTreeView commandTree = new(); // Инициализируем обьект класса для отрисовки каталога (Не знаю лучше тут объявить все обьекты классов, или нет,
                                                 // но идея в том, что вдруг какой то объект не будет использован и будет только занимать память,
                                                 // соответственно создаю объекты когда идет соответсвующая команда
            string[] commandParams = command.ToLower().Split(' '); // Разделели по пробелам
            if (commandParams.Length > 0)
            {
                switch (commandParams[0]) // Свичем пытаемся распознать команду
                {
                    case "cd":
                        if (commandParams.Length > 1 && commandParams[1] != "..") // Вызов каталога, если запрос не для вызова списка дисков
                        {
                            if (!Directory.Exists(commandParams[1])) // Если каталога нет
                            {
                                Console.Clear();
                                Console.SetCursorPosition(0, 3);
                                Console.WriteLine("Несуществующий каталог!");
                            }
                            if (Directory.Exists(commandParams[1])) // Если каталог есть, то вызываем объект класса по выводу каталога на экран
                            {
                                InputCommand._currentDir = commandParams[1];
                                Console.Clear();
                                Console.SetCursorPosition(0, 3);
                                commandTree.Execute(new DirectoryInfo(commandParams[1]));
                            }
                        }
                        if (commandParams.Length > 1 && commandParams[1] == "..") // Если запросим каталог .. то выведет каталог дисков
                        {
                            Console.Clear();
                            Console.SetCursorPosition(0, 3);
                            Console.WriteLine("Каталог логических дисков:");
                            string[] drivers = Environment.GetLogicalDrives();
                            foreach (string s in drivers)
                            {
                                Console.WriteLine(s);
                            }
                        }
                        break;

                    case "cp":

                        if (commandParams.Length > 2 && File.Exists(commandParams[1]))
                        {
                            CommandCopy commandCopy = new();
                            try
                            {
                                commandCopy.FileCopy(commandParams[1], commandParams[2]);
                                commandTree.Update(); // Обновляем экран после копирования, чтобы сразу видеть в каталоге, что копирование прошло успешно
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }

                        }
                        else if (commandParams.Length > 2 && Directory.Exists(commandParams[1]))
                        {
                            CommandCopy commandCopy = new();
                            try
                            {
                                commandCopy.CopyDirectory(commandParams[1], commandParams[2], true);
                                commandTree.Update();
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "crfile":
                        if (commandParams.Length > 1 && !File.Exists(commandParams[1]))
                        {
                            CommandCreate commandCreate = new();
                            try
                            {
                                commandCreate.FileCreate(commandParams[1]);
                                commandTree.Update(); // Обновляем экран после создания файла
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }

                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "crdir":
                        if (commandParams.Length > 1 && !Directory.Exists(commandParams[1]))
                        {
                            CommandCreate commandCreate = new();
                            try
                            {
                                commandCreate.CreateDirectory(commandParams[1]);
                                commandTree.Update();
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "movefile":
                        if (commandParams.Length > 2 && File.Exists(commandParams[1]) && !File.Exists(commandParams[2]))
                        {
                            CommandMove commandMove = new();
                            try
                            {
                                commandMove.MoveFile(commandParams[1], commandParams[2]);
                                commandTree.Update();
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "movedir":
                        if (commandParams.Length > 2 && Directory.Exists(commandParams[1]) && !Directory.Exists(commandParams[2]))
                        {
                            CommandMove commandMove = new();
                            try
                            {
                                commandMove.MoveDir(commandParams[1], commandParams[2]);
                                commandTree.Update();
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "rnfile":
                        if (commandParams.Length > 2 && File.Exists(commandParams[1]) && !File.Exists(commandParams[2]))
                        {
                            CommandMove commandMove = new();
                            try
                            {
                                commandMove.MoveFile(commandParams[1], commandParams[2]);
                                commandTree.Update();
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "rndir":
                        if (commandParams.Length > 2 && Directory.Exists(commandParams[1]) && !Directory.Exists(commandParams[2]))
                        {
                            CommandMove commandMove = new();
                            try
                            {
                                commandMove.MoveDir(commandParams[1], commandParams[2]);
                                commandTree.Update();
                            }
                            catch
                            {
                                commandTree.Update();
                                Console.WriteLine("\nОшибка");
                            }
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "rm":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            CommandDelete commandDelete = new();
                            commandDelete.FileDelete(commandParams[1]);
                            commandTree.Update();
                        }
                        else if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            CommandDelete commandDelete = new();
                            commandDelete.DeleteDirectory(commandParams[1], true);
                            commandTree.Update();
                        }
                        else
                        {
                            commandTree.Update();

                        }
                        break;

                    case "filesize":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            CommandSize size = new();
                            commandTree.Update();
                            Console.WriteLine("Размер файла: {0} байт", size.FileSize(commandParams[1]));
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "dirsize":
                        if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                        {
                            CommandSize size = new();
                            commandTree.Update();
                            Console.WriteLine("Размер директории: {0} байт", size.DirSize(commandParams[1], true));
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "isreadonly":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            CommandChangeAttributs attributs = new();
                            attributs.ReadOnly(commandParams[1]);
                            commandTree.Update();
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "isnonreadonly":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            CommandChangeAttributs attributs = new();
                            attributs.NonReadOnly(commandParams[1]);
                            commandTree.Update();
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "ishidden":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            CommandChangeAttributs attributs = new();
                            attributs.Hidden(commandParams[1]);
                            commandTree.Update();
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "isnonhidden":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]))
                        {
                            CommandChangeAttributs attributs = new();
                            attributs.NonHidden(commandParams[1]);
                            commandTree.Update();
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "search":
                        if (commandParams.Length > 2 && Directory.Exists(commandParams[1]))
                        {
                            CommandSearch commandSearch = new();
                            commandTree.Update();
                            Console.WriteLine("Найденные файлы:");
                            commandSearch.Search(commandParams[1], commandParams[2], true);

                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "textinfo":
                        if (commandParams.Length > 1 && File.Exists(commandParams[1]) && (Path.GetExtension(commandParams[1]) == "txt"))
                        {
                            CommandTextData commandTextData = new();
                            commandTree.Update();
                            Console.WriteLine("Количество строк: {0}", commandTextData.GetTextLines(commandParams[1]));
                            Console.WriteLine("Количество слов: {0}", commandTextData.GetTextWords(commandParams[1]));
                            Console.WriteLine("Количество символов: {0}", commandTextData.GetTextSymbol(commandParams[1]));
                            Console.WriteLine("Количество абзацев(beta): {0}", commandTextData.GetTextParagraph(commandParams[1]));
                        }
                        else
                        {
                            commandTree.Update();
                        }
                        break;

                    case "help":
                        CommandHelp.Help();
                        break;

                    default:
                        Console.Clear();
                        Console.SetCursorPosition(0, 3);
                        Console.WriteLine("Неизвестная команда. Для вызова справки наберите help");
                        break;
                }
            }
        }
    }
}
