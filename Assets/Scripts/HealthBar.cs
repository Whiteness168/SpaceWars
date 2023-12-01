using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _bar;

    private void HealthBarAnimation()
    {
        _bar.fillAmount = GameObject.FindWithTag("Player").GetComponent<Health>().HealthPoint;
    }

    void Update()
    {
        HealthBarAnimation();
    }
}
