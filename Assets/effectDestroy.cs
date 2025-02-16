using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectDestroy : MonoBehaviour
{
  
    void Update()
    {
        Object.Destroy(gameObject, 0.667f);

    }
}
