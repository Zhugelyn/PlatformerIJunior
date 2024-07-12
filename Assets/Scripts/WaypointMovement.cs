using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    public void MoveToPoint()
    {
        var increment = 1;
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint = _currentPoint + increment % _points.Length;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }

            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }
}
