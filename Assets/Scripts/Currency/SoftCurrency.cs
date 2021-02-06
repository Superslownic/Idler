namespace Idler.Currency
{
    public class SoftCurrency : Currency<double>
    {
        public override void Add(double value)
        {
            Value += value;
        }

        public override bool TryRemove(double value)
        {
            if (value > Value) return false;

            Value -= value;
            return true;
        }

        public override void SetValue(double value)
        {
            Value = value;
        }
    }
}
