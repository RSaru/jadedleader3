using jadedleader3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jadedleader3.FileManager
{
    public interface IJsonFileHandler<T>
    {

        void AddingUserAccountToJsonFile(List<T> userAccount, string jsonFilePath);

        List<T> DeserializingJsonFile(string jsonFilePath);
        void DeleteFromJSON(string jsonFilePath, Lectures objectToBeDeleted);

        public void EditLecture(Lectures objectToBeEdited, Lectures newInfo, string jsonFilePath);

    }
}
