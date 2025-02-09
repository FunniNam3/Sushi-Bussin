using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public bool[] items = new bool[6];

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ItemCollected(int itemIndex)
    {
        SaveManager.Instance.items[itemIndex] = true;
    }

    public void ResetItems()
    {
        for (int i = 0; i < 6; ++i)
        {
            SaveManager.Instance.items[i] = false;
        }
    }

    private void Start()
    {
        if (SaveManager.Instance != null)
        {
            for (int i = 0; i < 6; ++i)
            {
                SaveManager.Instance.items[i] = false;
            }
        }
    }
}
