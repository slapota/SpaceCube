using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public string product;
    public int amount;
    public Text text;
    public Sprite image;
    public int buyPrice;
    public int sellPrice;

    void Update()
    {
        text.text = amount.ToString();
    }
}
