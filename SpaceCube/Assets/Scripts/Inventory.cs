using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[6];
    [SerializeField] Item starterCarrot;
    [SerializeField] Item starterWood;
    [SerializeField] GameObject backpack;

    void Start()
    {
        items[0] = Spawn(starterCarrot, 0);
        items[1] = Spawn(starterWood, 1);
        items[0].amount = 1;
        items[1].amount = 5;
    }

    public void ReloadInventory()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                if (items[i].amount <= 0)
                {
                    Destroy(items[i].gameObject);
                    items[i] = null;
                }
            }
        }
    }
    public Item Spawn(Item item, int i)
    {
        Item instance = Instantiate(item);
        instance.transform.position = new Vector2(i * 85 + 70, -75);
        instance.transform.SetParent(backpack.transform, false);
        return instance;
    }
    public void Collect(Farm farm)
    {
        bool contains = false;
        int index = 0;
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                if (items[i].product == farm.product.product)
                {
                    contains = true;
                    index = i;
                }
            }
        }
        switch (contains)
        {
            case true:
                ContainsItem(index, farm);
                break;
            case false:
                NewItem(farm);
                break;
        }
    }
    void ContainsItem(int index, Farm farm)
    {
        items[index].amount += farm.stock;
        farm.stock = 0;
    }
    void NewItem(Farm farm)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                Item instance = Spawn(farm.product, i);
                instance.amount = farm.stock;
                items[i] = instance;
                farm.stock = 0;
                break;
            }
        }
    }
}
