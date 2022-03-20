using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour 
{
    protected Inventory inventory;
    protected Skills skills;

    [SerializeField] protected float health;
    [SerializeField] protected float armor;
    [SerializeField] protected string weaponTypeApply;
    [SerializeField] protected bool fireImmunity;
    [SerializeField] protected bool electricityImmunity;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        skills = GameObject.FindGameObjectWithTag("Skills").GetComponent<Skills>();
    }

    public virtual void ApplyDamage(float damage, string weaponType, string modifier, float modifierDamage)
    {
        if(weaponTypeApply == weaponType)
        {
            damage *= 10;
        }
        else if (weaponType == "Hammer" && GetComponent<ParticalSound>().Target_Type == "Stone")
        {
            damage *= 20;
        }
        else if(weaponTypeApply == "All")
        {
            damage *= 10;
        }

        if (!fireImmunity && modifier == "Fire")
        {
            health -= modifierDamage;
        }

        if (!electricityImmunity && modifier == "Electricity")
        {
            health -= modifierDamage;
        }

        inventory.characterInventory[inventory.gameObject.transform.parent.GetComponent<WeaponManager>().CurrentWeaponIndex].integrity -= damage;
        damage -= armor;

        if(damage > 0)
        {
            health -= damage;
        }
        if (inventory.characterInventory[inventory.gameObject.transform.parent.GetComponent<WeaponManager>().CurrentWeaponIndex].integrity <= 0)
        {
            inventory.characterInventory[inventory.gameObject.transform.parent.GetComponent<WeaponManager>().CurrentWeaponIndex] = Database.itemList[0];
            inventory.gameObject.GetComponent<AudioSource>().Play();
        }
        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        skills.AddXP(GetComponent<AddXP>().NameSkill, GetComponent<AddXP>().XP);

        if (!inventory.inventory_is_Full)
        {
            inventory.AddLoot(GetComponent<Loot>().Item);
        }
        else
        {
            print("Full");
            Instantiate(GetComponent<Loot>().Item.itemPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation, transform.parent);
        }

        Destroy(gameObject);
    }
}









































