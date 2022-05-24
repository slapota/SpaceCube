using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController player;
    float rotation;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }

        rotation += Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        player.transform.rotation = Quaternion.Euler(0, rotation, 0);

        /*float z = Input.GetAxis("Vertical");
        direction = transform.forward * z;
        player.Move(direction * Time.deltaTime * speed);
        direction = Vector3.zero;*/
    }
}
