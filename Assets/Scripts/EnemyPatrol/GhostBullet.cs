using UnityEngine;

public class GhostBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private int _damage = 20;
    private float _lifetime = 3f;
    private float _destructionTime;

    private void Start()
    {
        _destructionTime = Time.time + _lifetime;
    }

    private void Update()
    {
        if (Time.time > _destructionTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Atta");

        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamge(_damage);
        }

        Destroy(gameObject);
    }
}
