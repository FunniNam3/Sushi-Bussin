using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    Vector3 initLocation;
    public void MoveContainer(bool toggle)
    {
        if (toggle)
        {
            transform.position += new Vector3(0, 400);
        }
        else
        {
            transform.position -= new Vector3(0, 400);
        }
    }

    void Start()
    {
        initLocation = transform.position;
    }
}
