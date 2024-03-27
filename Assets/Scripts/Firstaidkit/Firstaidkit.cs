using UnityEngine;

public class Firstaidkit : MonoBehaviour
{
    private int _healthRestored = 20;

    public void RestoreHealth(Player player)
    {
        player.Health.Restore(_healthRestored, player.MaxHealth);
        Destroy(gameObject);
    }
}
