using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomber : MonoBehaviour
{

    public GameObject bulletP;
    public float spawnRatingMin = 0.5f;
    public float spawnRatingMax = 2f;

    private Transform target;
    private float spawnRate;
    private float afterSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        afterSpawn = 0f;
        spawnRate = Random.Range(spawnRatingMin, spawnRatingMax);
        target = FindObjectOfType<PlayerController>().transform;


    }

    // Update is called once per frame
    void Update()
    {
        afterSpawn += Time.deltaTime;
        transform.LookAt(target);

        if (afterSpawn >= spawnRate)
        {
            afterSpawn = 0f;

            GameObject bullet = Instantiate(bulletP, transform.position, transform.rotation);
            
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRatingMin, spawnRatingMax);

        }

    }
}
