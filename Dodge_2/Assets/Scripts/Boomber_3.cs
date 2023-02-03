using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomber_3 : MonoBehaviour
{

    public GameObject bulletP;
    public GameObject lazer;
    public float spawnRatingMin = 5f;
    public float spawnRatingMax = 10f;

    private Transform target_1;
    private Transform target_2;
    private float spawnRate;
    private float afterSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        afterSpawn = 0f;
        spawnRate = Random.Range(spawnRatingMin, spawnRatingMax);
        target_1 = FindObjectOfType<PlayerController>().transform;


    }

    // Update is called once per frame
    void Update()
    {
        afterSpawn += Time.deltaTime;
        transform.LookAt(target_1);

        if (afterSpawn >= spawnRate)
        {
            afterSpawn = 0f;

            StartCoroutine(lazerr());
            
            spawnRate = Random.Range(spawnRatingMin, spawnRatingMax);

        }

    }

    IEnumerator lazerr()
    {
        lazer.SetActive(true);
        yield return new WaitForSeconds(1f);
        lazer.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        GameObject bullet = Instantiate(bulletP, transform.position, transform.rotation);
        bullet.transform.LookAt(target_1);

    }



    
}
