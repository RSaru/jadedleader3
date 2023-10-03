using jadedleader3.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace jadedleader3.Classes
{
    public class LecturerAccount : IAccount
    {
        private readonly IJsonFileHandler<LecturerAccount> _jsonFileHandler;
     

        public Guid Id { get; set; }

        public string Access { get; set; }

        public string Username { get; set; }    

        public string Password { get; set; }

        public string TimeCreated { get; set; }

        public LecturerAccount()
        {
            
        }

        public LecturerAccount(string username, string password, IJsonFileHandler<LecturerAccount> jsonFileHandler)
        {
            _jsonFileHandler = jsonFileHandler;
            

            Id = Guid.NewGuid();
            Access = "Lecturer";
            Username = username;
            Password = password;
            TimeCreated = DateTime.Now.ToShortDateString();

        }

        private string FilePath = Configuration.ConfigureUsers();

        public void CreateNewAccount(string username, string password)
        {
            try
            {

                bool verification = VerifyingUniqueName(username);

                if (!verification)
                {
                    List<LecturerAccount> userAccountList = new List<LecturerAccount>();

                    LecturerAccount account = new LecturerAccount(username, password, _jsonFileHandler);

                    userAccountList.Add(account);

                    _jsonFileHandler.AddingUserAccountToJsonFile(userAccountList, FilePath);

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when trying to create a new account: {ex.Message}");
            }

        }

        //method to make sure that there are no duplicate name entries within the file before creating the account and adding it to the json file
        //currently working, just need to setup in the view the message that gets displayed since currently if the name does exist it still says "done" yet it doesn't add it to the file

        private bool VerifyingUniqueName(string username)
        {
            List<LecturerAccount> deserializedUserAccountList = _jsonFileHandler.DeserializingJsonFile(FilePath);

            if (deserializedUserAccountList == null)
            {
                throw new Exception("there is nothing within the user account list");
            }

            foreach (var account in deserializedUserAccountList)
            {

                dynamic dynamicAccount = account;
                if (dynamicAccount.Username == username)
                {
                    return true;
                }
            }

            return false;


        }



    }
}
