using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody player;
    [SerializeField] bool touchingGround;
    [SerializeField] CollisionManager collisionManager;
    [SerializeField] float rotation;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Text moneyText;
    [SerializeField] private Animator animator;
    public int money;

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
        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        {
            player.AddForce(Vector3.up * jumpForce);
        }
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed);

        animator.SetBool("Walk", Input.GetAxisRaw("Vertical") != 0);
        animator.SetBool("Jump", Input.GetKeyDown(KeyCode.Space));

        moneyText.text = money.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisionManager.Player(ref touchingGround, collision, player);
    }
    private void OnCollisionExit(Collision collision)
    {
        collisionManager.Player(ref touchingGround, collision, player);
    }
}
