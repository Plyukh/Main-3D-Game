using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsSlot : MonoBehaviour
{
    private Item bootsItem;
    private PlayerSprintAndCrouch playerSprint;

    private void Awake()
    {
        playerSprint = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSprintAndCrouch>();
    }

    private void Update()
    {
        bootsItem = GetComponent<Slot>().Item;

        if (bootsItem.name == "Boots-Runners")
        {
            playerSprint.move_Speed = playerSprint.move_Speed_Base * 2;
            playerSprint.sprint_Speed = playerSprint.sprint_Speed_Base * 2;
            playerSprint.crouch_Speed = playerSprint.crouch_Speed_Base * 2;
        }
        else
        {
            bootsItem = Database.itemList[0];
            playerSprint.move_Speed = playerSprint.move_Speed_Base;
            playerSprint.sprint_Speed = playerSprint.sprint_Speed_Base;
            playerSprint.crouch_Speed = playerSprint.crouch_Speed_Base;
        }
    }
}
