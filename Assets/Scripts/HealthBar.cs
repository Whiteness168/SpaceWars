using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : Player
{
    public Image Bar;

    void Update()
    {
        Bar.fillAmount = HealthPoint;
    }
}
