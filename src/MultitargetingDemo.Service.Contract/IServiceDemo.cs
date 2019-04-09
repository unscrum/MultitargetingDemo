using System.ServiceModel;

namespace MultitargetingDemo.Service.Contract
{
    [ServiceContract]
    public interface IServiceDemo
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeTypeResponse GetDataUsingDataContract(CompositeTypeRequest composite);


    }
}
