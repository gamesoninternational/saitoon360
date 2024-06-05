using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class DragPlayer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;
    private Vector2 initialPosition;
    private bool triggerActive = true; // Variable to track if the trigger should be active

    public GameObject Jumpscare, JumpscareLandscape, JumpscarePortrait, CheckOrientationScript, FinishPanel;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition; // Store the initial position
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerActive && other.CompareTag("Path"))
        {
            // Show jump scare
            Debug.Log("Jumpscare");
            Jumpscare.SetActive(true);
            StartCoroutine(HideJumpscare());

            // Reset position to initial position
            rectTransform.anchoredPosition = initialPosition;
        }

        if (triggerActive && other.CompareTag("FinishTigger"))
        {
            FinishPanel.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            triggerActive = false; // Disable the trigger when "C" is pressed
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            triggerActive = true; // Enable the trigger when "C" is released
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

    public IEnumerator HideJumpscare()
    {
        yield return new WaitForSeconds(3f);
        Jumpscare.SetActive(false);
    }
}
