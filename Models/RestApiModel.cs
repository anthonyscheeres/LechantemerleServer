namespace ChantemerleApi.Models
{
    public class RestApiModel
    {
        public int portNumber { get;  }

        public string hostName { get; }

        public RestApiModel(string hostName, int portNumber)
        {
            this.portNumber = portNumber;
            this.hostName = hostName;
        }
    }
}
