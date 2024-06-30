using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddEventTrigger : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private AudioSource audioSource;

    void Start()
    {
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { PlaySound(); });
        trigger.triggers.Add(entry);
    }

    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}