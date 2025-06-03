using UnityEngine;

public class Currency
{
    private int _amount;

    public Currency(int amount)
    {
        _amount = amount;
    }

    public int Amount
    {
        get { return _amount; }

        set
        {
            if (value < 0)
            {
                Debug.LogWarning($"Amount of currency can't be negative");
                return;
            }

            _amount = value;
        }
    }

    public void Add(int amount) => Amount += amount;

    public void Subtract(int amount) => Amount -= amount;
}
