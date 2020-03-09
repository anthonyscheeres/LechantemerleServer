namespace ChantemerleApi.Models
{

    public static class DataModel
    {
        private static ConfigModel config = new ConfigModel();


        public static void setConfigModel(ConfigModel config)
        {
            DataModel.config = config;
        }

        public static ConfigModel getConfigModel()
        {
            return config;
        }

    }
}
