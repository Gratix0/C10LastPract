using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract10
{
    public interface User
    {
        public void Create();
        public void Read(int id);
        public void Update(int id);
        public void Delete();
        public void Search();

    }
}
