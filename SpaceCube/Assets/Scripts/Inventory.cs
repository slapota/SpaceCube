using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Image> items = new List<Image>();
    public List<Text> amounts = new List<Text>();
    [SerializeField] GameObject backpack;

    void Start()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Image instance = Instantiate(items[i]);
            instance.transform.position = new Vector2(i * 80 + 60, -60);
            instance.transform.SetParent(backpack.transform, false);
            amounts[i].text = instance.GetComponent<Item>().amount.ToString();
        }
    }
}
