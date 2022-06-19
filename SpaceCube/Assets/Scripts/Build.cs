using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject building;
    public Inventory inventory;
    public BoxCollider cube;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        building = null;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == cube)
            {
                if(building != null)
                {
                    Instantiate(building, new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z), Quaternion.identity);
                    building = null;
                }
            }
            else if(hit.collider.name.Contains("Farm"))
            {
                Farm farm = hit.collider.gameObject.GetComponent<Farm>();
                Collect(farm);
            }
        }
    }
    void Collect(Farm farm)
    {
        for (int i = 0; i < inventory.items.Length; i++)
        {
            if (inventory.items[i] == null)
            {
                Item item = inventory.Spawn(farm.product, i);
                inventory.items[i] = item;
                farm.stock = 0;
                Debug.Log(inventory.items[i].amount + " new");
                break;
            }else if (inventory.items[i].product == farm.product.product)
            {
                inventory.items[i].amount += farm.stock;
                farm.stock = 0;
                Debug.Log(inventory.items[i].amount);
                break;
            }
        }
    }
}
