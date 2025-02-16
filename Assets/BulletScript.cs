using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float nextAttack = 0f;
    public float attackRate1 = 2f;
    public Transform bodStrely;
    public GameObject BulletPrefab;
   
    void Shoot()
    {
       if (Time.time >= nextAttack)
        {

           nextAttack = Time.time + 1f / attackRate1;
           Instantiate(BulletPrefab, bodStrely.position, bodStrely.rotation);
            FindObjectOfType<AudioManager>().Play("Boss_Shoot");
        }
       

    }


}
