namespace ChantemerleApi.Models
{
    public class RestApiModel
    {
        public int portNumber { get;  }

        public string hostName { get; set; }

        public bool UseHttps { get; set; } //else use http

        public RestApiModel(int portNumber, string hostName, bool useHttps)
        {
            this.portNumber = portNumber;
            this.hostName = hostName;
            UseHttps = useHttps;
        }
    }
}
