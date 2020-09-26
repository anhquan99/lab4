using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BAI4_CANHANH.ENCRYPT_DECRYPT
{
    class NV_ALGORITHM
    {
        
        private static readonly byte[] Salt = new byte[] { 10, 20, 30, 40, 50, 60, 70, 80 };
        private static byte[] key = CreateKey("N17DCAT055", 32);
        private static byte[] IV = CreateKey("D17CQAT", 16);
        private static byte[] CreateKey(string password, int keyBytes)
        {
            const int Iterations = 300;
            var keyGenerator = new Rfc2898DeriveBytes(password, Salt, Iterations);
            return keyGenerator.GetBytes(keyBytes);
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;
                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                             plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
        public void insert_NV(string maNV, string hoTen, string email, string luong, string tenDN, string matKhau)
        {
            using (QLSV_CANHANEntities db = new QLSV_CANHANEntities())
            {
                SHA1Managed sha1 = new SHA1Managed();
                sha1.ComputeHash(Encoding.UTF8.GetBytes(matKhau));
                byte[] hashMK = sha1.Hash;
                StringBuilder buildMK = new StringBuilder();
                for (int i = 0; i < hashMK.Length; i++)
                {
                    buildMK.Append(hashMK[i].ToString());
                }
                string finalMk = buildMK.ToString();
                byte[] encryptedLuong = EncryptStringToBytes_Aes(luong, key, IV);
                string finalLuong = Convert.ToBase64String(encryptedLuong);
                db.SP_INS_ENCRYPT_NHANVIEN(maNV, hoTen, email, finalLuong, tenDN, finalMk);
            }
        }
        public void getNV()
        {
            using (QLSV_CANHANEntities db = new QLSV_CANHANEntities())
            {
                var tempList = db.SP_SEL_ENCRYPT_NHANVIEN();
                foreach(var i in tempList)
                {
                    
                    string temp = DecryptStringFromBytes_Aes(Convert.FromBase64String(i.LUONG), key, IV);
                }
            }
        }
    }
}
