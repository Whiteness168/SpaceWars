using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Sounds _sounds;

    private void PlaySoundExplosion()
    {
        _sounds.PlayClip();
    }
    void Start()
    {
        _sounds = GetComponent<Sounds>();
        PlaySoundExplosion();
    }
}