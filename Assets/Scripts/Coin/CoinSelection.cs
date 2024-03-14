using UnityEngine;

public class CoinSelection : MonoBehaviour
{
    private void OnEnable()
    {
        SelectionItem.TakeItem += CheckLiftedItem;
    }

    private void OnDisable()
    {
        SelectionItem.TakeItem -= CheckLiftedItem;
    }

    private void CheckLiftedItem(GameObject gameObject, Player player)
    {
        if (gameObject.TryGetComponent(out Coin coin))
        {
            player.AddCoin(coin.AmountCoinsAdded);
            Destroy(coin.gameObject);
        }
    }
}
