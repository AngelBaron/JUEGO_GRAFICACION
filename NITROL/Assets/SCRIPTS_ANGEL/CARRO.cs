using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARRO : MonoBehaviour
{

    public Rigidbody2D cuerpo;
    public Rigidbody2D ruedaFrente;
    public Rigidbody2D ruedaAtras;
    public float fuerzaMotor = 10f;
    public float fuerzaVuelta = 10f;
    public float fuerzaFreno = 5f;
    public float velocidadGiro = 100f;
    public float velocidadMaxima = 20f; // Ajusta este valor según sea necesario
    void Update()
    {
        // Acelerar (D)
        if (Input.GetKey(KeyCode.D))
        {
            cuerpo.AddForce(Vector2.right * fuerzaMotor);
            GirarRuedas(true,cuerpo.velocity.x/2);
        }

        // Frenar (A) solo si hay velocidad en X
        if (Input.GetKey(KeyCode.A) && Mathf.Abs(cuerpo.velocity.x) > 0.1f)
        {
            // Aplicar fuerza de frenado en dirección opuesta al movimiento
            Vector2 direccionFreno = cuerpo.velocity.x > 0 ? Vector2.left : Vector2.right;
            cuerpo.AddForce(direccionFreno * fuerzaFreno);

            // Detener completamente si la velocidad es muy baja
            if (Mathf.Abs(cuerpo.velocity.x) < 0.5f)
            {
                cuerpo.velocity = new Vector2(0, cuerpo.velocity.y);
                DetenerRuedas(); // Detener la rotación de las ruedas
            }

            GirarRuedas(false,0);
        }

        // Moverse a la izquierda (W) o derecha (S) solo si hay velocidad en X
        if (Mathf.Abs(cuerpo.velocity.x) > 0.1f)
        {
            if (Input.GetKey(KeyCode.W))
            {
                cuerpo.AddForce(Vector2.up * fuerzaVuelta);
            }

            if (Input.GetKey(KeyCode.S))
            {
                cuerpo.AddForce(Vector2.down * fuerzaVuelta);
            }
        }
        else
        {
            // Si no hay velocidad en X, detener las ruedas
            DetenerRuedas();
        }

        LimitarVelocidad();

    }

    void GirarRuedas(bool acelerando, float veloz)
    {
        float velocidad = acelerando ? -velocidadGiro : velocidadGiro + veloz;
        ruedaFrente.angularVelocity = velocidad;
        ruedaAtras.angularVelocity = velocidad;
    }

    void DetenerRuedas()
    {
        ruedaFrente.angularVelocity = 0f;
        ruedaAtras.angularVelocity = 0f;
    }

    void LimitarVelocidad()
    {

        if (cuerpo.velocity.magnitude > velocidadMaxima)
        {
            cuerpo.velocity = cuerpo.velocity.normalized * velocidadMaxima;
        }
    }

    // Método para reducir la velocidad del carro
    public void ReducirVelocidad(float reduccion)
    {
        // Reducir la velocidad del carro
        cuerpo.velocity *= (1 - reduccion / 100f); // Reducción porcentual
    }



}
