using UnityEngine;
using UnityEngine.UI;

public class SetTable : MonoBehaviour
{
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width, Screen.height / 3);
    }

    void Update()
    {
        if (Screen.width != rect.rect.width || Screen.height != rect.rect.height)
        {
            rect.sizeDelta = new Vector2(Screen.width, Screen.height / 3);
        }
    }
}
