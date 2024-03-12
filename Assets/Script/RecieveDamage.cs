using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecieveDamage : NetworkBehaviour
{

    [SerializeField] int maxHealth = 10;

    [SyncVar] int currentHealth;

    [SerializeField] string damageTag;

    [SerializeField] bool destroyOnDeath;

    Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == damageTag) 
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }

    void TakeDamage(int dmg) 
    {
        currentHealth -= dmg;
        if (currentHealth <= 0) 
        {
            if (destroyOnDeath)
            {
                Destroy(gameObject);
            }
            else 
            {
                currentHealth = maxHealth;
                RpcRespawn();
            }
        }
    }

    [ClientRpc]
    void RpcRespawn() 
    {
        transform.position = initialPosition;
    }

}
