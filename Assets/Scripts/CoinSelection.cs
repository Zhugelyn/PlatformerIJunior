using UnityEngine;

public class CoinSelection : MonoBehaviour
{
    [SerializeField] private int _coinCount;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            _coinCount++;
            Destroy(coin.gameObject);
        }
    }
}
