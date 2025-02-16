using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLVL : MonoBehaviour
{
    // Start is called before the first frame update

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("RESET");
    }
}
