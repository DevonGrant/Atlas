using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private RectTransform rectTransform;

    private float speed = 0.1f;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void OnMouseDown()
    {

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = Vector3.Lerp(transform.position, curPosition, speed);
    }
}