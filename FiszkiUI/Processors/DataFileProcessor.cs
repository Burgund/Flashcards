using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardsUI.Processors
{
    //TODO temporary service
    public class DataFileProcessor
    {
        private string FILE_PATH = FileSystem.Current.AppDataDirectory + "\\FlashcardsUserData.txt";

        public void CreateDataFile()
        {
            try
            {
                if (!File.Exists(FILE_PATH))
                {
                    using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Create))
                    {
                        using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                        {
                            binaryWriter.Write("Flashcards" + Environment.NewLine);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void AddData(string dataToAdd)
        {
            CheckIfFileExistsAndCreateIfNot();

            if(string.IsNullOrWhiteSpace(dataToAdd))
                throw new Exception("DataFileProcessor.AddData: dataToAdd cant be null");

            using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Append))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(Environment.NewLine);
                    binaryWriter.Write(dataToAdd);
                }
            }
        }

        public void RemoveData() 
        {
            throw new NotImplementedException();
        }

        public string GetData()
        {
            string result = string.Empty;

            CheckIfFileExistsAndCreateIfNot();

            using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    result = binaryReader.ReadString();
                }
            }

            return result;
        }

        private void CheckIfFileExistsAndCreateIfNot()
        {
            if (!File.Exists(FILE_PATH))
            {
                CreateDataFile();
            }
        }
    }
}
