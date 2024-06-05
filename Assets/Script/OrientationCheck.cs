using UnityEngine;
using UnityEngine.UI;

public class OrientationCheck : MonoBehaviour
{
    private Canvas[] canvases;

    public string orientationSet;
    void Start()
    {
        // Get all Canvas components in the scene
        canvases = FindObjectsOfType<Canvas>();

        if (canvases.Length == 0)
        {
            Debug.LogError("No Canvas found in the scene.");
            return;
        }

        // Check initial orientation for all canvases
        CheckOrientations();
    }

    void Update()
    {
        // Check orientation for all canvases every frame
        CheckOrientations();
    }

    void CheckOrientations()
    {
        foreach (Canvas canvas in canvases)
        {
            CheckOrientation(canvas);
        }
    }

    void CheckOrientation(Canvas canvas)
    {
        float width = canvas.pixelRect.width;
        float height = canvas.pixelRect.height;

        string orientation = width > height ? "Landscape" : "Portrait";
        //Debug.Log($"Canvas '{canvas.name}' Orientation: {orientation}");

        // Optionally, if you want to display orientation on a text element inside each canvas
        Text orientationText = canvas.GetComponentInChildren<Text>();
        if (orientationText != null)
        {
            orientationText.text = orientation;
        }

        // Handle specific behaviors based on orientation
        if (orientation == "Landscape")
        {
            orientationSet = "Landscape";
        }
        else
        {
            orientationSet = "Portrait";
        }
    }
}
