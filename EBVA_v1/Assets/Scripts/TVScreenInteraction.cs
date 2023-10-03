using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class TVScreenInteraction : MonoBehaviour
{
    public GameObject imageCanvas; // Reference to the Canvas containing the Image UI element
    public TextMeshProUGUI interactionText; // Reference to the Text UI element for interaction message
    public float interactionRange = 2.0f; // Adjust this value for your desired interaction range
    public KeyCode interactionKey = KeyCode.E; // Key to trigger the interaction

    private bool isPlayerNear = false;

    // Start is called before the first frame update
    void Start()
    {
        // Hide the image Canvas initially
        imageCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // Calculate the distance between the player and the TV screen
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Check if the player is within interaction range
        if (distance <= interactionRange)
        {
            isPlayerNear = true;

            // Check if the interaction key is pressed
            if (Input.GetKeyDown(interactionKey))
            {
                ToggleImageCanvas();
            }
        }
        else
        {
            isPlayerNear = false;
        }
    }

    private void ToggleImageCanvas()
    {
        // Toggle the visibility of the image Canvas
        imageCanvas.SetActive(!imageCanvas.activeSelf);
    }
}
