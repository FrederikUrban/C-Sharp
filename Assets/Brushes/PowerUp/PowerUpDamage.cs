using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDamage : MonoBehaviour
{
    public int plus = 25;
    public float duration = 5f;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }


    IEnumerator PickUp(Collider2D player)
    {
        
       
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        Weapon Dmg = player.GetComponent<Weapon>();
        Weapon1 ww = Dmg.PlayerBulletPrefab.GetComponent<Weapon1>();
        ww.damage += plus;
        Debug.Log("DMG++");
        yield return new WaitForSeconds(5);
        ww.damage -= plus;
        Destroy(gameObject);
    }
}
