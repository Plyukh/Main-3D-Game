using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesHealth : HealthScript
{
    [SerializeField] private GameObject destroyPrefab;
    public override void Death()
    {
        if(destroyPrefab != null)
        {
            destroyPrefab.transform.localScale = transform.localScale;
            Instantiate(destroyPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.parent);
        }

        skills.AddXP(GetComponent<AddXP>().NameSkill, GetComponent<AddXP>().XP);

        if (!inventory.inventory_is_Full)
        {
            inventory.AddLoot(GetComponent<Loot>().Item);
        }
        else
        {
            print("Full");
            Instantiate(GetComponent<Loot>().Item.itemPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation , transform.parent);
        }

        Destroy(gameObject);
    }
}
