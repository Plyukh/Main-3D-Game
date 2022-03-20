using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponFireType
{
    NONE,
    SINGLE
}


public class WeaponHandler : MonoBehaviour
{
    private Animator anim;
    public WeaponFireType fireType;
    private new AudioSource audio;
    [SerializeField] int id;
    [SerializeField] AudioClip holsterClip;
    [SerializeField] AudioClip swingClip;

    public GameObject attack_Point;

    [SerializeField] bool canAttack;
    [SerializeField] bool canHolster;
    [SerializeField] bool holster;

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public bool CanAttack()
    {
        return canAttack;
    }

    public bool Holster()
    {
        return holster;
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    public void AttackAnimation()
    {
        anim.SetTrigger("Attack");
    }

    public void ApplyDamage()
    {
        anim.SetTrigger("ApplyDamage");
    }

    public void IdleAnimation()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);
    }

    public void WalkAnimation()
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Run", false);
    }

    public void RunAnimation()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Walk", false);
    }

    void Turn_On_AttackPoint()
    {
        attack_Point.SetActive(true);
    }

    void Turn_Off_AttackPoint()
    {
        if (attack_Point.activeInHierarchy)
        {
            attack_Point.SetActive(false);
        }
    }
    void CanAttack_On()
    {
        canAttack = true;
    }
    void CanAttack_Off()
    {
        canAttack = false;
    }
    void CanHolster_On()
    {
        canHolster = true;
    }
    void CanHolster_Off()
    {
        canHolster = false;
    }
    public void Swing()
    {
        audio.clip = swingClip;
        audio.Play();
    }

    public void TakeWeapon()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
        }
        holster = false;
        audio.clip = holsterClip;
        audio.Play();
    }

    public void HolsterWeapon()
    {
        holster = true;
        canAttack = true;
        gameObject.SetActive(false);
    }

    public void HolsterAnimation()
    {
        if (!holster)
        {
            if (canHolster)
            {
                canAttack = false;
                anim.SetTrigger("Holster");
                audio.clip = holsterClip;
                audio.Play();
            }
        }
        else
        {
            TakeWeapon();
        }
    }
} // class


