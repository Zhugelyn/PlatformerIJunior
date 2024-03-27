using System;

public class Health : IDamagable
{
    public event Action HealthDecreased;

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
    }

    public void Restore(int recovery, int maxHealth)
    {
        if (recovery < 0)
            return;

        bool isMoreMaxHealth = Count + recovery > maxHealth;

        Count = isMoreMaxHealth ? maxHealth : Count + recovery;
    }

    public int GetAmountHealth()
    {
        return Count;
    }
}
