using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Configuration.Library
{
    public static class EncryptProcess
    {
        public static string EncryptString(string data)
        {
            byte[] b = ASCIIEncoding.ASCII.GetBytes(data);
            string encrypted = Convert.ToBase64String(b);
            if (encrypted != null)
            {
                return encrypted;
            }
            return "Not Found";
        }
        public static string DecryptString(string data)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(data);
                decrypted = ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }
    }
}
