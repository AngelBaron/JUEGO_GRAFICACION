using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMERA_FOLLOW : MonoBehaviour {

	public Transform target; // El objeto que la cámara seguirá
    public float smoothSpeed = 0.125f; // Suavidad del movimiento de la cámara
    public Vector3 offset; // Offset de la cámara respecto al objeto

    void Update()
    {
        if (target != null)
        {
            // Calcular la posición deseada de la cámara
            Vector3 desiredPosition = target.position + offset;

            // Suavizar el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualizar la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
