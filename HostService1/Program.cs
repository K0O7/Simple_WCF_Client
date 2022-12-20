using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary1;

namespace HostService1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyData.info();
            Uri baseAddress1 = new Uri("http://localhost:1001/MyCarComp/");
            ServiceHost myHost1 = new ServiceHost(typeof(MyCarComp), baseAddress1);
            WSDualHttpBinding myBinding1 = new WSDualHttpBinding();
            ServiceEndpoint endpoint1 = myHost1.AddServiceEndpoint(typeof(ICarComp), myBinding1, "endpoin1");

            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myHost1.Description.Behaviors.Add(smb);


            try
            {
                myHost1.Open();
                Console.WriteLine("--> CarComp is running.");

                Console.WriteLine("--> press <ENTER> to stop.\n");
                Console.ReadLine();
                myHost1.Close();
                Console.WriteLine("--> CarComp finished.");
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine($"Exception occured: {ce.Message}");
                myHost1.Abort();
            }
        }
    }
}
