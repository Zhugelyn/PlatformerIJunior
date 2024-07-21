using System.Collections;
using UnityEngine;
using TMPro;

public class VampirismVisualization : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TMP_Text _textAbility;
    [SerializeField] private TMP_Text _textReloading;
    [SerializeField] private Vamprism _vampirism;

    private float _startTextAbility = 0;
    private float _startTextReloding = 6;

    private Coroutine _drawAbility;
    private Coroutine _drawReloading;

    private void OnEnable()
    {
        _vampirism.Activated += VisualizeAbility;
        _vampirism.Deactivated += VisualizeReloading;
    }

    private void OnDisable()
    {
        _vampirism.Activated -= VisualizeAbility;
        _vampirism.Deactivated -= VisualizeReloading;
    }

    private void Start()
    {
        _textAbility.enabled = false;
        _textReloading.enabled = false;
        _spriteRenderer.enabled = false;
    }

    public void VisualizeAbility(float duration, float delay)
    {
        _drawAbility = StartCoroutine(DrawAbility(duration, delay));
    }

    public void VisualizeReloading(float coolDown)
    {
        _drawReloading = StartCoroutine(DrawReloading(coolDown));
    }

    private IEnumerator DrawAbility(float duration, float delay)
    {
        var wait = new WaitForSeconds(delay);

        _textAbility.enabled = true;
        _spriteRenderer.enabled = true;

        for (float i = 0; i < duration; i+= delay)
        {
            _textAbility.text = (duration - i).ToString();

            yield return wait;
        }


        _textAbility.enabled = false;
        _spriteRenderer.enabled = false;
        _textAbility.text = _startTextAbility.ToString();

        if (_drawAbility != null)
            StopCoroutine(_drawAbility);
    }

    private IEnumerator DrawReloading(float cooldown)
    {
        float delay = 1f;
        var wait = new WaitForSeconds(delay);
        _textReloading.enabled = true;

        for (int i = 0; i < cooldown; i++)
        { 
            _textReloading.text = SetReloadDisplay(cooldown - i); ;

            yield return wait;
        }

        _textReloading.enabled = false;
        _textReloading.text = SetReloadDisplay(_startTextReloding);

        if (_drawReloading != null)
            StopCoroutine(_drawReloading);
    }

    private string SetReloadDisplay(float number)
    {
        return $"Перезарядка {number}";
    }
}
