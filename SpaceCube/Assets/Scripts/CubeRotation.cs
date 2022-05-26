using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    public GameObject planet;

    public void RollForward()
    {
        Rotate(Vector3.forward);
    }
    public void RollBack()
    {
        Rotate(Vector3.back);
    }
    public void RollLeft()
    {
        Rotate(Vector3.left);
    }
    public void RollRight()
    {
        Rotate(Vector3.right);
    }
    void Rotate(Vector3 direction)
    {
        planet.transform.Rotate(direction * 90, Space.World);
    }
}
