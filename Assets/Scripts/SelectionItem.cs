using System;
using UnityEngine;

public class SelectionItem : MonoBehaviour
{
    public static event Action<GameObject, Player> TakeItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            TakeItem?.Invoke(gameObject, player);
    }
}
