using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PROGTask2.Classes
{
    public class PasswordEncryption
    {
        //Method created to generate a random salt
        //public byte[] CreateSalt()
        //{
            //byte[] salt = new byte[16];
            //using (var rng = new RNGCryptoServiceProvider())
            //{
                //rng.GetBytes(salt);

            //}
            //return salt;
        //}

        //-----------------------------------------------method created to hash the password--------------------------------------------------------------------------// 
        public string HashedPassword(string password)
        {
            SHA1CryptoServiceProvider sHaiHash = new SHA1CryptoServiceProvider();
            byte[] hashPassword_bytes = Encoding.UTF8.GetBytes(password);
            byte[] salt_bytes = sHaiHash.ComputeHash(hashPassword_bytes);
            return Convert.ToBase64String(salt_bytes);
            
        }
    }
}
//-------------------------------------------------------------End of File----------------------------------------------------------------------------------------------//