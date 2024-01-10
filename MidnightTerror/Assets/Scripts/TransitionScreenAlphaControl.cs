using UnityEngine;
using UnityEngine.UI;

public class TransitionScreenAlphaControl : MonoBehaviour
{
    [SerializeField] private float _alphaChangeRate;

    private Image _image;
    private Color _currentColor;
    private bool _shouldIncrease;

    private void OnEnable()
    {
        if(_image == null)
            _image = GetComponent<Image>();

        _currentColor = new Color(0, 0, 0, 0);
        _image.color = _currentColor;

        _shouldIncrease = true;
    }
    private void Update()
    {
        _image.color = _currentColor;


        if (_shouldIncrease)
        {
            _currentColor.a += _alphaChangeRate * Time.deltaTime;

            if(_currentColor.a >= 1)
            {
                _shouldIncrease = false;
            }
        }
        else
        {
            _currentColor.a -= _alphaChangeRate * Time.deltaTime;

            if(_currentColor.a <= 0)
            {
                gameObject.SetActive(false);
            }
        }


    }
}
