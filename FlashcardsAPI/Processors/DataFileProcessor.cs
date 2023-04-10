using FlashcardsCommon.Models;
using FlashcardsCommon.ViewModels;
using Newtonsoft.Json;
using System;

namespace FlashcardsAPI.Processors
{
    //TODO temporary service
    public class DataFileProcessor
    {
        private string FILE_PATH = FileSystem.Current.AppDataDirectory + "\\FlashcardsUserData.txt";

        public void AddOrUpdateDataFile(string newDataFile)
        {
            if(string.IsNullOrWhiteSpace(newDataFile))
                throw new Exception("DataFileProcessor.AddData: dataToAdd cant be null");

            using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(newDataFile);
                }
            }
        }

        public void AddFlashcard(Flashcard flashcard)
        {
            var dataFile = GetData();
            dataFile.Flashcards.Add(flashcard);
            var updatedDataFileString = JsonConvert.SerializeObject(dataFile);
            AddOrUpdateDataFile(updatedDataFileString);
        }

        public void RemoveFlashcard(Flashcard flashcard)
        {
            var dataFile = GetData();
            dataFile.Flashcards.Remove(flashcard);
            var updatedDataFileString = JsonConvert.SerializeObject(dataFile);
            AddOrUpdateDataFile(updatedDataFileString);
        }

        public AppDataViewModel GetData()
        {
            string result = string.Empty;
            using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    result = binaryReader.ReadString();
                }
            }

            var existingAppData = JsonConvert.DeserializeObject<AppDataViewModel>(result);
            return existingAppData;
        }

        public bool FileExists()
        {
            return File.Exists(FILE_PATH);
        }
    }
}
