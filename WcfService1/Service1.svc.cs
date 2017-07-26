using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private int _callCount;
        public string GetData(int value)
        {
            _callCount++;
            Console.WriteLine("Instance:" + _callCount.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString() + "\n\n");

            // Wait for 5 seconds
            Thread.Sleep(5000);

            
            return string.Format("You entered: {0}. Callcount: {1}", value, _callCount);
        }

        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:49741/WcfService1/HelloWorld");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(Service1), httpUrl);

            //Add a service endpoint
            host.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), "");

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

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
