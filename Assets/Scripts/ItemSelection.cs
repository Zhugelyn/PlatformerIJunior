using UnityEngine;

[RequireComponent(typeof(Player))]
public class ItemSelection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = this.gameObject.GetComponent<Player>();
        GameObject gameObject = collision.gameObject;

        if (gameObject.TryGetComponent(out Firstaidkit firstaidkit))
        {
            firstaidkit.RestoreHealth(player);
        }

        if (gameObject.TryGetComponent(out Coin coin))
        {
            coin.AddCoins(player);
        }
    }
}
