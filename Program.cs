using Pract10;
using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.IO;

namespace Pract10
{
    public class Program
    {
        static void Main(string[] argrs)
        {
            string Path = Directory.GetCurrentDirectory();
            int length = Path.Length - 17;
            
            string json = Path.Substring(0, length) + "\\Data.json";
            List<ModelOfWorker> con = Converter.Des<List<ModelOfWorker>>(json);
            
            string jsonUs = Path.Substring(0, length) + "\\Tables.json";
            List<UserTable> converte = Converter.Des<List<UserTable>>(jsonUs);
 
            List<(string, string)> logins = new List<(string, string)>();
            
            for (int i = 0; i < con.Count; i++)
            {
                logins.Add((con[i].name, con[i].password));
            }

            int ind = Autorize.Autoriz(logins);
            ModelOfWorker workers = con[ind];
            
            if (workers.atribute == 1)
            {
                Console.Clear();
                Admin admin = new Admin(workers, converte);
                admin.Interface();
            } if (workers.atribute == 2)
            {
                Console.Clear();
                Manager manager = new Manager(workers, con);
            } if (workers.atribute == 3)
            {
                Console.Clear();
                string allPath = Directory.GetCurrentDirectory();
                int lenProd = Path.Length - 17;
                string jsonProd = Path.Substring(0, lenProd) + "\\Product.json";
                List<ALlProduct> products = Converter.Des<List<ALlProduct>>(jsonProd);
                UserWarehouseManager userWarehouseManager = new UserWarehouseManager(workers, products);
            } if (workers.atribute == 4)
            {
                Console.Clear();
                string allPathForSeller = Directory.GetCurrentDirectory();
                int lenProdSeller = Path.Length - 17;
                string jsonProdSeller = Path.Substring(0, lenProdSeller) + "\\Product.json";
                List<ALlProduct> productsSeller = Converter.Des<List<ALlProduct>>(jsonProdSeller);
                UserSeller userSeller = new UserSeller(workers, productsSeller);
            } if (workers.atribute == 5)
            {
                Console.Clear();
                string allPathForAccountant = Directory.GetCurrentDirectory();
                int lenAcc = Path.Length - 17;
                string jsonAcc = Path.Substring(0, lenAcc) + "\\Accounting.json";
                List<Accounting> accounting = Converter.Des<List<Accounting>>(jsonAcc);
                Accountant accountant = new Accountant(workers, accounting);
            }
        }
    }
}