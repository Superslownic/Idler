using System;

namespace Idler.Currency
{
    public abstract class Currency<T> where T : struct
    {
        public T Value
        {
            get => _value;
            protected set
            {
                _value = value;
                onValueChanged?.Invoke(_value);
            }
        }
        public abstract void Add(T value);
        public abstract bool TryRemove(T value);
        public abstract void SetValue(T value);
        public event Action<T> onValueChanged;

        private T _value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
