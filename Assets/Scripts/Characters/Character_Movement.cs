using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{


    public Characters_Scriptable playerData;

    private Rigidbody2D rb2d;
    private float playerSpeed;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerSpeed = playerData.characSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }


    public void PlayerMovement()
    {
        float horizontal;
        float vertical;

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * playerSpeed;

        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }

    }

}
