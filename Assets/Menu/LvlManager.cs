using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlManager : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i + 1 > levelAt)
            {
                buttons[i].interactable = false;
            }
        }
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}