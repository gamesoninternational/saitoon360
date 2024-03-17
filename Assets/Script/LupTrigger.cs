using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LupTrigger : MonoBehaviour
{
    public GameObject LupObj;
    public GameObject FinishObj, UIFailed, Jumpscare;

    public Animator CamAnim;
    // Start is called before the first frame update
    void Start()
    {
        //LupObj.transform.position = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObstacleObj"))
        {
            Debug.Log("Kena Obstacle");
            FinishObj.SetActive(false);
            UIFailed.SetActive(true);
        }

        if (other.CompareTag("ObstacleOut"))
        {
            Debug.Log("Stay on the Line");
        }
        if (other.CompareTag("Done"))
        {
            Debug.Log("Jumpscare");
            Jumpscare.SetActive(true);
            CamAnim.SetTrigger("Jumpscare");
            StartCoroutine(AfterJumpscare());
        }
    }

    public void RestartGame(){
        LupObj.transform.position = new Vector3(-3.6f, 1.56f, -5f);
        LupObj.transform.eulerAngles = new Vector3(90f, 90f, 0f);
        FinishObj.SetActive(true);
        UIFailed.SetActive(false);
        Jumpscare.SetActive(false);
    }

    IEnumerator AfterJumpscare(){
        yield return new WaitForSeconds(4f);
        RestartGame();
    }
}
