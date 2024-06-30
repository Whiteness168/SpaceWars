using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySoundOnHover : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField]
    private AudioSource audioSource;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}