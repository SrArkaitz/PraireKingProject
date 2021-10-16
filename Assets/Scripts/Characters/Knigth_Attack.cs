using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knigth_Attack : MonoBehaviour
{

    public ScreenShake screenShake;
    public enemyCommon enemyCommon;

    public GameObject weapon;
    private Collider2D weaponCol;

    private void Awake()
    {
        enemyCommon = GameObject.FindGameObjectWithTag("Enemy").GetComponent<enemyCommon>();
    }

    private void Start()
    {
        weaponCol = weapon.GetComponent<Collider2D>();
        weaponCol.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AttackStuffs();
        }
    }


    public void AttackStuffs()
    {
        StartCoroutine(screenShake.Shake(0.1f, 0.1f));        
        Knigth_Anim.instance.AttackAnimations();
        weaponCol.enabled = true;
        StartCoroutine(ReturnCollWeapon());
    }

    IEnumerator ReturnCollWeapon()
    {
        yield return new WaitForSeconds(0.4f);
        weaponCol.enabled = false;
    }

}
