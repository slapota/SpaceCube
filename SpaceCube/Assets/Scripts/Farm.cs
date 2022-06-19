using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public Item product;
    public int stock;
    public int level;
    public float speed;

    void Start()
    {
        stock = 0;
        StartCoroutine(Add());
    }

    IEnumerator Add()
    {
        yield return new WaitForSecondsRealtime(speed);
        stock += level;
        StartCoroutine(Add());
    }
}
