using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolBackGround : MonoBehaviour
{
    [SerializeField] public float SpeedScroll;
    [SerializeField] public float TileSize;
    private Transform _�urrentObject;

    void Start()
    {
        _�urrentObject = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _�urrentObject.position = new Vector3(_�urrentObject.position.x, Mathf.Repeat(Time.time * SpeedScroll, TileSize));
    }
}
