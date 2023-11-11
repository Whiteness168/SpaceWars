using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolBackGround : MonoBehaviour
{
    [SerializeField] public float SpeedScroll;
    [SerializeField] public float TileSize;
    private Transform _ñurrentObject;

    void Start()
    {
        _ñurrentObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _ñurrentObject.position = new Vector3(_ñurrentObject.position.x, Mathf.Repeat(Time.time * SpeedScroll, TileSize));
    }
}
