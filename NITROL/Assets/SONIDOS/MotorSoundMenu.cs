using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorSoundMenu : MonoBehaviour
{
    public AudioSource menuMusic; // Música de fondo para el menú

    void Start()
    {
        // Reproduce la música si no está ya sonando
        if (!menuMusic.isPlaying)
        {
            menuMusic.loop = true; // Asegura que se reproduzca en bucle
            menuMusic.Play();
        }
    }


}
