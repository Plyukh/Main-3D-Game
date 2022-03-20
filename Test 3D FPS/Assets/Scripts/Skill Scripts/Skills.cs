using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public Image[] skillIcons;
    [SerializeField] private string[] nameSkill;
    public float[] xp;
    [SerializeField] private Slider[] xpBar;
    [SerializeField] private int[] lvl;
    [SerializeField] private float[] lvlXP;
    [SerializeField] private Text[] lvlText;

    private AddImage addItemImage;

    private void Awake()
    {
        addItemImage = GameObject.Find("AddItemImage").GetComponent<AddImage>();
    }

    private void Update()
    {
        for (int i = 0; i < nameSkill.Length; i++)
        {
            lvlText[i].text = lvl[i].ToString();
            xpBar[i].maxValue = lvlXP[i];
            xpBar[i].value = xp[i];
        }

        for (int i = 1; i < transform.parent.GetComponent<WeaponManager>().AllWeapons.Length; i++)
        {
            if (transform.parent.GetComponent<WeaponManager>().AllWeapons[i].gameObject.activeInHierarchy)
            {
                if (transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().WeaponType == "Sword")
                {
                    transform.parent.GetComponent<WeaponManager>().AllWeapons[i].GetComponent<Animator>().SetFloat("Attack Speed", transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().attack_Speed + 0.05f * lvl[0]);
                }
                if (transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().WeaponType == "Axe")
                {
                    transform.parent.GetComponent<WeaponManager>().AllWeapons[i].GetComponent<Animator>().SetFloat("Attack Speed", transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().attack_Speed + 0.05f * lvl[1]);
                }
                if (transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().WeaponType == "Pickaxe" || transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().WeaponType == "Hammer")
                {
                    transform.parent.GetComponent<WeaponManager>().AllWeapons[i].GetComponent<Animator>().SetFloat("Attack Speed", transform.parent.GetComponent<WeaponManager>().AllWeapons[i].attack_Point.GetComponent<AttackScript>().attack_Speed + 0.05f * lvl[2]);
                }
            }
        }
    }

    public void AddXP(string NameSkill, float XP)
    {
        for (int i = 0; i < nameSkill.Length; i++)
        {
            if(nameSkill[i] == NameSkill && lvl[i] < 10)
            {
                xp[i] += XP;

                if (xp[i] >= lvlXP[i])
                {
                    float bufetXP;

                    bufetXP = xp[i] - lvlXP[i];

                    lvl[i] += 1;
                    LvlUp(NameSkill);
                    lvlXP[i] += 25;

                    xp[i] = 0;
                    xp[i] += bufetXP;
                }
                if (lvl[i] == 10)
                {
                    xp[i] = 0;
                }

                addItemImage.AddXPImage(skillIcons[i], XP);
                break;
            }
        }
    }
    private void LvlUp(string NameSkill)
    {
        if (NameSkill == nameSkill[0])
        {

        }
        else if (NameSkill == nameSkill[1])
        {

        }
        else if (NameSkill == nameSkill[2])
        {

        }
        else if (NameSkill == nameSkill[3])
        {
            for (int i = 0; i < Database.scrollList.Count; i++)
            {
                Database.scrollList[i].probabilityCreate += 5;
            }
        }
    }
}
