using jadedleader3.Classes;
using jadedleader3.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jadedleader3.Services
{
    public class LoginService<T> where T : IAccount
    {
        private readonly IJsonFileHandler<T> _jsonFileHandler;
        

        public LoginService(IJsonFileHandler<T> jsonFileHandler)
        {
            _jsonFileHandler = jsonFileHandler;
            
        }

        private string filepath = Configuration.ConfigureUsers();

        public string LoggingInUser(string username, string password)
        {


            try
            {

                List<T> deserializedJsonFile = _jsonFileHandler.DeserializingJsonFile(filepath);

                T filtering = deserializedJsonFile.FirstOrDefault(u => u.Username == username);

                if (filtering != null)
                {
                    bool checkingPassword = filtering.Password == password;

                    if (checkingPassword != null)
                    {
                        return filtering.Access;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Something went wrong: {ex.Message}");
            }

            return $"Nothing could be found for this user";
        }


    }
}
