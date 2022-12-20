using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    internal class WarehouseManager : User
    {
        ModelOfWorker warehouseManager = new ModelOfWorker();
        //Товары на складе
        List<Product> allProducts = new List<Product>();

        public WarehouseManager(ModelOfWorker warehouseManager, List<Product> allProducts)
        {
            this.warehouseManager = warehouseManager;
            this.allProducts = allProducts;
        }

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

        public void Interface()
        {
            int pose = 2;
            int max = allProducts.Count() + 1;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(pose);
                Console.SetCursorPosition(0, pose);
                Console.WriteLine("->");

                InterfaceForUsers.PrintInterface(warehouseManager);

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
                else if (key.Key == (ConsoleKey)Post.Enter)
                {
                    Console.Clear();
                    Product product = allProducts[pose - 2];
                    Update(product.id);
                }


            }
        }
        public void Create()
        {
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Product.json";
            List<Product> con = Converter.Des<List<Product>>(json);

            Console.WriteLine("Введите название");
            string name = Console.ReadLine();
            Console.WriteLine("Введите цену");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество");
            int count = Convert.ToInt32(Console.ReadLine());

            int id = con[con.Count - 1].id + 1;

            Product prod = new Product();
            prod.id = id;
            prod.name = name;
            prod.price = price;
            prod.count = count;

            con.Add(prod);
            allProducts.Insert(id, prod);

            Console.WriteLine("Введите название файла");
            string filename = Console.ReadLine();
            Converter.Ser<List<Product>>(con, filename);
        }

        public void Delete()
        {
            //Усечение строки до файла с юзерами
            string startupPath = Directory.GetCurrentDirectory();
            int len = startupPath.Length - 17;
            string json = startupPath.Substring(0, len) + "\\Product.json";
            List<Product> con = Converter.Des<List<Product>>(json);
            List<int> ids = new List<int>();

            //Добавление в список айдишников юзеров
            foreach (Product user in con)
            {
                ids.Add(user.id);
            }


            Console.WriteLine("Введите id товара, который хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());

            //Проверка на существующий айдишник
            if (ids.Contains(id))
            {
                Product product = con[ids.IndexOf(id)];
                con.Remove(product);

                Console.WriteLine("Введите название файла");
                string filename = Console.ReadLine();
                Converter.Ser<List<Product>>(con, filename);

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
            foreach (Product i in allProducts)
            {
                ids.Add(i.id);
            }
            Product user = allProducts[ids.IndexOf((id))];
            Console.WriteLine(user.id);
            Console.WriteLine(user.name);
            Console.WriteLine(user.price);
            Console.WriteLine(user.count);
            Console.WriteLine();

            Console.WriteLine("Нажмите на любую кнопку что бы выйти");
            Console.ReadKey();
        }

        public void Search()
        {
            Console.WriteLine("Введите ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();
            Console.WriteLine("Введите цену товара");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество товара на складе");
            int count = Convert.ToInt32(Console.ReadLine());

            Product products = new Product();
            products.id = id;
            products.name = name;
            products.price = price;
            products.count = count;

            if (allProducts.Contains(products))
            {
                Console.Clear();
                Console.WriteLine(products.id);
                Console.WriteLine(products.name);
                Console.WriteLine(products.price);
                Console.WriteLine(products.count);
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
            foreach (Product i in allProducts)
            {
                ids.Add(i.id);
            }

            Console.WriteLine("Введите название товара");
            string name = Console.ReadLine();
            Console.WriteLine("Введите цену товара");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество товара на складе");
            int count = Convert.ToInt32(Console.ReadLine());

            Product product = allProducts[ids.IndexOf((id))];
            allProducts.Remove(product);
            product.name = name;
            product.price = price;
            product.count = count;


            allProducts.Insert(id, product);
            Console.WriteLine("Введите название файла");
            string filename = Console.ReadLine();
            Converter.Ser<List<Product>>(allProducts, filename);
        }
    }
}
