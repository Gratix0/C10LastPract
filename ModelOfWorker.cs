using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazine
{
    public class ModelOfWorker
    {
        public int atribute;
        public string password;
        public int id;
        public string name;
        public string surname;
        public string patronymic;
        public DateOfStart start = new DateOfStart();
        public Passport passport = new Passport();
        public string post;
        public int salary;
        public int privID;
    }
}
