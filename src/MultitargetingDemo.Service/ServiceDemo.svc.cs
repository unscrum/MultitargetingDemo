using System;

namespace MultitargetingDemo.Service
{
    public class ServiceDemo : Contract.IServiceDemo
    {
        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        public Contract.CompositeTypeResponse GetDataUsingDataContract(Contract.CompositeTypeRequest composite)
        {
            if (composite == null)
                throw new ArgumentNullException("composite");
            

            return new Contract.CompositeTypeResponse
            {
                BoolValue = composite.BoolValue,
                StringValue = $"You entered: {composite.BoolValue}"
            };
        }
    }
}
