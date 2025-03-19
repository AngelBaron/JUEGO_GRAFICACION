using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CARROIA : MonoBehaviour {
public Rigidbody2D cuerpo;
    public Transform ruedaFrenteIA;
    public float velocidad = 10f;
    public float cambioCarrilVelocidad = 30f;
    private float[] carriles = { 11.6f, 26.2f, 36.5f };
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
        MoverAdelante();
    }

    void MoverAdelante()
    {
        cuerpo.velocity = new Vector2(velocidad, cuerpo.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    Debug.Log("Intentando detectar trigger con: " + collision.gameObject.name);

    if (collision.CompareTag("Bache") && !cambiandoCarril)
    {
        Debug.Log("¡SE DETECTÓ UN BACHE!");
        CambiarCarril();
    }
}

private void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Bache"))
    {
        Debug.Log("Salió del bache: " + collision.gameObject.name);
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
    Vector2 destino = new Vector2(transform.position.x, carriles[nuevoCarril]);
    float tiempoMaximo = 0.5f; // Tiempo máximo para cambiar de carril
    float tiempoTranscurrido = 0f;

    while (!Mathf.Approximately(transform.position.y, destino.y) && tiempoTranscurrido < tiempoMaximo)
    {
        Debug.Log("MOVERSE A CARRIL");
        transform.position = Vector2.MoveTowards(transform.position, destino, cambioCarrilVelocidad * Time.deltaTime);
        tiempoTranscurrido += Time.deltaTime;
        yield return null;
    }

    // Asegurar que llegue al destino
    transform.position = destino;
    carrilActual = nuevoCarril;
    cambiandoCarril = false;

    // 🔥 Reactivar colisiones para que pueda detectar más baches
    GetComponent<Collider2D>().enabled = false;
    yield return new WaitForSeconds(0.1f);
    GetComponent<Collider2D>().enabled = true;
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
        transform.position = new Vector2(transform.position.x, carriles[carrilActual]);
    }
}
