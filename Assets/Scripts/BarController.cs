using UnityEngine.UI;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField]
    private Image _bar;
    [SerializeField]
    private Health _health;
    [SerializeField]
    private Armor _armor;
    [SerializeField]
    private bool _needChangeColorBar;

    private float _threshold;


    private void UpdateBar(float point)
    {
        _bar.fillAmount = point;
    }

    private float WhatIsIndicator()
    {
        if (_health != null)
        {
            return _health.HealthPoint;
        }
        else
        {
            return _armor.ArmorPoint;
        }
    }

    private void ChangeColorBar()
    {
        if (_needChangeColorBar)
        {
            if (_bar.fillAmount < _threshold)
            {
                _bar.color = Color.red;
            }
            else 
            {
                _bar.color = Color.green;
            }
        }
    }

    private void Start()
    {
        _threshold = 0.38f;
    }

    private void Update()
    {
        UpdateBar(WhatIsIndicator());
        ChangeColorBar();
    }
}