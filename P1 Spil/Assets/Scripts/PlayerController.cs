using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Code inspired by a lesson from Ali, for movemnt of the player, and Unity Learn Lesson 2.1 Player Positioning and modified to fit this project.
public class PlayerController : MonoBehaviour
{
    private Vector2 _movement; 
    private Rigidbody2D _myBody; 
    
    private AudioSource _hitSoundSource;
    public AudioClip EnemyHitSoundEffect;
    
    public SpriteRenderer SpriteRenderer;
    public Sprite NewSprite;
    public Sprite SecondNewSprite;
    private GameManager _gameManager;

    [SerializeField] private int _speed = 5;
    [SerializeField] private float _xRange = 5f;

    private void Start()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _hitSoundSource = GetComponent<AudioSource>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _myBody = GetComponent<Rigidbody2D>(); 
    }

    private void ChangeSprite(Sprite newSprite)
    {
        SpriteRenderer.sprite = newSprite;
    }

    private void OnMovement(InputValue value) 
    {
        _movement = value.Get<Vector2>();  
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

        if (_gameManager.Health == 3)
        {
            ChangeSprite(NewSprite);
        }

        if (_gameManager.Health <= 1)
        {
            ChangeSprite(SecondNewSprite);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Item"))
        {
            GetComponent<AudioSource>().Play();
        }
        else if (col.CompareTag("Correct"))
        {
            GetComponent<AudioSource>().Play();
        }
        else if (col.CompareTag("Enemy"))
        {
            _hitSoundSource.PlayOneShot(EnemyHitSoundEffect);
        }
        else if (col.CompareTag("Incorrect"))
        {
            _hitSoundSource.PlayOneShot(EnemyHitSoundEffect);
        }
    }
}
