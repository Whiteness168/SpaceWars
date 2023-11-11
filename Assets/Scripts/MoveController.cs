using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : Player
{
    [SerializeField] public Animator Animator;
    
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalMovement, verticalMovement, 0) * _speed * Time.deltaTime;

        PlayfieldConstriction(horizontalMovement, verticalMovement);

        Animator.SetFloat("horizontalMovement", Mathf.Abs(horizontalMovement));
        Animator.SetFloat("horizontalMovement", Mathf.Abs(verticalMovement));
    }
}
