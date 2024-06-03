using Diplomat;

namespace MultipleIntegration.SICA.Model
{
    [ModelMapping(Source.SICA)]
    public class SICAModel : DiplomatModel
    {
        public required string Market { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
    }
}
