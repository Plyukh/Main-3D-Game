using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : HealthScript
{
    public float maxHealth;
    public float percentHealth;
    [SerializeField] private Image helthImage;
    [SerializeField] private Image healthPanel;

    private void Update()
    {
        percentHealth = health / maxHealth * 100;

        if (percentHealth <= 25)
        {
            helthImage.color = new Color32(125, 0, 0, 255); // Red
        }
        else if (percentHealth <= 50 && percentHealth > 25)
        {
            helthImage.color = new Color32(125, 75, 0, 255); // Orange
        }
        else if (percentHealth <= 75 && percentHealth > 50)
        {
            helthImage.color = new Color32(125, 125, 0, 255); // Yellow
        }
        else if (percentHealth > 75)
        {
            helthImage.color = new Color32(0, 125, 0, 255); // Green
        }
    }

    public override void ApplyDamage(float damage, string weaponType, string modifier, float modifierDamage)
    {
        StartCoroutine(SizeImage());
        Camera.main.GetComponent<Animator>().SetTrigger("Shake");
        if (weaponTypeApply == weaponType)
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

        damage -= armor;

        if (damage > 0)
        {
            health -= damage;
        }
        if (health <= 0)
        {
            Death();
        }
    }

    public override void Death()
    {
        print("Player DEAD");
    }

    IEnumerator SizeImage()
    {
        healthPanel.color = new Color32(255,0,0,50);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            helthImage.rectTransform.localScale += new Vector3(0.01f, 0.01f);
            healthPanel.color -= new Color32(0, 0, 0, 5);
        }
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.01f);
            helthImage.rectTransform.localScale -= new Vector3(0.01f, 0.01f);
        }
    }
}
