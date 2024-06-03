using Diplomat;
using Diplomat.Core;
using MultipleIntegration.VSS.Model;

namespace MultipleIntegration.VSS
{
    public class VSSWorkshop : Workshop<VSSModel>
    {
        public VSSWorkshop(IWorkerDispatcher workerDispatcher, IMessageConverter messageConvert)
            : base(workerDispatcher, messageConvert)
        {
        }

        public override Market[] IdentityMarket(VSSModel model)
        {
            return model.Market switch
            {
                "Japan" => [Market.Japan],
                "SouthAfrica" => [Market.SouthAfrica],
                "ALL" => [Market.Japan, Market.SouthAfrica],
                _ => throw new Exception($"Can't find the market {model.Market}"),
            };
        }

        public override void Dispatch(VSSModel model, Market[] markets)
        {
            foreach (var market in markets)
            {
                _workerDispatcher.Emit(model, Source.VSS, market);
            }
        }
    }
}
