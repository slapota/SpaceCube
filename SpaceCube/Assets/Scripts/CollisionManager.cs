using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public void Player(ref bool touching, Collision collision, Rigidbody player)
    {
        if (collision.collider.name == "Cube")
        {
            touching = true;
        }
        if(collision.collider.name == "Border")
        {
            player.velocity = Vector3.zero;
            player.transform.position = new Vector3(0, 2, 0);
        }
    }
}
