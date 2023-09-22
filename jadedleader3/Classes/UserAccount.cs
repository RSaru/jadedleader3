using jadedleader3.FileManager;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jadedleader3.Classes
{
    public class UserAccount
    {
        private readonly IJsonFileHandler _jsonFileHandler;

        public Guid Id { get;  set; }    

        public string Username { get; set; }   

        public string Password { get; set; }   

        public string TimeCreated { get; set; }

        private string JsonFileLocation = "C:\\Users\\joshy\\source\\repos\\jadedleader3\\jadedleader3\\JsonFiles\\UserAccounts.json";

        public UserAccount()
        {
            
        }
        public UserAccount(string username, string password, IJsonFileHandler jsonFileHandler)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            TimeCreated = DateTime.Now.ToShortDateString();

            _jsonFileHandler = jsonFileHandler;
        }

        //method to create a new user account and add it to the json file once it's created
        public void CreateNewAccount(string username, string password)
        {
             try
             {

                 bool verification = VerifyingUniqueName(username);

                 if (!verification)
                 {
                     List<UserAccount> userAccountList = new List<UserAccount>();

                    UserAccount user = new UserAccount(username, password, _jsonFileHandler);

                    userAccountList.Add(user);  

                    _jsonFileHandler.AddingUserAccountToJsonFile(userAccountList, JsonFileLocation);

                 }
             }
             catch(Exception ex)  
             {
                 throw new Exception($"Something went wrong when trying to create a new account: {ex.Message}");
             } 

        }

        //method to make sure that there are no duplicate name entries within the file before creating the account and adding it to the json file
        //currently working, just need to setup in the view the message that gets displayed since currently if the name does exist it still says "done" yet it doesn't add it to the file

        private bool VerifyingUniqueName(string username)
        {
            List<UserAccount> deserializedUserAccountList = _jsonFileHandler.DeserializingJsonFile(JsonFileLocation);

            if(deserializedUserAccountList == null)
            {
                throw new Exception("there is nothing within the user account list");
            }

            foreach(var u in deserializedUserAccountList)
            {
                if(u.Username == username)
                {
                    return true;
                }
            }

            return false;

            
        }
        
        




    }
}
