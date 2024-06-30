using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _bar;
    private Color _newColor = Color.red;

    private void HealthBarAnimation()
    {
        _bar.fillAmount = GameObject.FindWithTag("Player").GetComponent<Health>().HealthPoint;
    }

    private void ChangeColorBar()
    {
        if (_bar.fillAmount < 0.38)
        {
            _bar.color = _newColor;
        }
    }

    void Update()
    {
        HealthBarAnimation();
        ChangeColorBar();
    }
}