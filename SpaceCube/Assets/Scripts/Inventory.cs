using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] items = new Item[6];
    [SerializeField] GameObject backpack;

    public void ReloadInventory()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(items[i] != null)
            {
                Spawn(items[i], i);
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
}
