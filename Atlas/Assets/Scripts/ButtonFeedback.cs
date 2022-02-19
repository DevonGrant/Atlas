using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public enum SizeState {Stable, Growing, Shrinking}

public class ButtonFeedback : MonoBehaviour
{
    public AudioSource audioSource;
    public EventTrigger eventTrigger;
    public RectTransform rectTransform;

    private SizeState sizeState;
    private Vector2 originalSize;
    private Vector2 hoverSize;

    private float sizeLerpFactor = 0.04f;

    AudioClip hoverSound;
    AudioClip clickSound;
    AudioClip backSound;
    void Start()
    {
        sizeState = SizeState.Stable;

        if (gameObject.GetComponent<Button>().interactable)
        {
            hoverSound = Resources.Load<AudioClip>("Sounds/hover");
            clickSound = Resources.Load<AudioClip>("Sounds/click");
            backSound = Resources.Load<AudioClip>("Sounds/back");

            audioSource = SoundContinuity.Instance.GetComponent<AudioSource>();
            eventTrigger = GetComponent<EventTrigger>();
            rectTransform = GetComponent<RectTransform>();

            
            originalSize = new Vector2(rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);
            hoverSize = new Vector2(originalSize.x * 1.1f, originalSize.y * 1.1f);

            EventTrigger.Entry hoverEntry = new EventTrigger.Entry();
            hoverEntry.eventID = EventTriggerType.PointerEnter;
            hoverEntry.callback.AddListener((data) => {
                OnPointerEnterDelegate((PointerEventData)data);
            });

            EventTrigger.Entry leaveEntry = new EventTrigger.Entry();
            leaveEntry.eventID = EventTriggerType.PointerExit;
            leaveEntry.callback.AddListener((data) => {
                OnPointerExitDelegate((PointerEventData)data);
            });

            EventTrigger.Entry clickEntry = new EventTrigger.Entry();
            clickEntry.eventID = EventTriggerType.PointerDown;
            clickEntry.callback.AddListener((data) => {
                if (gameObject.name == "back")
                {
                    OnPointerDownDelegateBack((PointerEventData)data);
                }
                else
                {
                    OnPointerDownDelegate((PointerEventData)data);
                }
            });

            eventTrigger.triggers.Add(clickEntry);
            eventTrigger.triggers.Add(hoverEntry);
            eventTrigger.triggers.Add(leaveEntry);
        }
    }

    void Update()
    {
        UpdateSize();
    }

    private void UpdateSize()
    {
        switch (sizeState)
        {
            case SizeState.Growing:
                rectTransform.sizeDelta = new Vector2(Mathf.Lerp(rectTransform.sizeDelta.x, hoverSize.x, sizeLerpFactor),
                                                      Mathf.Lerp(rectTransform.sizeDelta.y, hoverSize.y, sizeLerpFactor));

                if (rectTransform.sizeDelta.magnitude >= hoverSize.magnitude * 0.99f)
                    sizeState = SizeState.Stable;
                break;
            case SizeState.Shrinking:
                rectTransform.sizeDelta = new Vector2(Mathf.Lerp(rectTransform.sizeDelta.x, originalSize.x, sizeLerpFactor),
                                                      Mathf.Lerp(rectTransform.sizeDelta.y, originalSize.y, sizeLerpFactor));

                if (rectTransform.sizeDelta.magnitude <= originalSize.magnitude * 1.01f)
                    sizeState = SizeState.Stable;
                break;
            default:
                break;
        }
    }

    public void OnPointerEnterDelegate(PointerEventData data)
    {
        audioSource.PlayOneShot(hoverSound);
        sizeState = SizeState.Growing;
    }

    public void OnPointerExitDelegate(PointerEventData data)
    {
        sizeState = SizeState.Shrinking;
    }

    public void OnPointerDownDelegate(PointerEventData data)
    {
        audioSource.PlayOneShot(clickSound);
    }

    public void OnPointerDownDelegateBack(PointerEventData data)
    {
        audioSource.PlayOneShot(backSound);
    }
}