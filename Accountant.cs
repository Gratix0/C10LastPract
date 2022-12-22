using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract10
{
    internal class Accountant : User
    {
        ModelOfWorker manager = new ModelOfWorker();
        List<Accounting> allBuh = new List<Accounting>();
        internal enum Post
        {
            F1 = ConsoleKey.F1,
            F2 = ConsoleKey.F2,
            F3 = ConsoleKey.F3,
            F4 = ConsoleKey.F4,
            Enter = ConsoleKey.Enter,
            UpArrow = ConsoleKey.UpArrow,
            DownArrow = ConsoleKey.DownArrow,

        }
        public Accountant(ModelOfWorker worker, List<Accounting> allBuh)
        {
            manager = worker;
            this.allBuh = allBuh;
        }
        public void Interface()
        {
            int pos = 2;
            int max = allBuh.Count() + 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(pos);
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");

                InterfaceForUsers.PrintInterface(manager);

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == (ConsoleKey)Post.F1)
                {
                    Console.Clear();
                    Create();
                }
                else if (key.Key == (ConsoleKey)Post.F2)
                {
                    Console.Clear();
                    Search();
                }
                else if (key.Key == (ConsoleKey)Post.F3)
                {
                    Console.Clear();
                    Delete();
                }
                else if (key.Key == (ConsoleKey)Post.F4)
                {
                    Console.Clear();
                    Read(pos);
                }
                else if (key.Key == (ConsoleKey)Post.UpArrow)
                {
                    if (pos <= 2)
                    {
                        pos += max - 2;
                    }
                    else
                    {
                        pos--;
                    }
                }
                else if (key.Key == (ConsoleKey)Post.DownArrow)
                {
                    if (pos >= max)
                    {
                        pos -= max - 2;
                    }
                    else
                    {
                        pos++;
                    }
                }
            }
        }
        public void Create()
        {
            string path; int len; string json; string name; int sumPrice; int adds; int id; string filename;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            Console.WriteLine("Enter product name");
            name = Console.ReadLine();
            Console.WriteLine("Enter purchase amount");
            sumPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter subtract or add (1 or 0)");
            adds = Convert.ToInt32(Console.ReadLine());

            id = con[con.Count - 1].id + 1;

            Accounting newAcc = new Accounting();
            newAcc.id = id;
            newAcc.name = name;
            newAcc.sumPrice = sumPrice;
            newAcc.adds = adds;

            con.Add(newAcc);

            Console.WriteLine("Enter file name");
            filename = Console.ReadLine();
            Converter.Ser<List<Accounting>>(con, filename);
        }

        public void Delete()
        {
            string path; int len; string json; int id; string filename; 
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            id = Convert.ToInt32(Console.ReadLine());

            foreach (Accounting acc in con)
            {
                if (acc.id == id)
                {
                    con.Remove(acc);
                    Console.WriteLine("Enter the file");
                    filename = Console.ReadLine();
                    Converter.Ser<List<Accounting>>(con, filename);
                    break;
                }
            }
        }

        public void Read(int id)
        {
            string path; int len; string json;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            foreach (Accounting acc in con)
            {
                if (acc.id == id)
                {
                    Console.WriteLine(acc.id);
                    Console.WriteLine(acc.name);
                    Console.WriteLine(acc.sumPrice);
                    Console.WriteLine(acc.adds);
                    break;
                }
            }
        }

        public void Search()
        {
            string path; int len; string json;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            Accounting newAcc = new Accounting();
            Console.WriteLine("Enter product name");
            newAcc.name = Console.ReadLine();
            Console.WriteLine("Enter purchase amount");
            newAcc.sumPrice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter subtract or add (1 or 0)");
            newAcc.adds = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter post id");
            newAcc.id = Convert.ToInt32(Console.ReadLine());

            foreach (Accounting acc in con)
            {
                if (acc == newAcc)
                {
                    Console.Clear();
                    Console.WriteLine(acc.id);
                    Console.WriteLine(acc.name);
                    Console.WriteLine(acc.sumPrice);
                    Console.WriteLine(acc.adds);
                    break;
                }
            }
        } 

        public void Update(int id)
        {
            string path; int len; string json; string name; int sum; int adds; string filename;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);

            foreach (Accounting acc in con)
            {
                if (acc.id == id)
                {
                    Console.WriteLine("Введите название товара");
                    name = Console.ReadLine();
                    Console.WriteLine("Введите сумму покупки");
                    sum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Введите вычитать или прибавлять (1 или 0)");
                    adds = Convert.ToInt32(Console.ReadLine());

                    Accounting vrem = acc; 
                    con.Remove(acc);
                    vrem.name = name;
                    vrem.sumPrice = sum;
                    vrem.adds = adds;

                    Console.WriteLine("Введите название файла");
                    filename = Console.ReadLine();
                    Converter.Ser<List<Accounting>>(con, filename);
                    break;
                      
                }
            }
        }
    }
}
