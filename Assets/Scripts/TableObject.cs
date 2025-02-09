using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TableObject : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameManager gameManager;
    public int sortingOrder = 0;
    public bool inBucket = false;
    private Vector3 initalLocation;
    private int initalOrder;
    private RectTransform rectTransform;
    private SpriteRenderer sprite;
    private bool allowMove = true;
    private bool moving = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        moving = true;
        if (allowMove)
        {
            sortingOrder = gameManager.topOrder;
            gameManager.objectChanged = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        moving = false;
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
        initalLocation = transform.position;
        initalOrder = sprite.sortingOrder;
    }

    void FixedUpdate()
    {
        if (allowMove)
        {
            if (sprite)
            {
                sprite.sortingOrder = sortingOrder;
            }
            if (!moving)
            {
                if (initalLocation.x - transform.position.x < 0.1f && initalLocation.y - transform.position.y < 0.1f && initalLocation.x - transform.position.x > -0.1f && initalLocation.y - transform.position.y > -0.1f)
                {
                    transform.position = initalLocation;
                    sprite.sortingOrder = initalOrder;
                }
                else
                {
                    transform.position += (initalLocation - transform.position) / 25;
                    sprite.sortingOrder = initalOrder;
                }

            }
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
            Vector3 temp = new Vector3(position.x + (rectTransform.rect.width / 2) + 0.1f, position.y + (rectTransform.rect.height / 2) + 0.1f, position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(-0.05f, -0.05f, 0);
            }

            // Top Left corner
            temp = new Vector3(position.x - (rectTransform.rect.width / 2), position.y + (rectTransform.rect.height / 2) + 0.1f, position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(0.05f, -0.05f, 0);
            }

            // Bottom Right corner
            temp = new Vector3(position.x + (rectTransform.rect.width / 2) + 0.1f, position.y - (rectTransform.rect.height / 2), position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(-0.05f, 0.05f, 0);
            }

            // Bottom Left corner
            temp = new Vector3(position.x - (rectTransform.rect.width / 2), position.y - (rectTransform.rect.height / 2), position.z);
            if (!other.bounds.Contains(temp))
            {
                transform.position += new Vector3(0.05f, 0.05f, 0);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inBucket = false;
    }
}