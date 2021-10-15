using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest : MonoBehaviour
{

    public enemyCommon enemyCommon;

    private void Start()
    {
        enemyCommon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyCommon>();
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log(collision.name);
            enemyCommon.hitted();
        }
    }
}
