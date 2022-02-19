using UnityEngine;

public class MatchHeight : MonoBehaviour
{
    RectTransform rectTransform;
    RectTransform parentRectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRectTransform = transform.parent.GetComponent<RectTransform>();
    }
    void Update()
    {
        rectTransform.sizeDelta = parentRectTransform.sizeDelta;
    }
}
