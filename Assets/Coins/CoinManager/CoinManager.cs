using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager CM;
    public TextMeshProUGUI text;
    public static int coinNum;

    void Start()
    {
        if (CM == null)
        {
            CM = this;

        }
    }

    public void ChangeScore(int coinValue)
    {
        coinNum += coinValue;
        text.text = "x" + coinNum.ToString();
    }

}
