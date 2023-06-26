using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.Utilit
{
    public static class Criptor
    {
        private const int EncryptionKey = 967843; // Ключ шифрования

        public static int Encrypt(int number)
        {
            return number + EncryptionKey; // Простейший шифратор: прибавляем ключ шифрования к числу
        }

        public static int Decrypt(int encryptedNumber)
        {
            return encryptedNumber - EncryptionKey; // Простейший дешифратор: вычитаем ключ шифрования из зашифрованного числа
        }
    }
}
