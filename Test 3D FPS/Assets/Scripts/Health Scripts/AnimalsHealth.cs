using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsHealth : HealthScript
{
    [SerializeField] private GameObject destroyPrefab;
    public override void Death()
    {
        if (destroyPrefab != null)
        {
            Instantiate(destroyPrefab, gameObject.transform.position, gameObject.transform.rotation, gameObject.transform.parent);
        }

        skills.AddXP(GetComponent<AddXP>().NameSkill, GetComponent<AddXP>().XP);
        Destroy(gameObject);
    }
}
