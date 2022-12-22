using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract10
{
    public class InterfaceForUsers
    {
        public static string[] roles = new string[] { "Admin", "Manager", "Warehouse Manager", "Seller"};
        public static void AccountingPrint()
        {
            string path; string json; int len;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Accounting.json";
            List<Accounting> con = Converter.Des<List<Accounting>>(json);
            //Output of accounting
            int allSum = 0;
            for (int i = 2; i < con.Count + 2; i++)
            {
                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"Name {con[i - 2].name}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"Price {con[i - 2].sumPrice}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].adds}");

                if (con[i - 2].adds == 1)
                {
                    allSum += con[i - 2].sumPrice;
                }
                else if (con[i - 2].adds == 0)
                {
                    allSum -= con[i - 2].sumPrice;
                }
            }
            Console.WriteLine($"Revenue: {allSum}");
        }
        public static void PrintInterface(ModelOfWorker user)
        {
            //Interface for admin
            Console.SetCursorPosition(50, 0);
            Console.WriteLine($"Welcome, {user.name}!");
            Console.SetCursorPosition(85, 0);
            Console.WriteLine($"Role: {roles[user.atribute]}");
            Console.WriteLine("|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
            if (user.atribute == 1)
            {
                UsersForAdmin();
            }
            else if (user.atribute == 2)
            {
                UsersForManager();
            }
            else if (user.atribute == 3)
            {
                ProductsForWarehouseManager();
            }
            else if (user.atribute == 4)
            {
                ProductsForWarehouseManager();
            }
            for (int i = 2; i < 12; i++)
            {
                Console.SetCursorPosition(85, i);
                Console.WriteLine("||");
            }
            if (user.atribute != 4)
            {
                Console.SetCursorPosition(95, 2);
                Console.WriteLine("F1 - Add");
                Console.SetCursorPosition(95, 3);
                Console.WriteLine("F2 - Find");
                Console.SetCursorPosition(95, 4);
                Console.WriteLine("F3 - Delete");
                Console.SetCursorPosition(95, 5);
                Console.WriteLine("F4 - Read");
            }
        }

        public static void UsersForAdmin()
        {
            string path; string json; int len;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Tables.json";
            List<UserTable> con = Converter.Des<List<UserTable>>(json);
            //Output of user
            for (int i = 2; i < con.Count + 2; i++)
            {
                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"{con[i - 2].login}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"{con[i - 2].password}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].role}");
            }
        }
        public static void UsersForManager()
        {
            string path; string json; int len;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Data.json";
            List<ModelOfWorker> con = Converter.Des<List<ModelOfWorker>>(json);
            //Output of user
            for (int i = 2; i < con.Count + 2; i++)
            {
                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"{con[i - 2].name}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"{con[i - 2].password}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].atribute}");
            }
        }
        public static void ProductsForWarehouseManager()
        {
            string path; string json; int len;
            
            path = Directory.GetCurrentDirectory();
            len = path.Length - 17;
            json = path.Substring(0, len) + "\\Product.json";
            List<ALlProduct> con = Converter.Des<List<ALlProduct>>(json);
            //Output of product
            for (int i = 2; i < con.Count + 2; i++)
            {

                Console.SetCursorPosition(5, i);
                Console.WriteLine($"ID {con[i - 2].id}");
                Console.SetCursorPosition(15, i);
                Console.WriteLine($"{con[i - 2].name}");
                Console.SetCursorPosition(35, i);
                Console.WriteLine($"{con[i - 2].price}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{con[i - 2].count}");
            }
        }
    }
}
