using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class VideoControl : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    public KeyCode interactionKey = KeyCode.E;
    public float interactionRange = 2.0f;

    private bool isPlayerNear = false;
    private bool isPlaying = false;


    private void Start()
    {
        // Ensure the video starts paused
        videoPlayer.Stop();
    }

    private void Update()
    {
        // Calculate the distance between the player and the TV screen
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        if (!isPlaying)
        {
            // Check if the player is within interaction range
            if (distance <= interactionRange)
            {
                isPlayerNear = true;

                // Check if the interaction key is pressed
                if (Input.GetKeyDown(interactionKey))
                {
                    PlayVideo();
                }
            }
            else
            {
                isPlayerNear = false;
            }
        }
        else if (isPlaying)
        {
            // Check if the player moves out of range while the video is playing
            if (distance > interactionRange)
            {
                StopVideo();
            }
            else if (Input.GetKeyDown(interactionKey))
            {
                StopVideo();
            }
        }

    }

    private void PlayVideo()
    {
        // Play the video
        videoPlayer.Play();
        isPlaying = true;
    }

    private void StopVideo()
    {
        // Stop the video
        videoPlayer.Stop();
        isPlaying = false;
    }
}
