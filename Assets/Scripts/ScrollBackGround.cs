using UnityEngine;

public class ScrollBackGround : MonoBehaviour
{
    [SerializeField] 
    public float SpeedScroll;
    [SerializeField] 
    public float TileSize;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Repeat(Time.time * SpeedScroll, TileSize));
    }
}
