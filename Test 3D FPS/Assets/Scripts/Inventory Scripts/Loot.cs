using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] protected Item item;
    [SerializeField] protected int id;
    public bool droped;

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

    public int Id
    {
        get
        {
            return id;
        }
    }

    private void Start()
    {
        if (!droped)
        {
            item = Database.itemList[id];
        }
    }
}
