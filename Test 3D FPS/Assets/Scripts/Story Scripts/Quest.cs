using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] objectsRemove;
    [SerializeField] private GameObject[] objectsSetActive;
    [SerializeField] private EnemyController[] enemies;
    [SerializeField] private bool canInteract;

    public bool CanInteract
    {
        get
        {
            return canInteract;
        }
    }

    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetSleep();
        }
        TakeBook();
    }

    public void TakeBook()
    {
        for (int i = 0; i < objectsRemove.Length; i++)
        {
            Destroy(objectsRemove[i]);
        }
        for (int i = 0; i < objectsSetActive.Length; i++)
        {
            objectsSetActive[i].SetActive(true);
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetUp();
        }
        player.GetComponent<OpenUI>().enabled = true;
        Destroy(gameObject);
    }
}
