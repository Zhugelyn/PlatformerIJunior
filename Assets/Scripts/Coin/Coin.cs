using UnityEngine;

public class Coin : MonoBehaviour
{
    private int AmountCoinsAdded { get; set; } = 1;

    public void AddCoins(Player player)
    {
        player.AddCoin(AmountCoinsAdded);
        Destroy(gameObject);
    }
}
