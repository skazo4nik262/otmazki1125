using System.Security;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<string>excuses = new List<string>();
        static void Main(string[] args)
        {
            Load();
            while (true)
            {
                Console.WriteLine("Введите команду:");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "exit":
                        Save();
                        return;
                    case "create":
                        Add();
                        break;
                    case "list":
                        List();
                        break;
                    case "help":
                        Help();
                        break;
                    default:
                        Console.WriteLine("нет такой команды");
                        break;
                }
            }

        }
        static void Load()
        {
            string[] lines = File.ReadAllLines("excuses.txt");
            excuses.AddRange(lines);
        }
        static void Save()
        {
            File.WriteAllLines("excuses.txt", excuses);
        }
        static void Add()
        {
            Console.WriteLine("Введите отмазку:");
            string excuse = Console.ReadLine();
            excuses.Add(excuse);
        }
        static void List()
        {
            foreach (string excuse in excuses)
            {
                Console.WriteLine(excuse);
            }
        }
        static void Help()
        {
            if (excuses.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(excuses.Count);
                string excuse = excuses[index];
                Console.WriteLine("Отмазка:" + excuse);
            }
            else
            {
                Console.WriteLine("не придумал");
            }
            
        }
    }
}