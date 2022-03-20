using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour
{
    private Inventory inventory;

    [SerializeField] private Image cursorImagePrefab;
    private Image dragImage;

    [SerializeField] private Image[] enterImages;
    public Vector3 position;

    public Slot dragSlot;
    public Slot pointerSlot;

    private Color32 baseColor = new Color32(233, 233, 233, 255);
    private Color32 characterBaseColor = new Color32(255,225,125,255);
    private Color32 enterColor = new Color32(210, 210, 210, 255);
    private Color32 dragColor = new Color32(150,150,150,255);
    private Color32 applyColor = new Color32(60,225,60,255);

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void StartDrag(Slot Slot)
    {
        if (dragSlot == null)
        {
            if (Slot.Item.id != 0)
            {
                Instantiate(cursorImagePrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity, gameObject.transform);
                dragImage = GameObject.FindWithTag("CursorImage").GetComponent<Image>();
                dragImage.sprite = Slot.Item.itemSprite;
                dragSlot = Slot;
            }
        }
    }

    public void Drag()
    {
        if (dragSlot != null)
        {
            dragImage.transform.position = Input.mousePosition;
            if (dragSlot.SlotType == "None")
            {
                dragSlot.transform.parent.GetComponent<Image>().color = dragColor;
            }

            for (int i = 0; i < inventory.characterInventory.Length; i++)
            {
                if (inventory.characterSlots[i].SlotType == dragSlot.Item.itemType)
                {
                    inventory.characterSlots[i].transform.parent.GetComponent<Image>().color = applyColor;
                }
            }

            for (int i = 0; i < enterImages.Length; i++)
            {
                if (enterImages[i].gameObject.activeInHierarchy)
                {
                    enterImages[i].gameObject.SetActive(false);
                }
            }
        }
    }

    public void EndDrag()
    {
        if (dragImage != null)
        {
            if (pointerSlot != null && dragSlot != null)
            {
                if(dragSlot.Item.itemType == pointerSlot.SlotType)
                {
                    if (dragSlot.SlotType == pointerSlot.SlotType)
                    {
                        inventory.characterInventory[pointerSlot.SlotId] = dragSlot.Item;
                        inventory.characterInventory[dragSlot.SlotId] = pointerSlot.Item;
                    }
                    else
                    {
                        if(pointerSlot.SlotType == "Scroll" || pointerSlot.SlotType == "Chalk")
                        {
                            inventory.alchemyInventory[pointerSlot.SlotId] = dragSlot.Item;
                            inventory.inventorySlots[dragSlot.SlotId] = pointerSlot.Item;
                        }
                        else
                        {
                            inventory.characterInventory[pointerSlot.SlotId] = dragSlot.Item;
                            inventory.inventorySlots[dragSlot.SlotId] = pointerSlot.Item;
                        }
                        //none/weapon - weapon
                    }
                }

                else if (dragSlot.Item.name == pointerSlot.SlotType)
                {
                    if(dragSlot.SlotType == "None")
                    {
                        inventory.alchemyInventory[pointerSlot.SlotId] = dragSlot.Item;
                        inventory.inventorySlots[dragSlot.SlotId] = pointerSlot.Item;
                    }
                    else
                    {
                        inventory.alchemyInventory[pointerSlot.SlotId] = dragSlot.Item;
                        inventory.alchemyInventory[dragSlot.SlotId] = pointerSlot.Item;
                    }
                }

                else
                {
                    if (dragSlot.SlotType != "None" && pointerSlot.SlotType == "None")
                    {
                        if(pointerSlot.Item.name == dragSlot.Item.name)
                        {
                            if (dragSlot.SlotType == "Scroll" || dragSlot.SlotType == "Chalk" ||
                                dragSlot.SlotType == "Create" || dragSlot.SlotType == dragSlot.Item.name)
                            {
                                inventory.inventorySlots[pointerSlot.SlotId] = dragSlot.Item;
                                inventory.alchemyInventory[dragSlot.SlotId] = pointerSlot.Item;
                            }
                            else
                            {
                                inventory.inventorySlots[pointerSlot.SlotId] = dragSlot.Item;
                                inventory.characterInventory[dragSlot.SlotId] = pointerSlot.Item;
                            }
                        }
                        else if (pointerSlot.Item.itemType == dragSlot.Item.itemType || pointerSlot.Item.id == 0)
                        {
                            if (dragSlot.SlotType == "Scroll" || dragSlot.SlotType == "Chalk" ||
                            dragSlot.SlotType == "Create" || dragSlot.SlotType == dragSlot.Item.name)
                            {
                                inventory.inventorySlots[pointerSlot.SlotId] = dragSlot.Item;
                                inventory.alchemyInventory[dragSlot.SlotId] = pointerSlot.Item;
                            }
                            else
                            {
                                inventory.inventorySlots[pointerSlot.SlotId] = dragSlot.Item;
                                inventory.characterInventory[dragSlot.SlotId] = pointerSlot.Item;
                            }
                        }
                        else
                        {
                            if (dragSlot.SlotType == "Scroll" || dragSlot.SlotType == "Chalk" ||
                            dragSlot.SlotType == "Create" || dragSlot.SlotType == dragSlot.Item.name)
                            {
                                inventory.alchemyInventory[dragSlot.SlotId] = dragSlot.Item;
                            }
                            else
                            {
                                inventory.characterInventory[dragSlot.SlotId] = dragSlot.Item;
                            }
                        }
                        //weapon - none
                    }

                    else if (dragSlot.SlotType == pointerSlot.SlotType)
                    {
                        inventory.inventorySlots[pointerSlot.SlotId] = dragSlot.Item;
                        inventory.inventorySlots[dragSlot.SlotId] = pointerSlot.Item;
                        //none - none
                    }

                    else
                    {
                        if (dragSlot.SlotType == "None")
                        {
                            inventory.inventorySlots[dragSlot.SlotId] = dragSlot.Item;
                        }
                        else
                        {
                            if (dragSlot.SlotType == "Scroll" || dragSlot.SlotType == "Chalk" ||
                            dragSlot.SlotType == "Create" || dragSlot.SlotType == dragSlot.Item.name)
                            {
                                inventory.alchemyInventory[dragSlot.SlotId] = dragSlot.Item;
                            }
                            else
                            {
                                inventory.characterInventory[dragSlot.SlotId] = dragSlot.Item;
                            }
                        }
                        //weapon !- weapon
                    }
                }
            }
            else
            {
                GameObject dropTarget = inventory.transform.GetChild(0).gameObject;
                dragSlot.Item.itemPrefab.GetComponent<Loot>().Item = dragSlot.Item;
                Instantiate(dragSlot.Item.itemPrefab, new Vector3(dropTarget.transform.position.x, dropTarget.transform.position.y, dropTarget.transform.position.z), inventory.transform.rotation, inventory.transform.parent.parent);
                
                Collider[] hitColliders = Physics.OverlapSphere(dropTarget.transform.position, 0.1f, LayerMask.GetMask("Items"));
                hitColliders[0].GetComponent<Loot>().droped = true;
                hitColliders[0].GetComponent<Loot>().Item = dragSlot.Item;

                GetComponent<AudioSource>().Play();
                if(dragSlot.SlotType == "None")
                {
                    inventory.inventorySlots[dragSlot.SlotId] = Database.itemList[0];
                }
                else
                {
                    if (dragSlot.SlotType == "Scroll" || dragSlot.SlotType == "Chalk" ||
                        dragSlot.SlotType == "Create" || dragSlot.SlotType == dragSlot.Item.name)
                    {
                        inventory.alchemyInventory[dragSlot.SlotId] = Database.itemList[0];
                    }
                    else
                    {
                        inventory.characterInventory[dragSlot.SlotId] = Database.itemList[0];
                    }
                }
                //drop
            }

            if (dragSlot.SlotType == "None" || dragSlot.SlotType == "Chalk" || dragSlot.SlotType == "Scroll")
            {
                dragSlot.transform.parent.GetComponent<Image>().color = baseColor;
            }
            for (int i = 0; i < inventory.characterSlots.Length; i++)
            {
                inventory.characterSlots[i].transform.parent.GetComponent<Image>().color = characterBaseColor;
            }

            dragSlot = null;
            Destroy(dragImage.gameObject);
        }
    }

    public void PointerEnter(Slot Slot)
    {
        pointerSlot = Slot;
        if (Slot.Item.id != 0)
        {
            if (Slot.Item.itemType == "Weapon")
            {
                enterImages[0].gameObject.SetActive(true);
                enterImages[0].transform.position = Slot.transform.position + position;

                enterImages[0].gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Slot.Item.name; // Name
                enterImages[0].gameObject.transform.GetChild(1).GetComponent<Text>().text = Slot.Item.description; // Description
                enterImages[0].gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().text = (Slot.Item.integrity / Slot.Item.integrityMax * 100).ToString() + "%"; // Integrity
                enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().maxValue = 100;
                enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value = Slot.Item.integrity / Slot.Item.integrityMax * 100;

                //color
                if (enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value <= 25)
                {
                    enterImages[0].gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 0, 0, 255); // Red
                }
                else if (enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value <= 50 && enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value > 25)
                {
                    enterImages[0].gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 165, 0, 255); // Orange
                }
                else if (enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value <= 75 && enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value > 50)
                {
                    enterImages[0].gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color32(255, 255, 0, 255); // Yellow
                }
                else if (enterImages[0].gameObject.transform.GetChild(3).GetComponent<Slider>().value > 75)
                {
                    enterImages[0].gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 255, 0, 255); // Green
                }
            }
            else if (Slot.Item.itemType == "Note")
            {
                enterImages[1].gameObject.SetActive(true);
                enterImages[1].transform.position = Slot.transform.position + position;

                enterImages[1].gameObject.transform.GetChild(1).GetComponent<Text>().text = Slot.Item.description; // Description
            }
            else if (Slot.Item.itemType != "None")
            {
                enterImages[2].gameObject.SetActive(true);
                enterImages[2].transform.position = Slot.transform.position + position;

                enterImages[2].gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = Slot.Item.name; // Name
                enterImages[2].gameObject.transform.GetChild(1).GetComponent<Text>().text = Slot.Item.description; // Description
            }
        }
        else
        {
            for (int i = 0; i < enterImages.Length; i++)
            {
                if (enterImages[i].gameObject.activeInHierarchy)
                {
                    enterImages[i].gameObject.SetActive(false);
                }
            }
        }

        if (Slot.SlotType == "None")
        {
            Slot.transform.parent.GetComponent<Image>().color = enterColor;
        }
    }

    public void PointerExit()
    {
        if (pointerSlot.SlotType == "None")
        {
            pointerSlot.transform.parent.GetComponent<Image>().color = baseColor;

            for (int i = 0; i < enterImages.Length; i++)
            {
                if (enterImages[i].gameObject.activeInHierarchy)
                {
                    enterImages[i].gameObject.SetActive(false);
                }
            }
        }
        pointerSlot = null;
    }
}
