using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Code inspired by a lesson from Ali and Unity Learn Lesson 2.1 Player Positioning and modified to fit this project.
    private Vector2 _movement; 
    private Rigidbody2D _myBody; 
    private Animator _myAnimator; 

    [SerializeField] private int _speed = 5;
    [SerializeField] private float _xRange = 5;

    private void Awake() 
    {
        _myBody = GetComponent<Rigidbody2D>(); 
        _myAnimator = GetComponent<Animator>(); 
    }

    private void OnMovement(InputValue value) 
    {
        _movement = value.Get<Vector2>();  

        if (_movement.x != 0 || _movement.y != 0) 
        {
            _myAnimator.SetFloat("x", _movement.x); 
            _myAnimator.SetFloat("y",_movement.y);  
            _myAnimator.SetBool("isWalking", true); 
        }
        else
        {
            _myAnimator.SetBool("isWalking", false); 
        }
    }

    private void FixedUpdate() 
    {
        _myBody.velocity = _movement * _speed; 
    }
   
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -_xRange){
            transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
        }
        
        if (transform.position.x > _xRange){
            transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
        }
    }
}
