using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public void Toggle(bool toggle)
    {
        this.GetComponent<Image>().enabled = !toggle;
    }
}