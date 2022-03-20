using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private WeaponHandler[] weapons;
    [SerializeField] private WeaponHandler[] allWeapons;

    private int current_Weapon_Index;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public WeaponHandler[] AllWeapons
    {
        get
        {
            return allWeapons;
        }
        set
        {
            allWeapons = value;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TurnOnSelectedWeapon(3);
        }

        for (int i = 0; i < inventory.weaponInventory.Length; i++)
        {
            if (inventory.weaponInventory[i].id == 0)
            {
                if(weapons[i] != null)
                {
                    if (weapons[i].gameObject.activeInHierarchy)
                    {
                        weapons[i].HolsterWeapon();
                    }
                }
                weapons[i] = null;
            }
            else
            {
                if (weapons[i] != null)
                {
                    if (inventory.weaponInventory[i].id != weapons[i].Id)
                    {
                        weapons[i].HolsterWeapon();
                    }
                }
                weapons[i] = allWeapons[inventory.weaponInventory[i].id];
            }
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if(inventory.weaponInventory[weaponIndex].id != 0)
        {
            if (current_Weapon_Index == weaponIndex && !GetCurrentSelectedWeapon().gameObject.activeInHierarchy)
            {
                weapons[weaponIndex].TakeWeapon();
                return;
            }
            if (weapons[current_Weapon_Index] != null)
            {
                weapons[current_Weapon_Index].HolsterWeapon();
            }

            weapons[weaponIndex].TakeWeapon();
            current_Weapon_Index = weaponIndex;
        }
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return weapons[current_Weapon_Index];
    }

    public int CurrentWeaponIndex
    {
        get
        {
            return current_Weapon_Index;
        }
    }
}
