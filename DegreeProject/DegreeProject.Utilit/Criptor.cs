using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.Utilit
{
    public static class Criptor
    {
        private const int EncryptionKey = 967843; 

        public static int Encrypt(int number)
        {
            return number + EncryptionKey;
        }

        public static int Decrypt(int encryptedNumber)
        {
            return encryptedNumber - EncryptionKey;
        }
    }
}
