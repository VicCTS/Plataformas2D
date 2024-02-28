using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public static bool _isGrounded;
    public bool prueba;
    //private Animator _animator;

    /*void Awake()
    {
        _animator = GameObject.Find("knight").GetComponent<Animator>();
    }*/
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isGrounded = true;
            //_animator.SetBool("IsJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isGrounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 6)
        {
            _isGrounded = true;
        }
    }
}
