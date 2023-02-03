using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Colltime : MonoBehaviour
{

    public float duration;
    public float current;
    public Image icon;

    private void Awake()
    {

    }
    public void init(float du)
    {
        duration = du;
        current = du;
        icon.fillAmount = 0;
    }
    WaitForSeconds seconds = new WaitForSeconds(0.1f);
    public void Execute()
    {
        icon.fillAmount = 1;
        current = duration;
        StartCoroutine(Activation());
    }

    IEnumerator Activation()
    {
        while (current > 0)
        {
            current -= 0.1f;
            icon.fillAmount = current / duration;
            yield return seconds;
        }
        icon.fillAmount = 0;
        current = 0;

        yield return null;
    }

    public void deActivation()
    {

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
