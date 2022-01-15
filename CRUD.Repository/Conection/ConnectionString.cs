using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Repository.Conection
{
    public static class ConnectionString
    {
        private static string cName = "Server=.; Database=CRUD; Trusted_Connection=True;";
        public static string CName { get => cName; }
    }
}
