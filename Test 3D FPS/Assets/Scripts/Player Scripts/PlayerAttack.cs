using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_Manager;
    private OpenUI openUI;
    public float damage = 0f;

    void Awake()
    {
        weapon_Manager = GetComponent<WeaponManager>();
        openUI = GetComponent<OpenUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(weapon_Manager.GetCurrentSelectedWeapon() != null)
        {
            if (weapon_Manager.GetCurrentSelectedWeapon().CanAttack() && !openUI.InventoryOpen())
            {
                WeaponAttack();
                HolsterWeapon();
            }
        }
    }

    void WeaponAttack()
    {
        if (weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.SINGLE)
        {
            if (Input.GetMouseButtonDown(0))
            {
                weapon_Manager.GetCurrentSelectedWeapon().AttackAnimation();
            }
        }
    }

    void HolsterWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon_Manager.GetCurrentSelectedWeapon().HolsterAnimation();
        }
    }
}
