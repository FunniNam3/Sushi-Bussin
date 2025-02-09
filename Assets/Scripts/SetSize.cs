using UnityEngine;
using UnityEngine.UI;

public class SetSize : MonoBehaviour
{
    RectTransform rect;
    public Image[] items;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width, 400);
        for (int i = 0; i < 6; ++i)
        {
            items[i].transform.position = new Vector3((i + 1) * Screen.width / 7, items[i].transform.position.y);
        }
    }

    void Update()
    {
        if (Screen.width != rect.sizeDelta.x)
        {
            rect.sizeDelta = new Vector2(Screen.width, 400);
            for (int i = 0; i < 6; ++i)
            {
                items[i].transform.position = new Vector3((i + 1) * Screen.width / 7, items[i].transform.position.y);
            }
        }
    }
}
