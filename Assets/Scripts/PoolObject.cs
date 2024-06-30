using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public void ReturnToPool()
    {
        if (this != null && gameObject != null)
        {
            gameObject.SetActive(false);
        }
    }
}