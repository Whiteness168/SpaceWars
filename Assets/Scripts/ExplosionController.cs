using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    [SerializeField]
    protected GameObject _explosion;


    public void Explosion()
    {
        var pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject explosionRef = Instantiate(_explosion, pos, Quaternion.identity);
        
        Destroy(explosionRef, 3f);
    }

    private void Start()
    {
        GetComponent<DeathController>().OnDeath += Explosion;
    }
}
