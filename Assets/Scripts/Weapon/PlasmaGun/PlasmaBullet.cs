using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D; 
    [SerializeField] private float _speed = 25;

    private int _damage = 20;

    private void Start()
    {
        _rigidbody2D.velocity = transform.right * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out EnemyPatrol enemy))
        {
            enemy.Health.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
