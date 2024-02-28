using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] float spawnRate = 1;
    [SerializeField] int numberOfObjectsToSpawn = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());

        /*
        StopCoroutine(Spawn());

        StopAllCoroutines();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            Instantiate(objectPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
