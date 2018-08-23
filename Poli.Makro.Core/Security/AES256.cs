using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Poli.Makro.Core.Security
{
    public class Aes256
    {
        /// <summary>
        /// AES256 string encrypter
        /// </summary>
        /// <param name="plainText">text to be encryp</param>
        /// <param name="key">decryption key</param>
        /// <param name="iv">decryption iv</param>
        /// <returns></returns>
        public static string EncryptString(string plainText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set key and IV
            encryptor.Key = key.Take(32).ToArray();
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            // Convert the plainText string into a byte array
            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

            // Encrypt the input plaintext string
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            // Complete the encryption process
            cryptoStream.FlushFinalBlock();

            // Convert the encrypted data from a MemoryStream to a byte array
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both the MemoryStream and the CryptoStream
            memoryStream.Close();
            cryptoStream.Close();

            // Convert the encrypted byte array to a base64 encoded string
            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            // Return the encrypted data as a string
            return cipherText;
        }

        /// <summary>
        /// AES256 string decrypter
        /// </summary>
        /// <param name="cipherText">ciphertext to be decrypt</param>
        /// <param name="key">encryption key</param>
        /// <param name="iv">encryption iv</param>
        /// <returns></returns>
        public static string DecryptString(string cipherText, byte[] key, byte[] iv)
        {
            // Instantiate a new Aes object to perform string symmetric encryption
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;
            //encryptor.KeySize = 256;
            //encryptor.BlockSize = 128;
            //encryptor.Padding = PaddingMode.Zeros;

            // Set key and IV
            encryptor.Key = key.Take(32).ToArray();
            encryptor.IV = iv;

            // Instantiate a new MemoryStream object to contain the encrypted bytes
            MemoryStream memoryStream = new MemoryStream();

            // Instantiate a new encryptor from our Aes object
            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            // Instantiate a new CryptoStream object to process the data and write it to the 
            // memory stream
            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            // Will contain decrypted plaintext
            string plainText = String.Empty;

            try
            {
                // Convert the ciphertext string into a byte array
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Decrypt the input ciphertext string
                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                // Complete the decryption process
                cryptoStream.FlushFinalBlock();

                // Convert the decrypted data from a MemoryStream to a byte array
                byte[] plainBytes = memoryStream.ToArray();

                // Convert the decrypted byte array to string
                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                // Close both the MemoryStream and the CryptoStream
                memoryStream.Close();
                cryptoStream.Close();
            }

            // Return the decrypted data as a string
            return plainText;
        }

        /// <summary>
        /// Basic AES256 Engine
        /// </summary>
        /// <param name="plainText">plaintext for encryption/decryption</param>
        /// <param name="plainkey">plain text key</param>
        /// <param name="type">encrypt (0) / decrypt (1)</param>
        /// <returns></returns>
        public static string Aes256Engine(string plainText, string plainkey, int type = 0)
        {
            // hash the password with BCrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainkey, 12);

            // Convert hashed password to array
            byte[] key = Encoding.ASCII.GetBytes(hashedPassword);

            // Create secret IV
            byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
            string encrypted = EncryptString(plainText, key, iv);


            if (type == 1)
            {
                return DecryptString(plainText, key, iv);
            }

            return encrypted + "&p=" + System.Text.Encoding.UTF8.GetString(key);
        }

        /// <summary>
        /// Basic base64 converter
        /// </summary>
        /// <param name="content">sended content</param>
        /// <param name="type">encode(0)/decode(1) type</param>
        /// <returns></returns>
        public static string Base64Engine(string content, int type = 0)
        {
            string ret = string.Empty;

            // encode
            if (type == 0)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(content);
                ret = Convert.ToBase64String(plainTextBytes);
            }

            // decode
            if (type == 1)
            {
                var base64EncodedBytes = Convert.FromBase64String(content);
                ret = Encoding.UTF8.GetString(base64EncodedBytes);
            }

            return ret;
        }

    }
}
