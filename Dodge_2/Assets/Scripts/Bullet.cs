using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletR;

    public static int lifecount = 3;
    public static bool started;

    //public GameObject bullet_s;

    // Start is called before the first frame update
    void Start()
    {
        if( started == true)
        {
            lifecount = 3;
            started = false;
        }


        bulletR = GetComponent<Rigidbody>();
        bulletR.velocity = transform.forward * speed;

        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            Destroy(gameObject, 0f);

            lifecount -= 1;
            Debug.Log(lifecount);
            if ( playerController != null && lifecount <= 0)
            {
                started = true;
                playerController.Die();
            }
            

        }
        if (other.tag == "Wall")
        {
            Destroy(gameObject, 0);

        }
    }




}
