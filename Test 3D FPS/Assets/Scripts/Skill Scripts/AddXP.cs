using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum NameSkill
{
    Combat,
    Chopping,
    Mining,
    Alchemy
}
public class AddXP : MonoBehaviour
{
    [SerializeField] private NameSkill nameSkill;
    [SerializeField] private float xp;

    public string NameSkill
    {
        get
        {
            return nameSkill.ToString();
        }
    }

    public float XP
    {
        get
        {
            return xp;
        }
    }
}
