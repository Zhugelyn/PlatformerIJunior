using System.Collections;
using UnityEngine;
using TMPro;

public class VampirismVisualization : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _textAbility;
    [SerializeField] private TMP_Text _textReloading;

    private float _startTextAbility = 0;
    private float _startTextReloding = 6;

    private void Start()
    {
        _textAbility.enabled = false;
        _textReloading.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public void VisualizeAbility(float duration)
    {
        StartCoroutine("DrawAbility", duration);
    }

    public void VisualizeReloading(float coolDown)
    {
        StartCoroutine("DrawReloading", coolDown);
    }

    private IEnumerator DrawAbility(float duration)
    {
        float delay = 1f;
        var wait = new WaitForSeconds(delay);
        int i = 0;

        _textAbility.enabled = true;
        _spriteRenderer.enabled = true;

        while (duration > i)
        {
            _textAbility.text = (duration - i).ToString();
            i++;

            yield return wait;
        }

        StopCoroutine("DrawAbility");

        _textAbility.enabled = false;
        _spriteRenderer.enabled = false;
        _textAbility.text = _startTextAbility.ToString();
    }

    private IEnumerator DrawReloading(float cooldown)
    {
        float delay = 1f;
        var wait = new WaitForSeconds(delay);
        int i = 0;
        _textReloading.enabled = true;

        while (cooldown > i)
        {
            _textReloading.text = SetReloadDisplay(cooldown - i); ;
            i++;

            yield return wait;
        }

        StopCoroutine("DrawReloading");

        _textReloading.enabled = false;
        _textReloading.text = SetReloadDisplay(_startTextReloding);
    }

    private string SetReloadDisplay(float number)
    {
        return $"Перезарядка {number}";
    }
}
