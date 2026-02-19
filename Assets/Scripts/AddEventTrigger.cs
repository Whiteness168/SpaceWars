using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AddEventTrigger : MonoBehaviour {
    [SerializeField] private Button _button;
    [SerializeField] private AudioSource _audioSource;

    void Start() {
        EventTrigger trigger = _button.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((eventData) => { PlaySound(); });
        trigger.triggers.Add(entry);
    }

    public void PlaySound() {
        if (_audioSource != null) {
            _audioSource.Play();
        }
    }
}
