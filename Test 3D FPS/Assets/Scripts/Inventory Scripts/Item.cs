using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Item
{
    public int id;
    public string name;
    public string description;
    public Sprite itemSprite;
    public string itemType;
    public GameObject itemPrefab;
    public Scroll scroll;
    public float integrityMax;
    public float integrity;

    public Item(int Id, string Name, string ItemType, string Description, Sprite ItemSprite, GameObject ItemPrefab)
    {
        id = Id;
        name = Name;
        itemType = ItemType;
        description = Description;
        itemSprite = ItemSprite;
        itemPrefab = ItemPrefab;

        scroll = null;
        integrityMax = 0;
        integrity = 0;

    }
    public Item(int Id, string Name, string ItemType, string Description, Sprite ItemSprite, GameObject ItemPrefab, float IntegrityMax)
    {
        id = Id;
        name = Name;
        itemType = ItemType;
        description = Description;
        itemSprite = ItemSprite;
        itemPrefab = ItemPrefab;
        integrityMax = IntegrityMax;
        integrity = IntegrityMax;

        scroll = null;
    }
    public Item(int Id, string Name, string ItemType, string Description, Sprite ItemSprite, GameObject ItemPrefab, Scroll Scroll)
    {
        id = Id;
        name = Name;
        itemType = ItemType;
        description = Description;
        itemSprite = ItemSprite;
        itemPrefab = ItemPrefab;
        scroll = Scroll;

        integrityMax = 0;
        integrity = 0;
    }
}
