using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCommon : MonoBehaviour
{
    public float attackRadius;
    public float speed;
    public float life;
    public GameObject deathParticles;


    GameObject player;

    bool move = true;

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
            Debug.Log("Entra");
            if (hit.collider.tag == "Player")
            {
                Debug.Log("AAA");
                target = player.transform.position;
            }
        }
        else
        {
            Debug.Log("No entra");
        }
        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        if (distance < attackRadius)
        {

        }
        else
        {
            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }


        Debug.DrawLine(transform.position, target, Color.green);

        //if (move == true)
        //{
        //    rb.MovePosition(transform.position + dir * speed * Time.deltaTime);

        //}


        if (life <= 0)
        {
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

   
}
