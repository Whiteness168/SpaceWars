using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    [SerializeField]
    private Sounds _sounds;
    [SerializeField]
    private float _volume;
    [SerializeField]
    private AudioClip _clip;
    [SerializeField]
    private float _rangePitchOne;
    [SerializeField]
    private float _rangePitchTwo;
    
    public void PlayClip()
    {
        _audioSource.PlayOneShot(_clip, _volume);
    }

    public void PlayLoopingSound()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }
    }

    public void StopLoopingSound()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }
    }

    public void PlaySound()
    {
        
    }
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
}