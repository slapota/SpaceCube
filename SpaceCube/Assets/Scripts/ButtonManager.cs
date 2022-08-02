using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Player player;
    public GameObject buildMenu, gameView, shop, shopMenu;
    public Slider slider;
    Item itemShop;
    public Text shopText, sellPrice, buyPrice;
    public Build build;
    public Image itemImage;
    [SerializeField] Inventory inventory;

    void Start()
    {
        CloseBuildMenu();
        CloseShop();
    }
    public void OpenBuildMenu()
    {
        Time.timeScale = 0;
        buildMenu.SetActive(true);
        gameView.SetActive(false);
    }
    public void CloseBuildMenu()
    {
        Time.timeScale = 1;
        gameView.SetActive(true);
        buildMenu.SetActive(false);
    }
    public void BuildFarm(Farm farm)
    {
        bool enoughItems = false;
        int itemIndex = 0;
        bool enoughWood = false;
        int woodIndex = 0;
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if(inventory.items[i] == null)
            {
                continue;
            }
            if (inventory.items[i].product == farm.product.product)
            {
                enoughItems = true;
                itemIndex = i;
            }else if(inventory.items[i].product == "Wood")
            {
                if (inventory.items[i].amount >= farm.wood_needed)
                {
                    enoughWood = true;
                    woodIndex = i;
                }
            }
        }
        if(enoughItems && enoughWood)
        {
            build.building = farm.gameObject;
            inventory.items[itemIndex].amount -= 1;
            inventory.items[woodIndex].amount -= farm.wood_needed;
            inventory.ReloadInventory();
            CloseBuildMenu();
        }
    }
    public void OpenShop(Item item)
    {
        itemShop = item;
        shop.SetActive(false);
        shopMenu.SetActive(true);
        itemImage.sprite = item.image;
        sellPrice.text = (slider.value * item.sellPrice).ToString();
        buyPrice.text = (slider.value * item.buyPrice).ToString();
    }
    public void CloseShop()
    {
        shop.SetActive(true);
        shopMenu.SetActive(false);
    }
    public void Slider(Slider slider)
    {
        shopText.text = slider.value.ToString();
        sellPrice.text = (slider.value * itemShop.sellPrice).ToString();
        buyPrice.text = (slider.value * itemShop.buyPrice).ToString();
    }
    public void Buy()
    {
        if(player.money >= int.Parse(buyPrice.text))
        {
            player.money -= int.Parse(buyPrice.text);
            inventory.Add(itemShop, int.Parse(shopText.text));
        }
    }
    public void Sell()
    {
        int index = 0;
        if(CheckForItemsToSell(ref index))
        {
            inventory.items[index].amount -= int.Parse(shopText.text);
            player.money += int.Parse(sellPrice.text);
            inventory.ReloadInventory();
        }
    }
    bool CheckForItemsToSell(ref int index)
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i] == null)
            {
                continue;
            }
            if (inventory.items[i].product == itemShop.product)
            {
                if (inventory.items[i].amount >= int.Parse(shopText.text))
                {
                    index = i;
                    return true;
                }
            }
        }
        return false;
    }
    public void SellAll()
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if(inventory.items[i] == null)
            {
                continue;
            }
            if (inventory.items[i].product == itemShop.product)
            {
                player.money += inventory.items[i].amount * itemShop.sellPrice;
                inventory.items[i].amount = 0;
                inventory.ReloadInventory();
                break;
            }
        }
    }
}
