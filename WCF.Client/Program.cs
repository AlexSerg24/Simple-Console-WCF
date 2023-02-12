using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCF.Client
{
    [ServiceContract]
    public interface ImessageService
    {
        [OperationContract]
        string[] GetMessages();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            string uri = "net.tcp://localhost:6565/MessageService";
            NetTcpBinding binding = new NetTcpBinding(SecurityMode.None);
            var chanel = new ChannelFactory<ImessageService>(binding);
            var endpoint = new EndpointAddress(uri);
            var proxy = chanel.CreateChannel(endpoint);
            var result = proxy?.GetMessages();
            if (result != null)
            {
                result.ToList().ForEach(p =>
                {
                    Console.WriteLine(p);
                });
                Console.ReadLine();
            }

        }
    }
}
