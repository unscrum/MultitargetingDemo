using System;
using System.ServiceModel;

namespace MultitargetingDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://localhost:54464/ServiceDemo.svc");
            using (var client = new System.ServiceModel.ChannelFactory<MultitargetingDemo.Service.Contract.IServiceDemo>(myBinding, myEndpoint))
            {
                try
                {
                    client.Open();
                    var channel = client.CreateChannel();
                    Console.WriteLine("Calling GetData with value of \"1\"");
                    var response1 = channel.GetData(1); ;
                    Console.WriteLine("Recieved: {0}", response1);

                    Console.WriteLine("Calling GetDataUsingDataContract with BoolValue of \"true\"");
                    var response2 = channel.GetDataUsingDataContract(new Service.Contract.CompositeTypeRequest { BoolValue = true});

                    Console.WriteLine("Recieved: {0}", response2.StringValue);


                    client.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                    client.Abort();
                }
            }
        }
    }
}
