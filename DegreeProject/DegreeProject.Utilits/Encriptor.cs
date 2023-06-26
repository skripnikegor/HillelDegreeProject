using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DegreeProject.Utilits
{
    public static class Encriptor
    {
        public static string GenerateRandomKey(int keySize)
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = keySize * 8;
                aes.GenerateKey();
                string key = Convert.ToBase64String(aes.Key);
                return key;
            }
        }

        public static byte[] EncryptNumber(int number, string key)
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] iv = new byte[16]; // Вектор инициализации - случайные данные

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                byte[] numberBytes = BitConverter.GetBytes(number);
                byte[] encryptedBytes = PerformCryptography(numberBytes, encryptor);

                return encryptedBytes;
            }
        }

        public static int DecryptNumber(byte[] encryptedBytes, string key)
        {
            byte[] keyBytes = Convert.FromBase64String(key);
            byte[] iv = new byte[16]; // Вектор инициализации - должен совпадать с вектором, использованным при шифровании

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                byte[] decryptedBytes = PerformCryptography(encryptedBytes, decryptor);
                int decryptedNumber = BitConverter.ToInt32(decryptedBytes, 0);

                return decryptedNumber;
            }
        }

        private static byte[] PerformCryptography(byte[] inputData, ICryptoTransform cryptoTransform)
        {
            byte[] outputBytes = cryptoTransform.TransformFinalBlock(inputData, 0, inputData.Length);
            return outputBytes;
        }
    }
}
