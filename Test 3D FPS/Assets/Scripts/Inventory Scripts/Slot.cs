using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private string slotType;
     private int slotId;
    [SerializeField] private Item item;

    public Item Item
    {
        get
        {
            return item;
        }
        set
        {
            item = value;
        }
    }

    public int SlotId
    {
        get
        {
            return slotId;
        }
        set
        {
            slotId = value;
        }
    }

    public string SlotType
    {
        get
        {
            return slotType;
        }
        set
        {
            slotType = value;
        }
    }
}
