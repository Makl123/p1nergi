using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 movement; // Vi vil gemme det "Vector2" der kommer ind når brugeren trykker på WASD ind på movement
    private Rigidbody2D myBody; // Det rigidbody vi ville flytte rundt.
    private Animator myAnimator; // Vi laver en animator variable så vi kan pille ved den i koden
    

    [SerializeField] private int speed = 5; // Den hastighed vores human skal flyttes rundt.

    private void Awake() // Awake kører kun en gang når programmet starter
    {
        myBody = GetComponent<Rigidbody2D>(); // Vi sætter myBody rigidbody til rigidbody på det gameobject vi sidder på.
        myAnimator = GetComponent<Animator>(); // Vi vil lege med den animator den sidder på vores gameobject så derfor
    }

    private void OnMovement(InputValue value) // Vi laver en function der holder øje med vores Input system value.
    {
        movement = value.Get<Vector2>(); // Movement bliver sat til vector2 fra vores Input Action når brugeren trykker WASD. 

        if (movement.x != 0 || movement.y != 0) // value.vector2 bliver sat til [0.0] når man ikke trykker på WASD og spilleren kigger op konstant når vi er færdig med at trykke. For at undgå det gøre vi sådan så vi ændre vores animation kun hvis mindst en af x eller y er ikke = 0. 
        {
            myAnimator.SetFloat("x", movement.x); // Sætter vores x i vores animator til movement.x der kommer fra Unity input
            myAnimator.SetFloat("y",movement.y);  // Sætter vores y i vores animator til movement.y der kommer fra Unity input
            myAnimator.SetBool("isWalking", true); // når enten movement.x eller y ikke er = 0 så betyder det vi går!
        }
        else
        {
            myAnimator.SetBool("isWalking", false); // Ellers går vi ikke så sæt den til false.
        }
    }

    private void FixedUpdate() // FixedUpdate er mere effectiv end update når det kommer til even based ting som flytning. 
    {
        myBody.velocity = movement * speed; // Vi sætter velocity af vores rigidbody2D i den hastighed vi har sat
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
