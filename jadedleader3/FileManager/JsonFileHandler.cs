using jadedleader3.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace jadedleader3.FileManager
{
    public class JsonFileHandler<T> : IJsonFileHandler<T>
    {
        //a method to add new users to the json file 
        public void AddingUserAccountToJsonFile(List<T> userAccount, string jsonFilePath)
        {
            try
            {

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                };

                List<T> existingUserAccounts = DeserializingJsonFile(jsonFilePath);

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
        public List<T> DeserializingJsonFile(string jsonFilePath)
        {
            try
            {
                string jsonFileContents = File.ReadAllText(jsonFilePath);

                List<T>? deserializedUserAccount = JsonSerializer.Deserialize<List<T>>(jsonFileContents);

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

        public List<Lectures> DeserializingJsonFileLecture(string jsonFilePath)
        {
            try
            {
                string jsonFileContents = File.ReadAllText(jsonFilePath);

                List<Lectures>? deserializedLectures = JsonSerializer.Deserialize<List<Lectures>>(jsonFileContents);

                if (deserializedLectures == null)
                {
                    throw new Exception($"File couldn't be deserialized, either the file has no contents or the file path is incorrect.");
                }

                return deserializedLectures;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while trying to deserialize the JSON file: {ex.Message}");
            }

        }

        public void DeleteFromJSON(string jsonFilePath, Lectures objectToBeDeleted)
        {

            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true,
            };

            List<Lectures> jsonDataToBeDeleted = DeserializingJsonFileLecture(jsonFilePath);
            jsonDataToBeDeleted = jsonDataToBeDeleted.Where(jsonObject => !CheckEqualObjects(jsonObject, objectToBeDeleted)).ToList();
            string updatedJsonData = JsonSerializer.Serialize(jsonDataToBeDeleted, options);
            File.WriteAllText(jsonFilePath, updatedJsonData);
        }

        public void EditLecture(Lectures objectToBeEdited,Lectures newInfo, string jsonFilePath)
        {
            List<Lectures> lecturesEdit = DeserializingJsonFileLecture(jsonFilePath);
            Lectures? lectureFind = lecturesEdit.FirstOrDefault(lecture => CheckEqualObjects(lecture, objectToBeEdited));
            if (lectureFind != null)
            {
                lectureFind.CourseName = newInfo.CourseName;
                lectureFind.ModuleCode = newInfo.ModuleCode;
                lectureFind.ModuleName = newInfo.ModuleName;
                lectureFind.LecturerName = newInfo.LecturerName;
                lectureFind.RoomNumber = newInfo.RoomNumber;
                lectureFind.DayOfTheWeek = newInfo.DayOfTheWeek;
                lectureFind.StartTime = newInfo.StartTime;
                lectureFind.EndTime = newInfo.EndTime;
                string newLectureEdit = JsonSerializer.Serialize(lecturesEdit, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                });
                File.WriteAllText(jsonFilePath, newLectureEdit);
            }
        }

        public void AddingLectureToJsonFile(List<Lectures> lectureAdd, string jsonFilePath)
        {
            try
            {

                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true,
                };

                List<Lectures> existingLectures = DeserializingJsonFileLecture(jsonFilePath);

                existingLectures.AddRange(lectureAdd);

                string serializingObjectToJson = JsonSerializer.Serialize(existingLectures, options);

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
        private static bool CheckEqualObjects(Lectures jsonObject, Lectures removedObject)
        {
            return jsonObject.ModuleCode == removedObject.ModuleCode && jsonObject.ModuleName == removedObject.ModuleName && jsonObject.CourseName == removedObject.CourseName && jsonObject.RoomNumber == removedObject.RoomNumber;
        }
    }
}
