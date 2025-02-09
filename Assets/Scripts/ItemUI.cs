using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public int itemIndex;
    void Update()
    {
        GetComponent<Image>().enabled = SaveManager.Instance.items[itemIndex];
    }
}
