using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private Transform _spawnCoins;
    [SerializeField] private ItemSelection _itemSelection;

    private Transform[] _spawns;

    private void OnEnable()
    {
        _itemSelection.Selected += DestroyCoin;
    }

    private void OnDisable()
    {
        _itemSelection.Selected -= DestroyCoin;
    }

    private void Awake()
    {
        _spawns = new Transform[_spawnCoins.childCount];

        for (int i = 0; i < _spawns.Length; i++)
        {
            _spawns[i] = _spawnCoins.GetChild(i);
        }
    }

    private void Start()
    {
        GenerateCoins();
    }

    private void GenerateCoins()
    {
        for (int i = 0; i < _spawns.Length; i++)
        {
            Instantiate(_template, _spawns[i].position, Quaternion.identity);
        }
    }

    private void DestroyCoin(GameObject coin)
    {
        Destroy(coin);
    }

}
