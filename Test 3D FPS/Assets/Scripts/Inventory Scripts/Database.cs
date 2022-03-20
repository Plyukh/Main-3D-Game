using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static List<Item> itemList = new List<Item>();
    public static List<Scroll> scrollList = new List<Scroll>();

    void Awake()
    {
        //items
        itemList.Add(new Item( 0, "None", "None", "None", Resources.Load<Sprite>("None"), Resources.Load<GameObject>("GameObjects/None")));
        itemList.Add(new Item(1, "Iron Axe", "Weapon", "A tool for cutting trees. Made of wood and iron.", Resources.Load<Sprite>("Sprites/Iron Axe"), Resources.Load<GameObject>("GameObjects/Iron Axe"), 1000));
        itemList.Add(new Item(2, "Iron Pickaxe", "Weapon", "A tool for mining ore. Made of wood and iron.", Resources.Load<Sprite>("Sprites/Iron Pickaxe"), Resources.Load<GameObject>("GameObjects/Iron Pickaxe"), 100));
        itemList.Add(new Item(3, "Iron Hammer", "Weapon", "A tool for mining stone. Made of wood and iron.", Resources.Load<Sprite>("Sprites/Iron Hammer"), Resources.Load<GameObject>("GameObjects/Iron Hammer"), 100));
        itemList.Add(new Item(4, "Iron Sword", "Weapon", "", Resources.Load<Sprite>("Sprites/Iron Sword"), Resources.Load<GameObject>("GameObjects/Iron Sword"), 100));
        itemList.Add(new Item(5, "Golden Axe", "Weapon", "", Resources.Load<Sprite>("Sprites/Golden Axe"), Resources.Load<GameObject>("GameObjects/Golden Axe"), 200));
        itemList.Add(new Item(6, "Golden Pickaxe", "Weapon", "", Resources.Load<Sprite>("Sprites/Golden Pickaxe"), Resources.Load<GameObject>("GameObjects/Golden Pickaxe"), 20));
        itemList.Add(new Item(7, "Golden Hammer", "Weapon", "", Resources.Load<Sprite>("Sprites/Golden Hammer"), Resources.Load<GameObject>("GameObjects/Golden Hammer"), 20));
        itemList.Add(new Item(8, "Golden Sword", "Weapon", "", Resources.Load<Sprite>("Sprites/Golden Sword"), Resources.Load<GameObject>("GameObjects/Golden Sword"), 20));
        itemList.Add(new Item(9, "Bomb", "Weapon", "", Resources.Load<Sprite>("Sprites/Bomb"), Resources.Load<GameObject>("GameObjects/Bomb")));
        itemList.Add(new Item(10, "Gold", "Resource", "Very soft metal, comparable to the hardness of the fingernail. Has high electrical conductivity.", Resources.Load<Sprite>("Sprites/Gold"), Resources.Load<GameObject>("GameObjects/Gold")));
        itemList.Add(new Item(11, "Iron", "Resource", "", Resources.Load<Sprite>("Sprites/Iron"), Resources.Load<GameObject>("GameObjects/Iron")));
        itemList.Add(new Item(12, "Sulfur", "Resource", "", Resources.Load<Sprite>("Sprites/Sulfur"), Resources.Load<GameObject>("GameObjects/Sulfur")));
        itemList.Add(new Item(13, "Saltpeter", "Resource", "", Resources.Load<Sprite>("Sprites/Saltpeter"), Resources.Load<GameObject>("GameObjects/Saltpeter")));
        itemList.Add(new Item(14, "Stone", "Resource", "", Resources.Load<Sprite>("Sprites/Stone"), Resources.Load<GameObject>("GameObjects/Stone")));
        itemList.Add(new Item(15, "Wood", "Resource", "", Resources.Load<Sprite>("Sprites/Wood"), Resources.Load<GameObject>("GameObjects/Wood")));
        itemList.Add(new Item(16, "Mask", "Hat", "", Resources.Load<Sprite>("Sprites/Mask"), Resources.Load<GameObject>("GameObjects/Mask")));
        itemList.Add(new Item(17, "Book", "Scroll", "", Resources.Load<Sprite>("Sprites/Book"), Resources.Load<GameObject>("GameObjects/Book")));
        itemList.Add(new Item(18, "Crystal Thermo", "Resource", "", Resources.Load<Sprite>("Sprites/Crystal Thermo"), Resources.Load<GameObject>("GameObjects/Crystal Thermo")));
        itemList.Add(new Item(19, "Crystal Electro", "Resource", "", Resources.Load<Sprite>("Sprites/Crystal Electro"), Resources.Load<GameObject>("GameObjects/Crystal Electro")));

        //scrolls
        scrollList.Add(new Scroll(0, itemList[1], itemList[15], itemList[11], itemList[11], 50));
        scrollList.Add(new Scroll(1, itemList[2], itemList[15], itemList[11], itemList[11], 50));
        scrollList.Add(new Scroll(2, itemList[3], itemList[15], itemList[11], itemList[11], 50));

        //item-scroll
        itemList.Add(new Item(20, "Scroll", "Scroll", "", Resources.Load<Sprite>("Sprites/Scroll Axe"), Resources.Load<GameObject>("GameObjects/Scroll Axe"), scrollList[0]));
        itemList.Add(new Item(21, "Scroll", "Scroll", "", Resources.Load<Sprite>("Sprites/Scroll Pickaxe"), Resources.Load<GameObject>("GameObjects/Scroll Pickaxe"), scrollList[1]));
        itemList.Add(new Item(22, "Scroll", "Scroll", "", Resources.Load<Sprite>("Sprites/Scroll Hammer"), Resources.Load<GameObject>("GameObjects/Scroll Hammer"), scrollList[2]));
        itemList.Add(new Item(23, "Boots-Runners", "Boots", "Legendary shoes. Wearing shoes makes it possible to move at high speed.", Resources.Load<Sprite>("Sprites/Boots-Runners"), Resources.Load<GameObject>("GameObjects/Boots-Runners")));
    }
}