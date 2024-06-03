using Diplomat;

namespace MultipleIntegration.VSS.Model
{
    [ModelMapping(Source.VSS)]
    public class VSSModel : DiplomatModel
    {
        public required string Market { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}
