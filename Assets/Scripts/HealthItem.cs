using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    [SerializeField] private int _healt = 1;
    private PlayerController playerScript;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            playerScript = collider.gameObject.GetComponent<PlayerController>();

            if(playerScript._currentHealth < playerScript._maxHealth)
            {
                playerScript.AddHealth(_healt);

                Destroy(gameObject);
            }
            
        }
    }
}
