namespace PizzaMania.Core.Customizations.Crust
{
    public class ChoiceOfCrust
    {
        public Crust Value { get; }

        public ChoiceOfCrust(Crust crust = Crust.Default)
        {
            Value = crust;
        }

        public float GetPrice()
        {
            return CrustPrices.GetPriceFor(Value);
        }
    }
}
