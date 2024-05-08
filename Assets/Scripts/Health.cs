using System;

public class Health : IDamagable
{
    public event Action HealthDecreased;
    public event Action Die;

    private int Count { get; set; }

    public void Init(int amount)
    {
        Count = amount;
    }

    public void TakeDamage(int damage)
    {
        if (Count < 0)
            return;

        Count -= damage;
        HealthDecreased?.Invoke();

        if (Count <= 0)
            Die?.Invoke();
    }

    public void Restore(int recovery, int maxHealth)
    {
        if (recovery < 0)
            return;

        Count = Math.Clamp(recovery + Count, Count, maxHealth);
    }

    public int GetAmountHealth()
    {
        return Count;
    }
}
