using System;

public class Health : IDamagable
{
    public event Action HealthDecreased;

    private int Amount { get; set; }

    public void Init(int amount)
    {
        Amount = amount;
    }

    public void TakeDamage(int damage)
    {
        if (Amount < 0)
            return;

        Amount -= damage;
        HealthDecreased?.Invoke();
    }

    public void Restore(int recovery, int maxHealth)
    {
        if (recovery < 0)
            return;

        bool isMoreMaxHealth = Amount + recovery > maxHealth;

        Amount = isMoreMaxHealth ? maxHealth : Amount + recovery;
    }

    public int GetAmountHealth()
    {
        return Amount;
    }
}
