using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class LukisanGame : MonoBehaviour
{
    public GameObject imagePrefab; // Prefab gambar yang akan di-spawn
    public RectTransform canvasRect; // Rect Transform dari canvas

    public float spawnInterval = 2f; // Interval antara spawn gambar
    public Vector2 spawnArea = new Vector2(200f, 200f); // Ukuran area spawn dalam canvas

    private float spawnTimer = 0f;
    private int score = 0; // Variabel skor

    public GameObject Jumpscare;
    public TextMeshProUGUI scoreText; // TextMeshPro untuk menampilkan skor
    public GameObject successPanel; // Panel sukses

    void Update()
    {
        // Jika jumpscare atau successPanel aktif, hentikan proses spawn
        if (Jumpscare.activeSelf || successPanel.activeSelf)
        {
            return;
        }

        // Menghitung waktu untuk spawn gambar
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnImage();
            spawnTimer = 0f;
        }
    }

    void SpawnImage()
    {
        // Menghitung posisi spawn secara acak di dalam canvas
        float xPos = Random.Range(-canvasRect.rect.width / 2f + spawnArea.x / 2f, canvasRect.rect.width / 2f - spawnArea.x / 2f);
        float yPos = Random.Range(-canvasRect.rect.height / 2f + spawnArea.y / 2f, canvasRect.rect.height / 2f - spawnArea.y / 2f);
        Vector3 spawnPos = new Vector3(xPos, yPos, 0f);

        // Spawn gambar
        GameObject newImage = Instantiate(imagePrefab, spawnPos, Quaternion.identity);
        newImage.transform.SetParent(canvasRect, false);

        // Menambahkan event click pada gambar
        ImageClickDestroy clickDestroy = newImage.AddComponent<ImageClickDestroy>();

        // Memanggil fungsi untuk menghancurkan prefab setelah 3 detik
        StartCoroutine(DestroyAfterTime(newImage, clickDestroy));
    }

    IEnumerator DestroyAfterTime(GameObject image, ImageClickDestroy clickDestroy)
    {
        yield return new WaitForSeconds(3f);
        
        if (!clickDestroy.clicked)
        {
            Destroy(image);
            Jumpscare.SetActive(true);
            
            StartCoroutine(DeactivateJumpscare());
        }
    }

    IEnumerator DeactivateJumpscare()
    {
        yield return new WaitForSeconds(3f);
        Jumpscare.SetActive(false);
        ResetScore();
    }

    // Fungsi untuk menambah skor dan menampilkan teks skor
    public void AddScore()
    {
        score++;
        scoreText.text = "Kumpulkan Api : " + score.ToString() + "/10"; // Menampilkan skor menggunakan TextMeshPro

        // Cek apakah skor mencapai 10
        if (score >= 10)
        {
            successPanel.SetActive(true); // Aktifkan panel sukses jika skor mencapai 10
            DestroyAllImages();
            Destroy(Jumpscare);
        }
    }

    void DestroyAllImages()
    {
        ImageClickDestroy[] images = FindObjectsOfType<ImageClickDestroy>();
        foreach (ImageClickDestroy image in images)
        {
            Destroy(image.gameObject);
        }
    }

    void ResetScore()
    {
        score = 0;
        scoreText.text = "Kumpulkan Api : " + score.ToString() + "/10";
    }
}

public class ImageClickDestroy : MonoBehaviour, IPointerClickHandler
{
    public bool clicked = false;
    private LukisanGame lukisanGame;

    private void Start()
    {
        lukisanGame = FindObjectOfType<LukisanGame>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
        Destroy(gameObject);
        lukisanGame.AddScore(); // Memanggil fungsi AddScore saat gambar diklik
    }
}
