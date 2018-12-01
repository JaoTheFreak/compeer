using System.Security.Cryptography;
using System.Text;

namespace Compeer.Core.Services
{
    public class UtilService
    {        
        public string GenerateHashFromString(string stringToHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));  
  
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  

                return builder.ToString();                  
            }  
        }
    }
}