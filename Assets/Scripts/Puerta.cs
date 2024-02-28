using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    bool cerrado = true;
    public int numero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.K) && cerrado == true)
        {
            Debug.Log("abriendo puerta");
            cerrado = false;
        }*/

        if(Input.GetKeyDown(KeyCode.K) && numero == 1)
        {
            Debug.Log("abriendo puerta hacia arriba");
            //cerrado = false;
        }
        else if(Input.GetKeyDown(KeyCode.K) && numero == 2)
        {
            Debug.Log("abriendo puerta hacia abajo");
            //cerrado = false;
        }
        else if(Input.GetKeyDown(KeyCode.K) && numero == 3)
        {
            Debug.Log("abriendo puerta hacia izquierda");
            //cerrado = false;
        }
    }
}
