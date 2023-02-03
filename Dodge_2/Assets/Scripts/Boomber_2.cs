using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomber_2 : MonoBehaviour
{

    public GameObject bulletP;
    public float spawnRatingMin = 1f;
    public float spawnRatingMax = 4f;

    private Transform target;
    private float spawnRate;
    private float afterSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        afterSpawn = 0f;
        spawnRate = Random.Range(spawnRatingMin, spawnRatingMax);
        target = FindObjectOfType<Gamemanager>().transform;


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
            Invoke("second", 0.5f);
            
            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRatingMin, spawnRatingMax);

        }

    }

    void second()
    {
        GameObject bullet = Instantiate(bulletP, transform.position, transform.rotation);
    }
}
