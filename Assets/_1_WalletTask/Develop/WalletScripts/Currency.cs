using UnityEngine;

public class Currency
{
    private Currencies _name;
    private int _amount;

    public Currency(Currencies name, int amount)
    {
        _name = name;
        _amount = amount;
    }

    public Currencies Name => _name;

    public int Amount
    {
        get { return _amount; }

        set
        {
            if (value < 0)
            {
                Debug.LogWarning($"Amount of {Name} can't be negative");
                return;
            }

            _amount = value;
        }
    }

    public void Add(int amount) => Amount += amount;

    public void Subtract(int amount) => Amount -= amount;
}
