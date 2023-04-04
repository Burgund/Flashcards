using System;

namespace FlashcardsUI.Processors
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

        public string GetData()
        {
            string result = string.Empty;

            using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    result = binaryReader.ReadString();
                }
            }

            return result;
        }

        public bool FileExists()
        {
            return File.Exists(FILE_PATH);
        }
    }
}
