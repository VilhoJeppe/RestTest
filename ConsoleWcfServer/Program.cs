using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryWcf;
using WcfService1;

namespace ConsoleWcfServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address

            //Uri httpUrl = new Uri("net.tcp://localhost:8001/HelloWorld");
            Uri httpUrl = new Uri("http://localhost:8010/MyService/HelloWorld");

            //Create ServiceHost
            ServiceHost host
                = new ServiceHost(typeof(Service1), httpUrl);

            //Add a service endpoint
            host.AddServiceEndpoint(typeof(IService1)
                , new WSHttpBinding(), "");

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);
            //Start the Service
            host.Open();

            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}
