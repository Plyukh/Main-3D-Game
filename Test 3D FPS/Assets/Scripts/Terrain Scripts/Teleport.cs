using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject teleportEnd;
    [SerializeField] GameObject effectPreffab;
    private GameObject player;
    [SerializeField] private bool canInteract;

    public bool CanInteract
    {
        get
        {
            return canInteract;
        }
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    public void TeleportOn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = teleportEnd.transform.position;
        player.GetComponent<CharacterController>().enabled = true;
        Instantiate(effectPreffab, teleportEnd.transform.position, teleportEnd.transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TeleportOn();
        }
    }
}
