using UnityEngine;
using UnityEngine.EventSystems;

public class TableObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameManager gameManager;
    private RectTransform rectTransform;
    private SpriteRenderer sprite;
    public int sortingOrder = 0;
    public bool inBucket = false;
    private bool allowMove = true;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (allowMove)
        {
            sortingOrder = ++(gameManager.topOrder);
            gameManager.objectChanged = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (inBucket)
        {
            allowMove = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (allowMove)
        {
            rectTransform.anchoredPosition += eventData.delta;
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(position.x, position.y, transform.position.z);
        }
    }

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rectTransform = GetComponent<RectTransform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (allowMove && sprite)
        {
            sprite.sortingOrder = sortingOrder;
        }
        if (inBucket && !allowMove)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inBucket = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!allowMove)
        {
            Vector3 position = rectTransform.position;

            // Top Right corner
            Vector3 temp = new Vector3(position.x + (rectTransform.rect.width / 2), position.y + (rectTransform.rect.height / 2), position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(-0.01f, -0.01f, 0);
            }

            // Top Left corner
            temp = new Vector3(position.x - (rectTransform.rect.width / 2), position.y + (rectTransform.rect.height / 2), position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(0.01f, -0.01f, 0);
            }

            // Bottom Right corner
            temp = new Vector3(position.x + (rectTransform.rect.width / 2), position.y - (rectTransform.rect.height / 2), position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(-0.01f, 0.01f, 0);
            }

            // Bottom Left corner
            temp = new Vector3(position.x - (rectTransform.rect.width / 2), position.y - (rectTransform.rect.height / 2), position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(0.01f, 0.01f, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inBucket = false;
    }
}