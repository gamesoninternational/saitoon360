using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelendangGame : MonoBehaviour
{
    public GameObject CheckOrientationScript;

    public GameObject EnvLandscape, EnvPortrait;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckOrientationScript.GetComponent<OrientationCheck>().orientationSet == "Landscape")
        {
            EnvLandscape.SetActive(true);
            EnvPortrait.SetActive(false);
        }
        if (CheckOrientationScript.GetComponent<OrientationCheck>().orientationSet == "Portrait")
        {
            EnvPortrait.SetActive(true);
            EnvLandscape.SetActive(false);
        }
    }
}
