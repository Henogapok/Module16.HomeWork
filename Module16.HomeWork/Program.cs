using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Module16.HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"";
            CreateOrWriteLogFile("");
            Console.WriteLine("Введите путь к дерриктории: ");
            string inputPath = Console.ReadLine();
            path += inputPath;
            
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                foreach (DirectoryInfo di2 in di.GetDirectories())
                {
                    Console.WriteLine($"\t{di2.Name}");
                }
                foreach (FileInfo fi in di.GetFiles())
                {
                    Console.WriteLine($"\t{fi.Name}");
                }
                
            }
            catch(Exception E)
            {
                CreateOrWriteLogFile(E.Message);
                Console.WriteLine("Ошибка записана в логи");
                return;
            }

            Console.WriteLine("Выберите создать директорию или файл?(1/2)");
            Creating();

            Console.WriteLine("Выберите какую директорию/файл хотите удалить(1/2)");
            Deleting();
        }

        public static void CreatingDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }
        public static void CreateFile(string path)
        {
            FileStream fstream = null;
            try
            {
                fstream = new FileStream(path, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fstream))
                {
                    sw.WriteLine("test");
                }
            }
            catch(Exception E)
            {
                CreateOrWriteLogFile(E.Message);
            }
            finally
            {
                fstream?.Close();
            }

        }
        public static void Creating()
        {
            try
            {
                char inputChar = Console.ReadLine()[0];
                switch (inputChar)
                {
                    case '1':
                        Console.WriteLine("Введите путь до новой директории: ");
                        string inp = @"";
                        inp += Console.ReadLine();
                        CreatingDirectory(inp);
                        CreateOrWriteLogFile($"Создана директория по пути {inp}");
                        break;
                    case '2':
                        Console.WriteLine(@"Введите путь до нового файла(path\file.txt): ");
                        string inp1 = @"";
                        inp1 += Console.ReadLine();
                        CreateFile(inp1);
                        CreateOrWriteLogFile($"Создана директория по пути {inp1}");
                        break;
                    default:
                        Console.WriteLine("Вы сделали неправильный ввод!");
                        break;
                }
            }
            catch (Exception E)
            {
                CreateOrWriteLogFile(E.Message);
            }
            
        }
        public static void DeleteDirectory(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                di.Delete();
            }
            catch(Exception E)
            {
                CreateOrWriteLogFile(E.Message);
            }
        }
        public static void DeleteFile(string path)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                fi.Delete();
            }
            catch (Exception E)
            {
                CreateOrWriteLogFile(E.Message);
            }
        }
        public static void Deleting()
        {
            try
            {
                char inputChar = Console.ReadLine()[0];
                switch (inputChar)
                {
                    case '1':
                        Console.WriteLine("Введите путь до директории, которую хотите удалить: ");
                        string inp = @"";
                        inp += Console.ReadLine();
                        DeleteDirectory(inp);
                        CreateOrWriteLogFile($"Директория удалена по пути {inp}");
                        break;
                    case '2':
                        Console.WriteLine(@"Введите путь до файла, который хотите удалить: ");
                        string inp1 = @"";
                        inp1 += Console.ReadLine();
                        DeleteFile(inp1);
                        CreateOrWriteLogFile($"Файл удален по пути {inp1}");
                        break;
                    default:
                        Console.WriteLine("Вы сделали неправильный ввод!");
                        break;
                }
            }
            catch (Exception E)
            {
                CreateOrWriteLogFile(E.Message);
            }
        }
        public static void CreateOrWriteLogFile(string str)
        {
            string path = @"C:\Users\Public\Documents\Output.txt";
            FileStream fstream = null;
            try
            {
                fstream = new FileStream(path, FileMode.OpenOrCreate);
                using (StreamWriter sw = new StreamWriter(fstream))
                {
                        sw.WriteLine(str, "\n");
                }

            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
            }
            finally
            {
                fstream?.Close();
            }
        }
    }
}
