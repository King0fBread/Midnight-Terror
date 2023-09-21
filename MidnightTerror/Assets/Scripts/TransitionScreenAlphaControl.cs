using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreenAlphaControl : MonoBehaviour
{
    [SerializeField] private float _alphaChangeRate;

    private Image _image;
    private Color _currentColor;

    private void OnEnable()
    {
        if(_image == null)
            _image = GetComponent<Image>();

        _currentColor = Color.black;
        _image.color = _currentColor;
    }
    private void Update()
    {
        _currentColor.a -= _alphaChangeRate * Time.deltaTime;
        _image.color = _currentColor;

        if(_currentColor.a <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
