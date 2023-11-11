using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sds : Enemy
{
    public override float Damage => 0.05f;

    void Start()
    {
        Health = 0.50f;
    }

    private void Update()
    {
        CheckHealth();
        DestroyOutOfBounds();
    }
}
