using UnityEngine;

public class SetScale : MonoBehaviour
{
    public Vector2 Scale;
    RectTransform rect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.sizeDelta = new Vector2(Screen.width * Scale.x, Screen.height * Scale.y);
        // rect.localScale = new Vector3(Scale.x, Scale.y, 0);
    }
}
