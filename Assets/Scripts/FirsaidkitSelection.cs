using UnityEngine;

public class FirsaidkitSelection : MonoBehaviour
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
        if (gameObject.TryGetComponent(out Firstaidkit firstaidkit))
        {
            player.RestoreHealth(firstaidkit.AmountHealthRestored);
            Destroy(firstaidkit.gameObject);
        }
    }
}
