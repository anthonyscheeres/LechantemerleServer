using ChantemerleApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;


namespace ChantemerleApi.Utilities
{
    public class DirectoryUtilitiescs
    {

        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ChantemerleServer/";
        string filename = "file.txt";

        public DirectoryUtilitiescs(string path, string filename)
        {

            this.path = path;
            this.filename = filename;
        }

        public DirectoryUtilitiescs(string filename)
        {
            this.filename = filename;
        }


        public void writeDataModelToJsonFileInDocumetsFolder()
        {

            string pathToFile = path + filename;
            Console.WriteLine(pathToFile);
            ConfigModel dataForDefaultConfigModel = DataModel.get();




            // If the directory doesn't exist, create it.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.WriteLine(pathToFile);

            string json = JsonConvert.SerializeObject(dataForDefaultConfigModel, Formatting.Indented);



            File.WriteAllText(pathToFile, json);

            ConfigModel configTemp = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(pathToFile));

            if (configTemp != null)
            {
                DataModel.set(configTemp);
            }
        }

    }





}

