using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    float nextAttack = 0f;
    public float attackRate1 = 2f;
    public Transform bodStrely;
    public GameObject PlayerBulletPrefab;
    private void Update() {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    
        
    }

    void Shoot()
    {
        if (Time.time >= nextAttack)
        {
           
            nextAttack = Time.time + 1f / attackRate1;
            Instantiate(PlayerBulletPrefab, bodStrely.position, bodStrely.rotation);
        }
        

    }
    

}
