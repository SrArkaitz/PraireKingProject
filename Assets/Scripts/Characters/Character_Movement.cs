using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{


    public Characters_Scriptable playerData;

    private Rigidbody2D rb2d;
    private float playerSpeed;
    private SpriteRenderer spriteRenderer;

    public Joystick joystick;

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
        Flip();
    }

    private void FixedUpdate()
    {
        //PlayerMovement();
        PlayerMovementJoystick();
    }

    float horizontal = 0;
    float vertical = 0;

    public void PlayerMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * playerSpeed * Time.fixedDeltaTime;

    }


    public void PlayerMovementJoystick()
    {

        if (joystick.Horizontal >= 0.3f)
        {
            horizontal = playerSpeed;
        }
        else if (joystick.Horizontal <= -0.3f)
        {
            horizontal = -playerSpeed;
        }
        else
        {
            horizontal = 0f;
        }

        if (joystick.Vertical >= 0.3f)
        {
            vertical = playerSpeed;
        }
        else if (joystick.Vertical <= -0.3f)
        {
            vertical = -playerSpeed;
        }
        else
        {
            vertical = 0f;
        }

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * playerSpeed * Time.fixedDeltaTime;

    }

    private void Flip()
    {
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
