using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Player : MonoBehaviour
{
    [Header("Player Stats")]
    [Tooltip("Controla la velocidad de movimiento del personaje")]
    [SerializeField]private float _playerSpeed = 5;
    [Tooltip("Controla la fuerza de salto del personaje")]
    [SerializeField]private float _jumpForce = 5;
    private float _playerInputHorizontal;

    int health;

    private Rigidbody2D _rBody2D;
    //private GroundSensor _sensor;
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayableDirector _director;
    [SerializeField] private SpriteRenderer _renderer;
    private GameManager _gManager;

    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        //_sensor = GetComponentInChildren<GroundSensor>();

        Debug.Log(GameManager.instance.vidas);

        /*_gManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _gManager.GameOver();*/
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if(Input.GetButtonDown("Jump") && GroundSensor._isGrounded == true)
        {
            Jump();
        }

        /*if(GroundSensor._isGrounded == true)
        {
            _animator.SetBool("IsJumping", false);
        }
        else
        {
            _animator.SetBool("IsJumping", true);
        }*/

        _animator.SetBool("IsJumping", !GroundSensor._isGrounded);

        if(Input.GetButtonDown("Fire2"))
        {
            _director.Play();
        }

    }

    void FixedUpdate()
    {
        _rBody2D.velocity = new Vector2(_playerInputHorizontal * _playerSpeed, _rBody2D.velocity.y);
    }

    void PlayerMovement()
    {
        _playerInputHorizontal = Input.GetAxis("Horizontal");

        if(_playerInputHorizontal < 0)
        {
           transform.rotation = Quaternion.Euler(0, 180, 0);
           _animator.SetBool("IsRunning", true);
        }
        else if(_playerInputHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
        _rBody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);        
    }

    public void SignalTest()
    {
        Debug.Log("Señal recibida");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameManager.instance.GameOver();

        if(collider.gameObject.layer == 9)
        {
            GameManager.instance.vidas -= 1;
        }
    }

    void TakaDamage()
    {
        health = health - 1;
        health -= 1;
        health--;

        if(health == 0)
        {
            GameManager.instance.GameOver();
        }
    }

    
}