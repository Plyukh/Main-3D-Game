using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] private string weaponType;
    [SerializeField] private string modifier;
    [SerializeField] private float damage;
    public float attack_Speed;
    [SerializeField] private float modifierDamage;

    [SerializeField] private float distance;
    [SerializeField] private GameObject targetEffect;

    [SerializeField] private LayerMask layerMask;

    private WeaponManager weaponManager;

    public string WeaponType
    {
        get
        {
            return weaponType;
        }
    }

    private void Awake()
    {
        if(layerMask != LayerMask.GetMask("Player"))
        {
            weaponManager = GameObject.Find("Player").GetComponent<WeaponManager>();
        }
    }

    void FixedUpdate()
    {
        RaycastHit hits;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hits, distance, layerMask))
        {
            if (weaponManager != null)
            {
                weaponManager.GetCurrentSelectedWeapon().ApplyDamage();
            }

            if (hits.collider.GetComponent<HealthScript>() != null)
            {
                hits.collider.GetComponent<HealthScript>().ApplyDamage(damage, weaponType, modifier, modifierDamage);
            }

            if (hits.collider.GetComponent<ParticalSound>() != null)
            {
                hits.collider.GetComponent<ParticalSound>().TakeEffect(targetEffect, weaponType);
            }

            gameObject.SetActive(false);
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * distance, Color.red);
    }
}
