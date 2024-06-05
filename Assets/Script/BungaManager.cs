using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BungaManager : MonoBehaviour
{
    public int BungaCount;

    public GameObject SajenPanelDone;
    
    public int countdownTime = 10; // Waktu hitung mundur dalam detik
    public TextMeshProUGUI countdownText; // Referensi ke TextMeshPro Text UI

    private Coroutine countdownCoroutine; // Menyimpan referensi ke Coroutine yang berjalan

    public List<GameObject> BungaButton = new List<GameObject>();
    public List<GameObject> BungaObj = new List<GameObject>();

    public GameObject CheckOrientationScript;
    public GameObject Jumpscare, JumpscareLandscape, JumpscarePortrait;

    // Start is called before the first frame update
    void Start()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countdownCoroutine = StartCoroutine(Countdown());

        
    }

    // Update is called once per frame
    void Update()
    {

        if(BungaCount == 8){
            SajenPanelDone.SetActive(true);
            StopCountdown();
        }

        if (CheckOrientationScript.GetComponent<OrientationCheck>().orientationSet == "Landscape")
        {
            JumpscareLandscape.SetActive(true);
            JumpscarePortrait.SetActive(false);
        }
        if (CheckOrientationScript.GetComponent<OrientationCheck>().orientationSet == "Portrait")
        {
            JumpscarePortrait.SetActive(true);
            JumpscareLandscape.SetActive(false);
        }
    }

    public void StartGame(){
        
    }

    public void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownText.text = "Stopped"; // Atau teks lain yang Anda inginkan saat dihentikan
        }
    }

    private System.Collections.IEnumerator Countdown()
    {
        int currentTime = countdownTime;

        while (currentTime > 0)
        {
            countdownText.text = "Waktu : " + currentTime.ToString();
            yield return new WaitForSeconds(1f); // Tunggu 1 detik
            currentTime--;
        }

        countdownText.text = "0"; // Tampilkan nol setelah hitungan selesai
        countdownCoroutine = null; // Reset Coroutine
        // Anda bisa menambahkan tindakan lain di sini setelah hitungan mundur selesai

        Jumpscare.SetActive(true);
        StartCoroutine(HideJumpscare());
        ResetGame();
        BungaCount = 0;
    }

    public IEnumerator HideJumpscare(){
        yield return new WaitForSeconds(3f);
        Jumpscare.SetActive(false);

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        countdownCoroutine = StartCoroutine(Countdown());
    }

    public void ResetGame()
    {
        foreach (GameObject button in BungaButton)
        {
            button.SetActive(true);
        }

        foreach (GameObject bunga in BungaObj)
        {
            bunga.SetActive(false);
        }
        
        Debug.Log("Semua objek telah di-disable.");
    }
}
