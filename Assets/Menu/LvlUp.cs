using UnityEngine;
using UnityEngine.SceneManagement;
/*
public class LvlUp : MonoBehaviour
{
    public int iLvlLoad;
    public string sLvlLoad;
    public bool IntLoadLvl = false;

    private void Start()
    {
        PlayerPrefs.SetInt("levelIsUnlocked", 1);
    }

    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelIsUnlocked"))
        {
            PlayerPrefs.SetInt("levelIsUnlocked", currentLevel + 1);
            Debug.Log("lvlUNLOCKED" + PlayerPrefs.GetInt("levelIsUnlocked"));
        }

        Debug.Log("LEVEL" + PlayerPrefs.GetInt("levelIsUnlocked") + " UNLOCKED");
    } 
    
    private void Load()
    {
        if (IntLoadLvl)
        {
            SceneManager.LoadScene(iLvlLoad);
        }
        else
        {
            SceneManager.LoadScene(sLvlLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        if (collisionGameObject.name == "Hrac")
        {
            FindObjectOfType<AudioManager>().Play("LvlUp");
            Pass();
            Load();
        }
    }

   
}*/