using UnityEngine;

public class Firstaidkit : MonoBehaviour
{
    private int AmountHealthRestored { get; set; } = 20;

    public void RestoreHealth(Player player)
    {
        player.Health.Restore(AmountHealthRestored, player.MaxHealth);
        Destroy(gameObject);
    }
}
