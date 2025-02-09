using UnityEngine;

public class SetLeftSize : MonoBehaviour
{
    RectTransform rect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width * Screen.height * 3 / 4 / rect.rect.height, Screen.height * 3 / 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (rect.rect.width != Screen.width)
        {
            rect.sizeDelta = new Vector2(Screen.height * 3 / 7.8f, Screen.height * 3 / 4);
        }

    }
}
