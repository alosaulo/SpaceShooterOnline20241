using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MoveShip : NetworkBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody2D rb;

    float movement;

    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
            rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer)
            movement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
            rb.velocity = new Vector2(movement * speed, 0.0f);
    }

}
