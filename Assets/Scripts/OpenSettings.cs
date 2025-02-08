using UnityEngine;

public class OpenSettings : MonoBehaviour
{
    Vector3 initLocation;
    public bool Open = false;
    public void MoveContainer(bool toggle)
    {
        if (toggle)
        {
            transform.position += new Vector3(411, 0);
            // Open = false;
        }
        else
        {
            transform.position = initLocation;
            // Open = true;
        }
    }

    void Start()
    {
        initLocation = transform.position;
    }
}
