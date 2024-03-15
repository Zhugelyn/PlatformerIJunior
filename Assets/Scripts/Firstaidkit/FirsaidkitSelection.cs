using UnityEngine;

public class FirsaidkitSelection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            Firstaidkit firstaidkit = gameObject.GetComponent<Firstaidkit>();
            Debug.Log(firstaidkit.AmountHealthRestored);
            player.RestoreHealth(firstaidkit.AmountHealthRestored);
            Destroy(firstaidkit.gameObject);
        }
    }
}
