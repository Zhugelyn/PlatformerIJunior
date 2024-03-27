using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _coinsAdded = 1;

    public void AddCoins(Player player)
    {
        player.AddCoin(_coinsAdded);
        Destroy(gameObject);
    }
}
