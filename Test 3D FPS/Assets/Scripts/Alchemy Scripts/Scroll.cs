using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll
{
    public int id;
    public Item createItem;
    public Item[] partsOfItem;
    public bool scrollDone;
    public int probabilityCreate;
    public Scroll(int Id, Item CreateItem, Item part_1, int ProbabilityCreate)
    {
        id = Id;
        createItem = CreateItem;
        partsOfItem = new Item[1];
        partsOfItem[0] = part_1;
        probabilityCreate = ProbabilityCreate;
    }
    public Scroll(int Id, Item CreateItem, Item part_1, Item part_2, int ProbabilityCreate)
    {
        id = Id;
        createItem = CreateItem;
        partsOfItem = new Item[2];
        partsOfItem[0] = part_1;
        partsOfItem[1] = part_2;
        probabilityCreate = ProbabilityCreate;
    }
    public Scroll(int Id, Item CreateItem, Item part_1, Item part_2, Item part_3, int ProbabilityCreate)
    {
        id = Id;
        createItem = CreateItem;
        partsOfItem = new Item[3];
        partsOfItem[0] = part_1;
        partsOfItem[1] = part_2;
        partsOfItem[2] = part_3;
        probabilityCreate = ProbabilityCreate;
    }
    public Scroll(int Id, Item CreateItem, Item part_1, Item part_2, Item part_3, Item part_4, int ProbabilityCreate)
    {
        id = Id;
        createItem = CreateItem;
        partsOfItem = new Item[4];
        partsOfItem[0] = part_1;
        partsOfItem[1] = part_2;
        partsOfItem[2] = part_3;
        partsOfItem[3] = part_4;
        probabilityCreate = ProbabilityCreate;
    }
    public Scroll(int Id, Item CreateItem, Item part_1, Item part_2, Item part_3, Item part_4, Item part_5, int ProbabilityCreate)
    {
        id = Id;
        createItem = CreateItem;
        partsOfItem = new Item[5];
        partsOfItem[0] = part_1;
        partsOfItem[1] = part_2;
        partsOfItem[2] = part_3;
        partsOfItem[3] = part_4;
        partsOfItem[4] = part_5;
        probabilityCreate = ProbabilityCreate;
    }
    public Scroll(int Id, Item CreateItem, Item part_1, Item part_2, Item part_3, Item part_4, Item part_5, Item part_6, int ProbabilityCreate)
    {
        id = Id;
        createItem = CreateItem;
        partsOfItem = new Item[6];
        partsOfItem[0] = part_1;
        partsOfItem[1] = part_2;
        partsOfItem[2] = part_3;
        partsOfItem[3] = part_4;
        partsOfItem[4] = part_5;
        partsOfItem[5] = part_6;
        probabilityCreate = ProbabilityCreate;
    }
}
