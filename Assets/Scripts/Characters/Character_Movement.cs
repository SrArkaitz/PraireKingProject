using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Movement : MonoBehaviour
{


    public Characters_Scriptable playerData;

    private Rigidbody2D rb2d;
    private float playerSpeed;
    private int currentLife;
    private int maxLife;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public Joystick joystick;


    float testSpeed;

    public GameObject pivot;

    public ParticleSystem dust;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerSpeed = playerData.characSpeed;
        currentLife = playerData.currentLife;
        maxLife = playerData.maxLife;

        playerData.InitLife();

    }

    Vector2 test = new Vector2(0f, 0f);


    // Update is called once per frame
    void Update()
    {
        Flip();
        FlipPivot();
        RunAnim();
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
            CreateDust();
            Debug.Log(horizontal);
        }
        else if (joystick.Horizontal <= -0.3f)
        {
            horizontal = -playerSpeed;
            CreateDust();
        }
        else
        {
            horizontal = 0f;
        }

        if (joystick.Vertical >= 0.3f)
        {
            vertical = playerSpeed;
            CreateDust();
            Debug.Log("vertical");
        }
        else if (joystick.Vertical <= -0.3f)
        {
            vertical = -playerSpeed;
            CreateDust();
        }
        else
        {
            vertical = 0f;
        }

        rb2d.velocity = new Vector2(horizontal, vertical).normalized * playerSpeed * Time.fixedDeltaTime;

    }

    private void FlipPivot()
    {
        if (horizontal > 0)
        {
            pivot.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontal < 0)
        {
            pivot.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
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

    private void RunAnim()
    {
        testSpeed = horizontal + vertical;
        animator.SetFloat("runAnim", Mathf.Abs(testSpeed));
    }

    private void Die()
    {
        if (currentLife <= 0)
        {
            Destroy(this.gameObject);
            //Particula muerte
            //Acciones de revivir o empezar de nuevo el juego
        }
    }

    bool canRecibeDamage = true;

    public void PlayerHittet(int damage)
    {
        if (canRecibeDamage)
        {
            currentLife -= damage;
        }
        //Animación daño
        //Corrutina invulnerabilidad
    }


    private void CreateDust()
    {
        dust.Play();
    }

}
