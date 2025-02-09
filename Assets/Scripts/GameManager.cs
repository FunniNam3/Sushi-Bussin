using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int topOrder = 0;
    public int totalTrash;
    public bool objectChanged = false;
    public int currentLevel;
    public static int TrashCollected = 0;
    public bool isBetween = false;

    void Update()
    {
        if (!isBetween && TrashCollected >= totalTrash && SaveManager.Instance.items[currentLevel - 1])
        {
            Debug.Log(isBetween);
            if (currentLevel == 6)
            {
                SceneManager.LoadScene("Win");
                return;
            }
            isBetween = true;
            SceneManager.LoadScene("Between " + (currentLevel + 1).ToString());
        }
    }

    public void SetBetween()
    {
        isBetween = false;
    }

    public void ResetCollected()
    {
        TrashCollected = 0;
    }
}
