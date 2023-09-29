using jadedleader3.Classes;
using jadedleader3.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace jadedleader3.Services
{
    public class AuthenticationService<T> where T : IAccounts
    {
        private readonly IJsonFileHandler<T> _jsonFileHandler;

        public AuthenticationService(IJsonFileHandler<T> jsonFileHandler)
        {
            _jsonFileHandler = jsonFileHandler;
        }


        //filter via the username, filter via the access role and make sure that if the access role == admin, they get access to the button etc, else they dont
        public string Authenticate(string username, string password, string filePath)
        {

            try
            {

                List<T> accountList = _jsonFileHandler.DeserializingJsonFile(filePath);
                

                T account = accountList.FirstOrDefault(u => u.Username == username);
                

                if (account != null && account.Password == password)
                {

                    return account.Access;

                }

            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when trying to authenticate the account: {ex.Message}");

                
            }

            return "Invalid credentials";

            


        }
    }
}
