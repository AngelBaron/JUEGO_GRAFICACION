using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARROIA : MonoBehaviour {
  public Rigidbody2D cuerpo;
    public Transform ruedaFrenteIA;
    public float aceleracion = 1000f; // 🔥 Fuerza de aceleración en X
    public float velocidadMaxima = 150f; // 🚀 Límite de velocidad en X
    public float cambioCarrilVelocidad = 30f; // 🔄 Velocidad de cambio de carril en Y
    public float[] carriles = { 11.6f, 26.2f, 36.5f };
    private int carrilActual;
    private bool cambiandoCarril = false;



    void Start()
    {
        cuerpo.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        carrilActual = ObtenerCarrilMasCercano();
        AjustarAPosicionCarril();
    }

    void Update()
    {
        AcelerarEnX();
    }

    void AcelerarEnX()
    {
        // ✅ Agregamos fuerza en X solo si no ha alcanzado la velocidad máxima
        if (cuerpo.velocity.x < velocidadMaxima)
        {
            cuerpo.AddForce(Vector2.right * aceleracion * Time.deltaTime, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bache") && !cambiandoCarril)
        {
            Debug.Log("¡SE DETECTÓ UN BACHE!");
            CambiarCarril();
        }
    }

    void CambiarCarril()
    {
        int nuevoCarril = carrilActual;
        if (carrilActual == 0)
        {
            nuevoCarril = 1;
        }
        else if (carrilActual == 2)
        {
            nuevoCarril = 1;
        }
        else
        {
            nuevoCarril = (Random.Range(0, 2) == 0) ? 0 : 2;
        }

        if (!HayCarroEnCarril(nuevoCarril))
        {
            StartCoroutine(MoverACarril(nuevoCarril));
        }
    }

    bool HayCarroEnCarril(int carril)
    {
        Collider2D carroDetectado = Physics2D.OverlapCircle(new Vector2(transform.position.x, carriles[carril]), 1f, LayerMask.GetMask("CarroIA"));
        return carroDetectado != null;
    }

    IEnumerator MoverACarril(int nuevoCarril)
    {
        cambiandoCarril = true;
        Vector2 destino = new Vector2(cuerpo.position.x, carriles[nuevoCarril]);
        float tiempoMaximo = 0.5f;
        float tiempoTranscurrido = 0f;

        while (!Mathf.Approximately(cuerpo.position.y, destino.y) && tiempoTranscurrido < tiempoMaximo)
        {
            Debug.Log("MOVERSE A CARRIL");
            
            // ✅ Usamos `velocity` en Y para un cambio de carril sin afectar la velocidad en X
            cuerpo.velocity = new Vector2(cuerpo.velocity.x, Mathf.Sign(destino.y - cuerpo.position.y) * cambioCarrilVelocidad);

            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }

        // Asegurar que llegue al destino
        cuerpo.velocity = new Vector2(cuerpo.velocity.x, 0); // ✅ Frenar movimiento en Y al llegar
        cuerpo.position = new Vector2(cuerpo.position.x, carriles[nuevoCarril]);
        carrilActual = nuevoCarril;
        cambiandoCarril = false;
    }

    int ObtenerCarrilMasCercano()
    {
        float distanciaMinima = Mathf.Infinity;
        int indiceCarril = 0;

        for (int i = 0; i < carriles.Length; i++)
        {
            float distancia = Mathf.Abs(transform.position.y - carriles[i]);
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                indiceCarril = i;
            }
        }
        return indiceCarril;
    }

    void AjustarAPosicionCarril()
    {
        cuerpo.position = new Vector2(transform.position.x, carriles[carrilActual]);
    }
}
