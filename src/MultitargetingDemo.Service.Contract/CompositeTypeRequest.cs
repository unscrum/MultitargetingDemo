using System.Runtime.Serialization;

namespace MultitargetingDemo.Service.Contract
{
    [DataContract]
    public class CompositeTypeRequest
    {

        [DataMember]
        public bool BoolValue { get;set; }

    }
}
