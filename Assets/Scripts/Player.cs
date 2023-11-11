using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public virtual float _speed { get; protected set; }
    public virtual float HealthPoint { get; protected set; }

    private Material _matBlink;
    private Material _matDefault;
    private SpriteRenderer _spriteRend;

    private int _score;

    private Camera _camera;

    public Player()
    {
        _speed = 10f;
        HealthPoint = 1.0f;
    }

    public void PlayfieldConstriction(float horizontalMovement, float verticalMovement)
    {
        var min = _camera.ViewportToWorldPoint(new Vector2(0, 0));
        var max = _camera.ViewportToWorldPoint(new Vector2(1, 1));

        if (transform.position.x > max.x || transform.position.x < min.x)
        {
            transform.position -= new Vector3(horizontalMovement, 0, 0) * _speed * Time.deltaTime;
        }

        if (transform.position.y > max.y || transform.position.y < min.y)
        {
            transform.position -= new Vector3(0, verticalMovement, 0) * _speed * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        HealthPoint -= damage;

        if (HealthPoint < 0f)
        {
            Die();
        }
        PerformBlink();
    }

    private async void PerformBlink()
    {
        _spriteRend.material = _matBlink;
        await Task.Delay(200);
        _spriteRend.material = _matDefault;
    }

    private void ResourcesMaterial()
    {
        _spriteRend.material = _matDefault;
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        _camera = Camera.main;
        _spriteRend = GetComponent<SpriteRenderer>();
        _matBlink = Resources.Load("Blink", typeof(Material)) as Material;
        _matDefault = _spriteRend.material;
    }

    void Update()
    {
        
    }
}
