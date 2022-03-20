using UnityEngine;
using UnityEngine.UI;

public class ScrollManager : MonoBehaviour
{
    private Inventory inventory;
    public Skills skills;

    [SerializeField] private Slot scroll;
    [SerializeField] private Slot chalk;
    public GameObject[] elements;
    private int elementsNumber;

    private GameObject currentScroll;

    public int probability;
    public Text probabilityText;

    private void Awake()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        skills = GameObject.FindGameObjectWithTag("Skills").GetComponent<Skills>();
    }

    public Slot ScrollSlot
    {
        get
        {
            return scroll;
        }
    }
    public Slot ChalkSlot
    {
        get
        {
            return chalk;
        }
    }

    public GameObject CurrentScroll
    {
        get
        {
            return currentScroll;
        }
    }

    private void Update()
    {
        if (scroll.Item.id != 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (scroll.Item.scroll.id == i)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                    currentScroll = transform.GetChild(i).gameObject;

                    for (int j = 0; j < currentScroll.transform.childCount; j++)
                    {
                        elementsNumber += 1;
                    }

                    elements = new GameObject[elementsNumber];
                    elementsNumber = 0;

                    for (int j = 0; j < elements.Length; j++)
                    {
                        elements[j] = currentScroll.transform.GetChild(j).gameObject;
                    }
                }
                else
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            if (scroll.Item.scroll.scrollDone)
            {
                inventory.alchemyCreateSlot.gameObject.SetActive(true);
                probabilityText.transform.parent.gameObject.SetActive(true);
                //color
                if (scroll.Item.scroll.probabilityCreate <= 100 && scroll.Item.scroll.probabilityCreate >= 0)
                {
                    probabilityText.text = scroll.Item.scroll.probabilityCreate.ToString() + "%";
                }
                if (scroll.Item.scroll.probabilityCreate <= 25)
                {
                    probabilityText.color = new Color32(255, 0, 0, 255); // Red
                }
                else if (scroll.Item.scroll.probabilityCreate <= 50 && scroll.Item.scroll.probabilityCreate > 25)
                {
                    probabilityText.color = new Color32(255, 165, 0, 255); // Orange
                }
                else if (scroll.Item.scroll.probabilityCreate <= 75 && scroll.Item.scroll.probabilityCreate > 50)
                {
                    probabilityText.color = new Color32(255, 255, 0, 255); // Yellow
                }
                else if (scroll.Item.scroll.probabilityCreate > 75)
                {
                    probabilityText.color = new Color32(0, 255, 0, 255); // Green
                }
                
                for (int i = 0; i < scroll.Item.scroll.partsOfItem.Length; i++)
                {
                    inventory.alchemyPartSlots[i].SetActive(true);
                    inventory.alchemyPartSlots[i].transform.GetChild(0).GetComponent<Slot>().SlotType = scroll.Item.scroll.partsOfItem[i].name;

                    if (scroll.Item.scroll.partsOfItem.Length == 1)
                    {
                        if (i == 0)
                        {
                            inventory.alchemyPartSlots[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -86);
                        }
                        if (inventory.alchemyPartInventory[0].Item.name == inventory.alchemyPartInventory[0].SlotType &&
                            inventory.alchemyPartInventory[1].Item.name == inventory.alchemyPartInventory[1].SlotType &&
                            inventory.alchemyPartInventory[2].Item.name == inventory.alchemyPartInventory[2].SlotType)
                        {
                            CompleteScroll();
                            CreateItem(1);
                        }
                    }
                    else if (scroll.Item.scroll.partsOfItem.Length == 2)
                    {

                    }
                    else if (scroll.Item.scroll.partsOfItem.Length == 3)
                    {
                        if (i == 0)
                        {
                            inventory.alchemyPartSlots[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 215);
                        }
                        else if (i == 1)
                        {
                            inventory.alchemyPartSlots[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-130, -11.5f);
                        }
                        else if (i == 2)
                        {
                            inventory.alchemyPartSlots[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(130, -11.5f);
                        }
                        if (inventory.alchemyPartInventory[0].Item.name == inventory.alchemyPartInventory[0].SlotType &&
                            inventory.alchemyPartInventory[1].Item.name == inventory.alchemyPartInventory[1].SlotType &&
                            inventory.alchemyPartInventory[2].Item.name == inventory.alchemyPartInventory[2].SlotType)
                        {
                            CompleteScroll();
                            CreateItem(6);
                            break;
                        }
                    }
                    else if (scroll.Item.scroll.partsOfItem.Length == 4)
                    {

                    }
                    else if (scroll.Item.scroll.partsOfItem.Length == 5)
                    {

                    }
                    else if (scroll.Item.scroll.partsOfItem.Length == 6)
                    {

                    }
                }
            }
            else
            {
                ReleaseSlots();
            }
        }
        else if (scroll.Item.id == 0 && currentScroll != null)
        {
            currentScroll.SetActive(false);
            probabilityText.transform.parent.gameObject.SetActive(false);
            currentScroll = null;
            ReleaseSlots();
        }
    }

    public void CompleteScroll()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            for (int j = 0; j < elements[i].transform.childCount; j++)
            {
                elements[i].transform.GetChild(j).GetComponent<ParticleSystem>().Play();
            }
        }
        GetComponent<AudioSource>().Play();
    }
    public void CreateItem(int length)
    {
        if (inventory.alchemyInventory[2].id == 0)
        {
            probability = Random.Range(0, 100);
            print(probability);
            for (int i = 3; i < length; i++)
            {
                inventory.alchemyInventory[i] = Database.itemList[0];
                if (i == length - 1 && probability <= scroll.Item.scroll.probabilityCreate && scroll.Item.scroll.probabilityCreate >= 0)
                {
                    inventory.alchemyInventory[2] = scroll.Item.scroll.createItem;
                    probability = -1;
                    skills.AddXP(currentScroll.GetComponent<AddXP>().NameSkill, currentScroll.GetComponent<AddXP>().XP);
                    return;
                }
                skills.AddXP(currentScroll.GetComponent<AddXP>().NameSkill, currentScroll.GetComponent<AddXP>().XP / 2);
            }
        }
    }
    public void ReleaseSlots()
    {
        for (int i = 2; i < inventory.alchemyInventory.Length; i++)
        {
            if (inventory.alchemySlots[i].transform.parent.gameObject.activeInHierarchy)
            {
                if (inventory.alchemySlots[i].Item.id != 0)
                {
                    for (int j = 0; j < inventory.inventorySlots.Length; j++)
                    {
                        if (inventory.inventorySlots[j].id == 0)
                        {
                            inventory.inventorySlots[j] = inventory.alchemyInventory[i];
                            inventory.alchemyInventory[i] = Database.itemList[0];
                        }
                    }
                }
                inventory.alchemySlots[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
