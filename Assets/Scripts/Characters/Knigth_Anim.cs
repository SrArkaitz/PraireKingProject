using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knigth_Anim : MonoBehaviour
{

    public Animator weaponAnim;
    public Animator slashAnim;
    public static Knigth_Anim instance;

    private void Awake()
    {
        instance = this;
    }


    public void AttackAnimations()
    {
        weaponAnim.SetTrigger("Attack");
        slashAnim.SetTrigger("slash");
    }


}
