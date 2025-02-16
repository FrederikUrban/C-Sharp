using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GollemBullet : MonoBehaviour
{

    public GameObject laser;
    public GameObject Effect;
    
    void Start()
    {
    
        Instantiate(Effect, transform.position, transform.rotation);
       
        Destroy(gameObject, 2f);
        Instantiate(laser, transform.position, transform.rotation);
        Destroy(gameObject, 2f);


    }

    


}




   
   

    

