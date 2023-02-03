using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerR;
    public float speed = 8f;
    public GameObject effect;

    float hAxis;
    float vAxis;
    Vector3 moveVec;

    Animator anim;
    bool wDown;
    bool sDown;
    bool aDown;
    bool Dashbool;
    bool skill_2bool;
    bool skillActive;
    public static bool moving;

    public GameObject skill02_effect;
    public GameObject skill03_effect;
    MeshRenderer[] mesh;


    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        mesh = GetComponentsInChildren<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerR = GetComponent<Rigidbody>();
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.y <= -1 || (transform.position.x > 13 && transform.position.z > 13) || (transform.position.x < -13 && transform.position.z > 13) || (transform.position.x > 13 && transform.position.z < -13) || (transform.position.x < -13 && transform.position.z < -13))
        {
            Die();
        }
        if (moving)
        {
            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");
            wDown = Input.GetButton("walk");
            sDown = Input.GetButton("skill_1");
            aDown = Input.GetButton("skill_2");

            if ( sDown && !Dashbool && Gamemanager.isStarting)
            {
                Colltime cool = FindObjectOfType<Colltime>();
                
                cool.Execute();
                Dashbool = true;
                StartCoroutine(Dash());
            }
            if (aDown && !skill_2bool && Gamemanager.isStarting)
            {

                Colltime_2 cool = FindObjectOfType<Colltime_2>();

                cool.Execute();
                skill_2bool = true;
                StartCoroutine(skill_2());
            }


            moveVec = new Vector3(hAxis, 0, vAxis).normalized;

            transform.position += moveVec * speed * (wDown ? 0.5f : 1f) * Time.deltaTime;

            anim.SetBool("isrun", moveVec != Vector3.zero);
            anim.SetBool("iswalk", wDown);

            transform.LookAt(transform.position + moveVec);
        }
        

        
    }


    public void Die()
    {
        speed = 8f;
        gameObject.SetActive(false);

        Gamemanager gameManager = FindObjectOfType<Gamemanager>();

        gameManager.EndGame();
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "nomal" && Bullet.lifecount >0 )
        {
            StartCoroutine(Ondamage());
        }
        if (other.tag == "missile" && Bullet.lifecount > 0)
        {
            StartCoroutine(Stun());
        }
    }

    IEnumerator Ondamage()
    {
        foreach (MeshRenderer mesh in mesh)
        {
            mesh.material.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f);
        
        foreach (MeshRenderer mesh in mesh)
        {
            mesh.material.color = Color.white;
        }
    }
    IEnumerator Stun()
    {
        moving = false;
        foreach (MeshRenderer mesh in mesh)
        {
            mesh.material.color = Color.yellow;
        }

        yield return new WaitForSeconds(0.2f);

        moving = true;
        foreach (MeshRenderer mesh in mesh)
        {
            mesh.material.color = Color.white;
        }
    }

    IEnumerator Dash()
    {

        speed = 16f;
        effect.SetActive(true);

        yield return new WaitForSeconds(3f);

        speed = 8f;
        effect.SetActive(false);

        yield return new WaitForSeconds(12f);
        
        Dashbool = false;


    }

    IEnumerator skill_2()
    {

        if ( Gamemanager.skillmode == 1 )
        {
            
        }else if (Gamemanager.skillmode == 2)
        {
            
            if( Bullet.lifecount < 3)
            {
                Bullet.lifecount += 1;
                skill02_effect.SetActive(true);
;           }
        }else if (Gamemanager.skillmode == 3)
        {
            skill03_effect.SetActive(true);
            
        }
        

        yield return new WaitForSeconds(5f);
        skill03_effect.SetActive(false);


        yield return new WaitForSeconds(20f);
        skill02_effect.SetActive(false);

        
        skill_2bool = false;


    }




}
