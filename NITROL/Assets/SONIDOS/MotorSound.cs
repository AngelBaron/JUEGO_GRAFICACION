using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSound : MonoBehaviour
{
    public AudioSource idleAudio;   // Sonido del motor en reposo
    public AudioSource motorAudio;  // Sonido del motor acelerando

    public float pitchMin = 1f;
    public float pitchMax = 1.5f;

    void Start()
    {
        idleAudio.loop = true;
        motorAudio.loop = true;

        idleAudio.Play();
    }

    void Update()
    {
        // Captura ambos ejes, el vertical ("w", "s") y el horizontal ("d", "a")
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Verifica si hay entrada en cualquiera de los ejes
        if (Mathf.Abs(verticalInput) > 0.01f || Mathf.Abs(horizontalInput) > 0.01f)
        {
            if (!motorAudio.isPlaying)
                motorAudio.Play();

            if (idleAudio.isPlaying)
                idleAudio.Pause();

            // Ajusta el tono basado en la combinación de entradas
            float combinedInput = Mathf.Max(Mathf.Abs(verticalInput), Mathf.Abs(horizontalInput));
            motorAudio.pitch = Mathf.Lerp(pitchMin, pitchMax, combinedInput);
        }
        else
        {
            if (!idleAudio.isPlaying)
                idleAudio.UnPause();

            if (motorAudio.isPlaying)
                motorAudio.Pause();
        }
    }
}
