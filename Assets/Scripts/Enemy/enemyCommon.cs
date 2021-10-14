using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCommon : MonoBehaviour
{
    public float attackRadius;
    public float speed;
    public float life;
    public GameObject deathParticles;
    public Animator animator;


    GameObject player;

    Animator anim;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 target = player.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            player.transform.position - transform.position,
            attackRadius,
            1 << LayerMask.NameToLayer("Default")
         );

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                Debug.Log("AAA");
                target = player.transform.position;
            }
        }
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if (distance < attackRadius)
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);            
        }


        Debug.DrawLine(transform.position, target, Color.green);



        if (life <= 0)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

        if (transform.position.x < player.transform.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        

    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public void hitted()
    {
        life--;

        //Efecto partículas


    }
   
}



//Mirar maquina de estados

//Mirar corrutina

//Fuerza a rb