using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meteor : Enemy
{
    public override float Damage => 0.05f;

    void Start()
    {
        Health = 0.50f;

        _spriteRend = GetComponent<SpriteRenderer>();
        _matBlink = Resources.Load("Blink", typeof(Material)) as Material;
        _matDefault = _spriteRend.material;

        _explosion = Resources.Load("Explosion");
    }

    private void Update()
    {
        CheckHealth();
        DestroyOutOfBounds();
    }

}
