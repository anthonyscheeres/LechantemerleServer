using ChantemerleApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;


namespace ChantemerleApi.Utilities
{
    public class DirectoryUtilitiescs
    {

         string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ChantemerleServer/";
        string filename = "config.json";

        public DirectoryUtilitiescs(string path, string filename)
        {

            this.path = path;
            this.filename = filename;
        }

        public DirectoryUtilitiescs(string filename)
        {
            this.filename = filename;
        }

        public DirectoryUtilitiescs()
        {
        }

        public ConfigModel writeDataModelToJsonFileInDocumetsFolder()
        {

            string pathToFile = path + filename;
            Console.WriteLine(pathToFile);
            ConfigModel dataForDefaultConfigModel = new ConfigModel(new DatabaseModel("Host=*******;Username=****;Password=****; Database=****"), 
                new MailModel("****@gmail.com", "****"), new RestApiModel(44314, "localhost", true) //this is needed do the token system can call itself
);




            // If the directory doesn't exist, create it.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);


                string json = JsonConvert.SerializeObject(dataForDefaultConfigModel, Formatting.Indented);



                File.WriteAllText(pathToFile, json);

            }


            ConfigModel configTemp = JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(pathToFile));
            DataModel.config = configTemp;
            Console.WriteLine(configTemp.databaseCredentials.cs);

            return configTemp;


        }

    }





}

