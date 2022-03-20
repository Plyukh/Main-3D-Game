using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TargetType
{
    Tree,
    Stone,
    Ore,
    Animal,
    Player,
    MagicObject
}

public class ParticalSound : MonoBehaviour
{
    [SerializeField] private TargetType targetType;
    [SerializeField] private GameObject[] effects;

    public string Target_Type
    {
        get
        {
            return targetType.ToString();
        }
    } 

    public void TakeEffect(GameObject target, string weaponType)
    {
        if (targetType == TargetType.Tree)
        {
            if(weaponType == "Axe")
            {
                Effect(effects[0], target);
            }
            else if(weaponType == "Sword")
            {
                Effect(effects[1], target);
            }
            else
            {
                Effect(effects[2], target);
            }
        }
        else if (targetType == TargetType.Stone)
        {
            if (weaponType == "Pickaxe")
            {
                Effect(effects[0], target);
            }
            else if(weaponType == "Sword")
            {
                Effect(effects[1], target);
            }
            else if (weaponType == "Hammer")
            {
                Effect(effects[2], target);
            }
            else
            {
                Effect(effects[3], target);
            }
        }
        else if (targetType == TargetType.Ore)
        {
            if (weaponType == "Pickaxe")
            {
                Effect(effects[0], target);
            }
            else if (weaponType == "Sword")
            {
                Effect(effects[1], target);
            }
            else
            {
                Effect(effects[2], target);
            }
        }
        else if (targetType == TargetType.Animal)
        {
            if (weaponType == "Axe")
            {
                Effect(effects[0], target);
            }
            else if(weaponType == "Sword")
            {
                Effect(effects[1], target);
            }
            else if(weaponType == "Hammer")
            {
                Effect(effects[2], target);
            }
            else if(weaponType == "Pickaxe")
            {
                Effect(effects[3], target);
            }
        }
        else if (targetType == TargetType.Player)
        {
            Effect(effects[0], target);
        }
        else if (targetType == TargetType.MagicObject)
        {
            Effect(effects[0], target);
        }
    }

    void Effect(GameObject effect, GameObject target)
    {
        Instantiate(effect, target.transform.position, target.transform.rotation, gameObject.transform.parent);
    }
}
