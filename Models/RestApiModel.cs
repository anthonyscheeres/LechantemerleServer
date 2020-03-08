namespace ChantemerleApi.Models
{
    public class RestApiModel
    {
        private int portNumber { get; set; }

        private string hostName { get; set; }

        public RestApiModel(string hostName, int portNumber)
        {
            this.portNumber = portNumber;
            this.hostName = hostName;
        }
    }
}
