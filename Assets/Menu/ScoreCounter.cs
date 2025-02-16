using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int ScoreVal;
    public Text score;
    void Start()
    {
        ScoreVal = 0;
        score = GetComponent<Text> ();
    }

    void Update()
    {
        score.text = "Score  " + ScoreVal;
    }
}
