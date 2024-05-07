using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _textMeshPro;
    [SerializeField] private float _startNumber = 0;
    [SerializeField] private float _delay = 0.5f;

    private float _incrementValue = 1f;
    private bool _isOn = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isOn = !_isOn;
            StartCoroutine(AccountIncrease());
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
