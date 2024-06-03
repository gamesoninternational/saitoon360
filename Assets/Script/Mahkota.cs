using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mahkota : MonoBehaviour
{
    public int PermataBiruInt, PermataHijauInt, PermataMerahInt, PermataCount;
    public int PasangPermata;

    public GameObject MahkotaDone, ClaimButton, CariButton;

    public GameObject PermataBiru, PermataHijau, PermataMerah, Permata;

    public GameObject PermataBiruItem, PermataHijauItem, PermataMerahItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PermataBiruInt = PlayerPrefs.GetInt("PermataBiruInt");
        PermataHijauInt = PlayerPrefs.GetInt("PermataHijauInt");
        PermataMerahInt = PlayerPrefs.GetInt("PermataMerahInt");
        PermataCount = PlayerPrefs.GetInt("PermataCount");

        if(PasangPermata == 3){
            ClaimButton.SetActive(true);
            Permata.SetActive(false);
            CariButton.SetActive(false);
        }

        if (PermataBiruInt == 1){
            PermataBiru.SetActive(true);
            PermataBiruItem.SetActive(false);
        }

        if (PermataHijauInt == 2){
            PermataHijau.SetActive(true);
            PermataHijauItem.SetActive(false);
        }

        if (PermataMerahInt == 3){
            PermataMerah.SetActive(true);
            PermataMerahItem.SetActive(false);
        }

        if(PermataCount == 3){
            CariButton.SetActive(false);

        }

    }

    public void CollectPermataBiru(){
        PermataBiruInt = 1;
        PlayerPrefs.SetInt("PermataBiruInt", PermataBiruInt);
        PermataCount++;
        PlayerPrefs.SetInt("PermataCount", PermataCount);
    }

    public void CollectPermataHijau(){
        PermataHijauInt = 2;
        PlayerPrefs.SetInt("PermataHijauInt", PermataHijauInt);
        PermataCount++;
        PlayerPrefs.SetInt("PermataCount", PermataCount);
    }

    public void CollectPermataMerah(){
        PermataMerahInt = 3;
        PlayerPrefs.SetInt("PermataMerahInt", PermataMerahInt);
        PermataCount++;
        PlayerPrefs.SetInt("PermataCount", PermataCount);
    }

    public void PasangPermataCall(){
        PasangPermata++;
    }

    public void CollectAllPermata() {
        CollectPermataBiru();
        CollectPermataHijau();
        CollectPermataMerah();
    }
}
