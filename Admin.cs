using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Magazine.Admin;

namespace Magazine
{
    internal class Admin : User
    {
        ModelOfWorker admin = new ModelOfWorker();
        //Юзеры системы
        List<UserTable> allUsers = new List<UserTable>();
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
        public Admin(ModelOfWorker worker, List<UserTable> allUsers)
        {
            admin = worker;
            this.allUsers = allUsers;
        }
        public void Interface()
        {
            int pose = 2;
            int max = allUsers.Count() + 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(pose);
                Console.SetCursorPosition(0, pose);
                Console.WriteLine("->");

                InterfaceForUsers.PrintInterface(admin);

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
                        pose -= max - 2 ;
                    }
                    else
                    {
                        pose++;
                    }

                }
                else if (key.Key == (ConsoleKey)Post.Enter)
                {
                    Console.Clear();
                    UserTable user = allUsers[pose - 2];
                    Update(user.id);
                }

             
            }
            



        }
        public void Create()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\UserTables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);

            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();
            Console.WriteLine("Введите роль польвателя");
            int role = Convert.ToInt32(Console.ReadLine());

            int id = con[con.Count - 1].id + 1;

            UserTable newUser = new UserTable();
            newUser.id = id;
            newUser.login = login;
            newUser.password = password;
            newUser.role = role;

            con.Add(newUser);

            Console.WriteLine("Введите название файла");
            string filename = Console.ReadLine();
            Converter.Ser<List<UserTable>>(con, filename);

        }

        public void Delete()
        {
            //Усечение строки до файла с юзерами
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\UserTables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (UserTable user in con)
            {
                ids.Add(user.id);
            }
            

            Console.WriteLine("Введите id пользователя, которого хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());

            //Проверка на существующий айдишник
            if (ids.Contains(id))
            {
                UserTable user = con[ids.IndexOf(id)];
                con.Remove(user);

                Console.WriteLine("Введите название файла");
                string filename = Console.ReadLine();
                Converter.Ser<List<UserTable>>(con, filename);

            }
            else
            {
                Console.WriteLine("Такого пользователя нету, нажмите любую клавишу, что бы выйти");
                Console.ReadKey();
                Console.Clear();
            }


        }

        public void Read(int id)
        {
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (UserTable i in allUsers)
            {
                ids.Add(i.id);
            }
            UserTable user = allUsers[ids.IndexOf((id))];
            Console.WriteLine(user.id);
            Console.WriteLine(user.login);
            Console.WriteLine(user.role);
            Console.WriteLine(user.password);
            Console.WriteLine();

            Console.WriteLine("Нажмите на любую кнопку что бы выйти");
            Console.ReadKey();
            

        }

        public void Search()
        {
            Console.WriteLine("Введите ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();
            Console.WriteLine("Введите роль польвателя");
            int role = Convert.ToInt32(Console.ReadLine());

            UserTable user = new UserTable();
            user.id = id;
            user.login = login;
            user.password = password;
            user.role = role;

            if (allUsers.Contains(user))
            {
                Console.Clear();
                Console.WriteLine(user.id);
                Console.WriteLine(user.login);
                Console.WriteLine(user.role);
                Console.WriteLine(user.password);
                Console.WriteLine();

                Console.WriteLine("Нажмите на любую кнопку что бы выйти");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Такого пользователя нету, нажмите любую клавишу, что бы выйти");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Update(int userUpdate)
        {

            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (UserTable i in allUsers)
            {
                ids.Add(i.id);
            }

            Console.WriteLine("Введите новый логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите новый пароль польвателя");
            string password = Console.ReadLine();
            Console.WriteLine("Введите новую роль польвателя");
            int role = Convert.ToInt32(Console.ReadLine());

            UserTable user = allUsers[ids.IndexOf((userUpdate))];
            allUsers.Remove(user);
            user.login = login;
            user.password = password;
            user.role = role;

            allUsers.Add(user);
            Console.WriteLine("Введите название файла");
            string filename = Console.ReadLine();
            Converter.Ser<List<UserTable>>(allUsers, filename);


        }
    }
}
