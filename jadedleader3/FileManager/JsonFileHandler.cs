using jadedleader3.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace jadedleader3.FileManager
{
    public class JsonFileHandler : IJsonFileHandler
    {
        //a method to add new users to the json file 
        public void AddingUserAccountToJsonFile(List<UserAccount> userAccount, string jsonFilePath)
        {
            try
            {

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                };

                List<UserAccount> existingUserAccounts = DeserializingJsonFile(jsonFilePath);

                // Add the new user accounts to the existing list
                existingUserAccounts.AddRange(userAccount);

                // Serialize the entire updated list of user accounts to JSON
                string serializingObjectToJson = JsonSerializer.Serialize(existingUserAccounts, options);

                if (serializingObjectToJson != null)
                {
                    File.WriteAllText(jsonFilePath, serializingObjectToJson);
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Either an invalid user account was given, or the filepath was incorrect: {ex.Message}");
            }

            
        }

        // a method to deserialize the current json file dependant on the path and return it as a list
        public List<UserAccount> DeserializingJsonFile(string jsonFilePath)
        {
            try
            {
                string jsonFileContents = File.ReadAllText(jsonFilePath);

                List<UserAccount> deserializedUserAccount = JsonSerializer.Deserialize<List<UserAccount>>(jsonFileContents);

                if (deserializedUserAccount == null)
                {
                    throw new Exception($"File couldn't be deserialized, either the file has no contents or the file path is incorrect.");
                }

                return deserializedUserAccount;
            } 
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to deserialize the JSON file: {ex.Message}");
            }
            
        }
    }
}
