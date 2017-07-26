using System;
using System.ServiceModel;
using System.Threading;
using WcfService1;

namespace ClassLibraryWcf
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        private int _callCount;

        private string _testValue;

        private TestClass _class;
        

        public string GetData(int value)
        {
            _callCount++;
            _testValue = value.ToString();
            _class = new TestClass {TestValue = _testValue};

            Console.WriteLine($"Testvalue is: {_class.TestValue }");

            Console.WriteLine("Instance:" + _callCount.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() + " Time:" + DateTime.Now.ToString());

            // Wait for 5 seconds
            //Thread.Sleep(5000);


            return string.Format("You entered: {0}. Callcount: {1}", value, _callCount);
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
