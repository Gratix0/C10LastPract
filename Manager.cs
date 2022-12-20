using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    internal class Manager : User
    {
        ModelOfWorker manager = new ModelOfWorker();
        //Юзеры системы
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
        public void Create()
        {
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (ModelOfWorker i in allUsers)
            {
                ids.Add(i.id);
            }

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите отчество");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            int birthDate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите месяц");
            int birthMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите год");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите серию паспорта");
            int serial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();

            Console.WriteLine("Введите роль польвателя");
            int atribute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите почту");
            string post = Console.ReadLine();

            Console.WriteLine("Введите зарплату");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите айди пользователя к аккаунту которого хотите привязать рабочего");
            int privID = Convert.ToInt32(Console.ReadLine());


            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\UserTables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            List<int> idsUsers = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (UserTable user in con)
            {
                idsUsers.Add(user.id);
            }

            if (idsUsers.Contains(privID))
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
                worker.passport.serial = serial;
                worker.passport.number = number;
                worker.post = post;
                worker.salary = salary;
                worker.privID = privID;

                allUsers.Add(worker);
                Console.WriteLine("Введите название файла");
                string filename = Console.ReadLine();
                Converter.Ser<List<ModelOfWorker>>(allUsers, filename);
            }
            else
            {
                Console.WriteLine("Такого юзера для привзки не существует, нажмите любую кнопку для выхода в меню");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Delete()
        {
            //Усечение строки до файла с юзерами
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\usersData.json";
            List<ModelOfWorker> con = Converter.Des<List<ModelOfWorker>>(json);
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (ModelOfWorker user in con)
            {
                ids.Add(user.id);
            }


            Console.WriteLine("Введите id пользователя, которого хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());

            //Проверка на существующий айдишник
            if (ids.Contains(id))
            {
                ModelOfWorker user = con[ids.IndexOf(id)];
                con.Remove(user);

                Console.WriteLine("Введите название файла");
                string filename = Console.ReadLine();
                Converter.Ser<List<ModelOfWorker>>(con, filename);

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
            foreach (ModelOfWorker i in allUsers)
            {
                ids.Add(i.id);
            }
            ModelOfWorker user = allUsers[ids.IndexOf((id))];

            Console.WriteLine("Базовая инфа");
            Console.WriteLine(user.id);
            Console.WriteLine(user.name);
            Console.WriteLine(user.surname);
            Console.WriteLine(user.patronymic);

            Console.WriteLine();
            Console.WriteLine("Дата рождения");
            Console.WriteLine(user.start.date);
            Console.WriteLine(user.start.month);
            Console.WriteLine(user.start.year);
            Console.WriteLine();
            Console.WriteLine("Паспорт");
            Console.WriteLine(user.passport.serial);
            Console.WriteLine(user.passport.number);
            Console.WriteLine();
            Console.WriteLine("Остальное");
            Console.WriteLine(user.post);
            Console.WriteLine(user.salary);
            Console.WriteLine(user.privID);
            Console.WriteLine();

            Console.WriteLine("Нажмите на любую кнопку что бы выйти");
            Console.ReadKey();
        }

        public void Search()
        {
            Console.WriteLine("Введите ID");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите отчество");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            int birthDate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите месяц");
            int birthMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите год");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите серию паспорта");
            int serial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();

            Console.WriteLine("Введите роль польвателя");
            int atribute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите почту");
            string post = Console.ReadLine();

            Console.WriteLine("Введите зарплату");
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
            worker.passport.serial = serial;
            worker.passport.number = number;
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
                Console.WriteLine(worker.passport.serial);
                Console.WriteLine(worker.passport.number);
                Console.WriteLine(worker.post);
                Console.WriteLine(worker.salary);
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

        public void Update(int id)
        {
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (ModelOfWorker i in allUsers)
            {
                ids.Add(i.id);
            }

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите отчество");
            string patronymic = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            int birthDate = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите месяц");
            int birthMonth = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите год");
            int birthYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите серию паспорта");
            int serial = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите номер");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите пароль польвателя");
            string password = Console.ReadLine();

            Console.WriteLine("Введите роль польвателя");
            int atribute = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите почту");
            string post = Console.ReadLine();

            Console.WriteLine("Введите зарплату");
            int salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите айди пользователя привязанного к аккаунту");
            int privID = Convert.ToInt32(Console.ReadLine());


            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\UserTables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            List<int> idsUsers = new List<int>();

            //Добавление в список айдишников юзеров
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
                worker.passport.serial = serial;
                worker.passport.number = number;
                worker.post = post;
                worker.salary = salary;
                worker.privID = privID;

                allUsers.Add(worker);
                Console.WriteLine("Введите название файла");
                string filename = Console.ReadLine();
                Converter.Ser<List<ModelOfWorker>>(allUsers, filename);
            }
            else
            {
                Console.WriteLine("Такого юзера для привзки не существует, нажмите любую кнопку для выхода в меню");
                Console.ReadKey();
                Console.Clear();
            }


            
        }
    }
}
