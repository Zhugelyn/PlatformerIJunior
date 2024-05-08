using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _startNumber = 0;
    [SerializeField] private float _delay = 0.5f;

    private float _incrementValue = 1f;
    private bool _isOn = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isOn == false)
            {
                _isOn = true;
                StartCoroutine(AccountIncrease());
            }
            else
            {
                _isOn = false;
            }
        }
    }

    private IEnumerator AccountIncrease()
    {
        var wait = new WaitForSeconds(_delay);

        while (_isOn)
        {
            _startNumber += _incrementValue;
            _textMeshPro.text = _startNumber.ToString();
            yield return wait;
        }
    }
}
