using Diplomat.Core;
using MultipleIntegration.VSS.Model;

namespace MultipleIntegration.DiplomatProcess
{
    public class ValidateVSSModelProcess : Process<VSSModel>
    {
        protected override void Execute(VSSModel model, Action next)
        {
            if(model.Price <= 0)
            {
                Console.WriteLine("This process will be cut off, casue the price less than 0.");
                return;
            }
            next();
        }
    }
}
