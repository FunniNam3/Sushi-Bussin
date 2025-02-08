using UnityEngine;
using UnityEngine.EventSystems;

public class TableObject : MonoBehaviour, IDragHandler
{
    private RectTransform rectTransform;
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
        Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(position.x, position.y, transform.position.z);
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
}