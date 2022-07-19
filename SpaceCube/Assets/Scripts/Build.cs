using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject building;
    public GameObject world;
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
            Click();
        }
    }
    void Click()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == cube)
            {
                Spawn(hit);
            }
            else if(hit.collider.name.Contains("Farm"))
            {
                Farm farm = hit.collider.gameObject.GetComponent<Farm>();
                if(farm.stock > 0)
                {
                    inventory.Collect(farm);
                }
            }
        }
    }
    void Spawn(RaycastHit hit)
    {
        if (building != null)
        {
            Instantiate(building, new Vector3(hit.point.x, hit.point.y + 0.05f, hit.point.z), Quaternion.identity).transform.parent = world.transform;
            building = null;
        }
    }
    
}
