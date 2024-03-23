using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingGame : MonoBehaviour
{
    public float LoadingTime;
    public string NamaScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KeScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KeScene(){
        yield return new WaitForSeconds(LoadingTime);
        Application.LoadLevel(NamaScene);
    }
}
