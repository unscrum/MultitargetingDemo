using System.Runtime.Serialization;

namespace MultitargetingDemo.Service.Contract
{


    [DataContract]
    public class CompositeTypeResponse
    {

        [DataMember]
        public bool BoolValue { get; set; }

        [DataMember]
        public string StringValue { get; set; }
    }
}
