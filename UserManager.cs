using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract10
{
    internal class Manager : User
    {
        ModelOfWorker manager = new ModelOfWorker();
        //Users
        List<ModelOfWorker> allUsers = new List<ModelOfWorker>();
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
        public Manager(ModelOfWorker worker, List<ModelOfWorker> allUsers)
        {
            manager = worker;
            this.allUsers = allUsers;
        }
        public void Inteface()
        {
            int pose = 2;
            int max = allUsers.Count() + 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(pose);
                Console.SetCursorPosition(0, pose);
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
                    Read(pose);
                }
                else if (key.Key == (ConsoleKey)Post.UpArrow)
                {
                    if (pose <= 2)
                    {
                        pose += max - 2;
                    }
                    else
                    {
                        pose--;
                    }
                }
                else if (key.Key == (ConsoleKey)Post.DownArrow)
                {
                    if (pose >= max)
                    {
                        pose -= max - 2;
                    }
                    else
                    {
                        pose++;
                    }
                }
            }
        }
        public void Read(int id)
        {
            List<int> ids = new List<int>();

            //Adding users to the list of ID
            foreach (ModelOfWorker i in allUsers)
            {
                ids.Add(i.id);
            }
            ModelOfWorker user = allUsers[ids.IndexOf((id))];

            Console.WriteLine("Info");
            Console.WriteLine(user.id);
            Console.WriteLine(user.name);
            Console.WriteLine(user.surname);
            Console.WriteLine(user.patronymic);

            Console.WriteLine();
            Console.WriteLine("Date of Birth");
            Console.WriteLine(user.start.date);
            Console.WriteLine(user.start.month);
            Console.WriteLine(user.start.year);
            Console.WriteLine();
            Console.WriteLine("Passport");
            Console.WriteLine(user.userPassrot.serial);
            Console.WriteLine(user.userPassrot.number);
            Console.WriteLine();
            Console.WriteLine("Others");
            Console.WriteLine(user.post);
            Console.WriteLine(user.salary);
            Console.WriteLine(user.privID);
            Console.WriteLine();

            Console.WriteLine("Press any button to exit");
            Console.ReadKey();
        }
        public void Create()
        {
            List<int> ids = new List<int>();

            //Adding users to the list of ID
            foreach (ModelOfWorker i in allUsers)
            {
                ids.Add(i.id);
            }

            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter last name");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter middle name");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            int birthDate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter month");
            int birthMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter year");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the passport series");
            int serial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter user password");
            string password = Console.ReadLine();

            Console.WriteLine("Enter user role");
            int atribute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter email");
            string post = Console.ReadLine();

            Console.WriteLine("Enter salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the user ID to whose account you want to link a worker");
            int privateID = Convert.ToInt32(Console.ReadLine());
            
            
            string path = Directory.GetCurrentDirectory();
            int len = path.Length - 17;
            string json = path.Substring(0, len) + "\\Tables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            List<int> idsUsers = new List<int>();

            //Adding users to the list of ID
            foreach (UserTable user in con)
            {
                idsUsers.Add(user.id);
            }

            if (idsUsers.Contains(privateID))
            {
                ModelOfWorker worker = new ModelOfWorker();
                
                worker.id = allUsers[allUsers.Count - 1].id + 1;
                worker.atribute = atribute;
                worker.password = password;
                worker.name = name;
                worker.surname = surname;
                worker.patronymic = patronymic;
                worker.start.date = birthDate;
                worker.start.month = birthMonth;
                worker.start.year = birthYear;
                worker.userPassrot.serial = serial;
                worker.userPassrot.number = number;
                worker.post = post;
                worker.salary = salary;
                worker.privID = privateID;

                allUsers.Add(worker);
                Console.WriteLine("Enter file name");
                string filename = Console.ReadLine();
                Converter.Ser<List<ModelOfWorker>>(allUsers, filename);
            }
            else
            {
                Console.WriteLine("This user does not exist, press any button to exit the menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Delete()
        {
            //Truncating a string to a file with users
            string path = Directory.GetCurrentDirectory();
            int len = path.Length - 17;
            string json = path.Substring(0, len) + "\\Data.json";
            List<ModelOfWorker> con = Converter.Des<List<ModelOfWorker>>(json);
            List<int> ids = new List<int>();

            //Adding users to the list of ID
            foreach (ModelOfWorker user in con)
            {
                ids.Add(user.id);
            }


            Console.WriteLine("Enter the id of the user you want to delete");
            int id = Convert.ToInt32(Console.ReadLine());

            //ID check 
            if (ids.Contains(id))
            {
                ModelOfWorker user = con[ids.IndexOf(id)];
                con.Remove(user);

                Console.WriteLine("Enter file name");
                string filename = Console.ReadLine();
                Converter.Ser<List<ModelOfWorker>>(con, filename);

            }
            else
            {
                Console.WriteLine("There is no such user, press any key to exit");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void Search()
        {
            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter surname");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter middle name");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            int birthDate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter month");
            int birthMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter year");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the passport series");
            int serial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter user password");
            string password = Console.ReadLine();

            Console.WriteLine("Enter user role");
            int atribute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter email");
            string post = Console.ReadLine();

            Console.WriteLine("Enter salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            ModelOfWorker worker = new ModelOfWorker();
            worker.atribute = atribute;
            worker.password = password;
            worker.id = id;
            worker.name = name;
            worker.surname = surname;
            worker.patronymic = patronymic;
            worker.start.date = birthDate;
            worker.start.month = birthMonth;
            worker.start.year = birthYear;
            worker.userPassrot.serial = serial;
            worker.userPassrot.number = number;
            worker.post = post;
            worker.salary = salary;

            if (allUsers.Contains(worker))
            {
                Console.Clear();
                Console.WriteLine(worker.id);
                Console.WriteLine(worker.atribute);
                Console.WriteLine(worker.password);
                Console.WriteLine(worker.name);
                Console.WriteLine(worker.surname);
                Console.WriteLine(worker.patronymic);
                Console.WriteLine(worker.start.date);
                Console.WriteLine(worker.start.month);
                Console.WriteLine(worker.start.year);
                Console.WriteLine(worker.userPassrot.serial);
                Console.WriteLine(worker.userPassrot.number);
                Console.WriteLine(worker.post);
                Console.WriteLine(worker.salary);
                Console.WriteLine();

                Console.WriteLine("Press any button to exit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("There is no such user, press any key to exit");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Update(int id)
        {
            List<int> ids = new List<int>();

            //Adding users to the list of ID
            foreach (ModelOfWorker i in allUsers)
            {
                ids.Add(i.id);
            }

            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter last name");
            string surname = Console.ReadLine();

            Console.WriteLine("Enter middle name");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            int birthDate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter month");
            int birthMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter year");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the passport series");
            int serial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter user password");
            string password = Console.ReadLine();

            Console.WriteLine("Enter user role");
            int atribute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your email");
            string post = Console.ReadLine();

            Console.WriteLine("Enter salary");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the user ID associated with the account");
            int privID = Convert.ToInt32(Console.ReadLine());


            string path = Directory.GetCurrentDirectory();
            int len = path.Length - 17;
            string json = path.Substring(0, len) + "\\Tables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            List<int> idsUsers = new List<int>();

            //Adding users to the list of ID
            foreach (UserTable user in con)
            {
                idsUsers.Add(user.id);
            }

            if (idsUsers.Contains(privID))
            {
                ModelOfWorker worker = allUsers[ids.IndexOf((id))];
                allUsers.Remove(worker);
                worker.atribute = atribute;
                worker.password = password;
                worker.name = name;
                worker.surname = surname;
                worker.patronymic = patronymic;
                worker.start.date = birthDate;
                worker.start.month = birthMonth;
                worker.start.year = birthYear;
                worker.userPassrot.serial = serial;
                worker.userPassrot.number = number;
                worker.post = post;
                worker.salary = salary;
                worker.privID = privID;
  
                allUsers.Add(worker);
                Console.WriteLine("Enter file name");
                string filename = Console.ReadLine();
                Converter.Ser<List<ModelOfWorker>>(allUsers, filename);
            }
            else
            {
                Console.WriteLine("There is no such user for the link, press any button to exit the menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
