using jadedleader3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jadedleader3.FileManager
{
    public interface IJsonFileHandler
    {

        void AddingUserAccountToJsonFile(List<UserAccount> userAccount, string jsonFilePath);

        List<UserAccount> DeserializingJsonFile(string jsonFilePath);   

    }
}
