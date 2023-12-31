﻿using jadedleader3.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        void EditLecture(Lectures objectToBeEdited, Lectures newInfo, string jsonFilePath);

        List<Lectures> DeserializingJsonFileLecture(string jsonFilePath);

        List<Lectures> DeserializingJsonFileLectureStudent(string jsonFilePath);

        void AddingLectureToJsonFile(List<Lectures> lectureAdd, string jsonFilePath);


    }
}
