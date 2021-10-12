using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knigth_Attack : MonoBehaviour
{

    public ScreenShake screenShake;


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
    }



}
