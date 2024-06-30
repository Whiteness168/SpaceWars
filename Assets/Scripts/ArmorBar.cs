using UnityEngine.UI;
using UnityEngine;

public class ArmorBar : MonoBehaviour
{
    [SerializeField]
    private Image _bar;

    private void ArmorBarAnimation()
    {
        _bar.fillAmount = GameObject.FindWithTag("Player").GetComponent<Armor>().ArmorPoint;
    }

    void Update()
    {
        ArmorBarAnimation();
    }
}