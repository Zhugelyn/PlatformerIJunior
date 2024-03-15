using UnityEngine;

public class CoinSelection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Coin coin = gameObject.GetComponent<Coin>();
            player.AddCoin(coin.AmountCoinsAdded);
            Destroy(coin.gameObject);
        }
    }
}
