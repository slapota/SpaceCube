using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public void Player(ref bool touching, Collision collision, Rigidbody player)
    {
        switch (collision.collider.name)
        {
            case "Cube":
                touching = true;
                break;
            case "Border":
                player.velocity = Vector3.zero;
                player.transform.position = new Vector3(0, 2, 0);
                break;
        }
    }
}
