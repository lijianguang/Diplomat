using Diplomat;
using Diplomat.Core;
using MultipleIntegration.SICA.Model;

namespace MultipleIntegration.SICA
{
    public class SICAWorkshop : Workshop<SICAModel>
    {
        public SICAWorkshop(IWorkerDispatcher workerDispatcher, IMessageConverter messageConvert)
            : base(workerDispatcher, messageConvert)
        {
        }

        public override Market[] IdentityMarket(SICAModel model)
        {
            return model.Market switch
            {
                "JP" => [Market.Japan],
                "ZA" => [Market.SouthAfrica],
                "ALL" => [Market.Japan, Market.SouthAfrica],
                _ => throw new Exception($"Can't find the market {model.Market}"),
            };
        }

        public override void Dispatch(SICAModel model, Market[] markets)
        {
            foreach (Market market in markets)
            {
                _workerDispatcher.Emit(model, Source.SICA, market);
            }
        }
    }
}
