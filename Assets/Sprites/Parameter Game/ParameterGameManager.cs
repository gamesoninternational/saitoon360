using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterGameManager : MonoBehaviour
{
    
    public GameObject ButtonHijau, Jumpscare;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Hijau"))
        {
            ButtonHijau.SetActive(true);
        }
        if (other.CompareTag("NonHijau"))
        {
            ButtonHijau.SetActive(false);
        }
    }

    public void ShowJumpscare(){
        Jumpscare.SetActive(true);
        StartCoroutine(HideJumpscare());
    }

    IEnumerator HideJumpscare(){
        yield return new WaitForSeconds(3f);
        Jumpscare.SetActive(false);
    }


}
