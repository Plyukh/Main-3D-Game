using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] inventorySlots = new Item[25];
    public Slot[] slots = new Slot[25];

    public Item[] characterInventory = new Item[7];
    public Slot[] characterSlots = new Slot[7];

    public Item[] weaponInventory = new Item[4];
    public Item[] armorInventory = new Item[3];

    public Item[] alchemyInventory = new Item[9];
    public Slot[] alchemySlots = new Slot[9];

    public GameObject alchemyCreateSlot;
    public GameObject[] alchemyPartSlots = new GameObject[6];
    public Slot[] alchemyPartInventory = new Slot[6];

    public bool inventory_is_Full;

    private AddImage addItemImage;

    private void Awake()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            slots[i].SlotId = i;
        }
        for (int i = 0; i < characterInventory.Length; i++)
        {
            characterSlots[i].SlotId = i;
        }
        for (int i = 0; i < alchemyInventory.Length; i++)
        {
            alchemySlots[i].SlotId = i;
        }

        addItemImage = GameObject.Find("AddItemImage").GetComponent<AddImage>();
    }

    private void Update()
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            slots[i].GetComponent<Image>().sprite = inventorySlots[i].itemSprite;
            slots[i].Item = inventorySlots[i];

            if (inventorySlots[i].id == 0)
            {
                slots[i].GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                slots[i].GetComponent<CanvasGroup>().alpha = 1;
            }
            if (!slots[i].gameObject.activeInHierarchy)
            {
                slots[i].transform.parent.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }

        for (int i = 0; i < characterInventory.Length; i++)
        {
            characterSlots[i].GetComponent<Image>().sprite = characterInventory[i].itemSprite;
            characterSlots[i].Item = characterInventory[i];

            if (characterInventory[i].id == 0)
            {
                characterSlots[i].GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                characterSlots[i].GetComponent<CanvasGroup>().alpha = 1;
            }
            if (!characterSlots[i].gameObject.activeInHierarchy)
            {
                characterSlots[i].transform.parent.GetComponent<Image>().color = new Color32(255, 225, 125, 255);
            }

            if (i < 2)
            {
                weaponInventory[i] = characterInventory[i];
            }
            else
            {
                for (int j = 0; j < armorInventory.Length; j++)
                {
                    armorInventory[j] = characterInventory[i];
                }
            }
        }

        for (int i = 0; i < alchemyInventory.Length; i++)
        {
            alchemySlots[i].GetComponent<Image>().sprite = alchemyInventory[i].itemSprite;
            alchemySlots[i].Item = alchemyInventory[i];

            if (alchemyInventory[i].id == 0)
            {
                alchemySlots[i].GetComponent<CanvasGroup>().alpha = 0;
            }
            else
            {
                alchemySlots[i].GetComponent<CanvasGroup>().alpha = 1;
            }
            if (!alchemySlots[i].gameObject.activeInHierarchy)
            {
                alchemySlots[i].transform.parent.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
            }

            if (i == 2)
            {
                alchemyCreateSlot = alchemySlots[i].transform.parent.gameObject;
            }
            else if (i > 2)
            {
                for (int j = 0; j < alchemyPartSlots.Length; j++)
                {
                    if(alchemyPartSlots[j] == null)
                    {
                        alchemyPartSlots[j] = alchemySlots[i].transform.parent.gameObject;
                        alchemyPartInventory[j] = alchemySlots[i];
                        break;
                    }
                }
            }
        }
    }

    public void AddLoot(Item loot)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].id == 0)
            {
                inventorySlots[i] = loot;
                addItemImage.AddLootImage(loot);
                inventory_is_Full = false;
                break;
            }
            inventory_is_Full = true;
        }
    }
    public void TakeEweyLoot(int id, ref bool trigger)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].id == id)
            {
                inventorySlots[i] = Database.itemList[0];
                addItemImage.TakeEweyLootImage(id);
                trigger = true;
                break;
            }
        }
    }
}
