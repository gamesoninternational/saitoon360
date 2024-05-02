using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHide : MonoBehaviour
{
    public float waitSec;
    public GameObject GO;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(HideObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator HideObj(){
        yield return new WaitForSeconds(waitSec);
        GO.SetActive(false);
    }
}
