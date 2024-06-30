using UnityEngine;

public class EngineAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator Animator;

    void Update()
    {
        Animator.SetFloat("horizontalMovement", Mathf.Abs(GetComponent<PlayerMoveController>().HorizontalMovement));
        Animator.SetFloat("horizontalMovement", Mathf.Abs(GetComponent<PlayerMoveController>().VerticalMovement));
    }
}