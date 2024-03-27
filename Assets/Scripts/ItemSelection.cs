using UnityEngine;

[RequireComponent(typeof(Player))]
public class ItemSelection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = gameObject.GetComponent<Player>();
        GameObject item = collision.gameObject;

        if (item.TryGetComponent(out Firstaidkit firstaidkit))
        {
            firstaidkit.RestoreHealth(player);
        }

        if (item.TryGetComponent(out Coin coin))
        {
            coin.AddCoins(player);
        }
    }
}
