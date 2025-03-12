using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuedaFrente : MonoBehaviour
{
    private CARRO carro; // Referencia al script CARRO

    void Start()
    {
        // Obtener la referencia al script CARRO (puede estar en el padre o en otro objeto)
        carro = GetComponentInParent<CARRO>();
        if (carro == null)
        {
            Debug.LogError("No se encontró el script CARRO en el padre de la rueda.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si la rueda ha colisionado con un bache
        if (collision.CompareTag("Bache"))
        {
            // Obtener el script Bache del objeto con el que colisionó
            Bache bache = collision.GetComponent<Bache>();
            if (bache != null)
            {
                // Llamar al método ReducirVelocidad del script CARRO y pasarle la reducción de velocidad
                carro.ReducirVelocidad(bache.reduccionVelocidadBache);
            }
        }
    }
}
