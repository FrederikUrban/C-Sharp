using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHP : MonoBehaviour
{
    public int plus = 25;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            FindObjectOfType<AudioManager>().Play("PowerUp");
            PickUp(other);
        }
    }
    

    void PickUp (Collider2D player)
    {
        
        
        PlayerHP PHP = player.GetComponent<PlayerHP>();
        PHP.CurrentHealth += plus;

        Destroy(gameObject);
    }
}
