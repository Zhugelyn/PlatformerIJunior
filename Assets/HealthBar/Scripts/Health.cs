using System;

public class Health
{
    public event Action<int> Changed;
    public event Action Die;

    public Health(int amount)
    {
        Count = amount;
        MaxHealth = amount;
    }

    public int MaxHealth { get; private set; }
    public int Count { get; private set; }

    public void TakeDamage(int damage)
    {
        if (Count < 0)
            return;

        Count -= damage;
        Changed?.Invoke(Count);

        if (Count <= 0)
            Die?.Invoke();
    }

    public void Restore(int recovery)
    {
        if (recovery < 0)
            return;

        Count = Math.Clamp(recovery + Count, Count, MaxHealth);
        Changed?.Invoke(Count);
    }

    public int GetAmountHealth()
    {
        return Count;
    }
}
