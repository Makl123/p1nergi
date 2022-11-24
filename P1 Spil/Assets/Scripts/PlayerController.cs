using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
 private Vector2 movement; 
    private Rigidbody2D myBody; 
    private Animator myAnimator; 

    [SerializeField] private int speed = 5;
    [SerializeField] private float xRange = 5;

    private void Awake() 
    {
        myBody = GetComponent<Rigidbody2D>(); 
        myAnimator = GetComponent<Animator>(); 
    }

    private void OnMovement(InputValue value) 
    {
        movement = value.Get<Vector2>();  

        if (movement.x != 0 || movement.y != 0) 
        {
            myAnimator.SetFloat("x", movement.x); 
            myAnimator.SetFloat("y",movement.y);  
            myAnimator.SetBool("isWalking", true); 
        }
        else
        {
            myAnimator.SetBool("isWalking", false); 
        }
    }

    private void FixedUpdate() 
    {
        myBody.velocity = movement * speed; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
