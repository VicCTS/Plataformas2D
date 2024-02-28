using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]static int health = 5;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CorrutinaTest());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log(health);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        health--;
    }

    IEnumerator CorrutinaTest()
    {
        Debug.Log(1);
        yield return null;
        Debug.Log(2);
    }
}
