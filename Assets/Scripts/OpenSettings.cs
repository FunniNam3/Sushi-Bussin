using UnityEngine;
using UnityEngine.UI;

public class OpenSettings : MonoBehaviour
{
    Vector3 initLocation;
    public static RectTransform rect;
    public void MoveContainer(bool toggle)
    {
        if (toggle)
        {
            transform.position += new Vector3(rect.rect.width, 0);
        }
        else
        {
            transform.position = initLocation;
        }
    }

    public void ByHowTo(bool toggle)
    {
        if (toggle)
        {
            transform.position += new Vector3(rect.rect.width, 0);
            this.GetComponent<Image>().enabled = false;
        }
        else
        {
            transform.position = initLocation;
            this.GetComponent<Image>().enabled = true;
        }
    }

    void Start()
    {
        initLocation = transform.position;
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(rect.rect.width * (Screen.height * 0.75f) / rect.rect.height, Screen.height * 0.75f);
    }
}
