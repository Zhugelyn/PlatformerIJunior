using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class ItemSelection : MonoBehaviour
{
    public event Action<GameObject> Selected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = gameObject.GetComponent<Player>();

        if (collision.gameObject.TryGetComponent(out Firstaidkit firstaidkit))
        {
            player.RestoreHealth(firstaidkit.HealthRestored);
            Destroy(firstaidkit.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            player.AddCoin(coin.Count);
            Selected?.Invoke(coin.gameObject);
        }
    }
}
