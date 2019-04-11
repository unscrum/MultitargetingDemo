using System;
using System.Configuration;
using System.Linq;
using MultitargetingDemo.Data;

namespace MultitargetingDemo.Service
{
    public class ServiceDemo : Contract.IServiceDemo
    {
        public string GetData(int value)
        {
            using (var ctx =
                DemoDbContext.BySqlServerConnectionString(ConfigurationManager.ConnectionStrings["DemoDb"]
                    .ConnectionString))
            {
                var note = ctx.Notes.FirstOrDefault();
                return $"You entered: {value} and note is {note?.Text}";
            }
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
