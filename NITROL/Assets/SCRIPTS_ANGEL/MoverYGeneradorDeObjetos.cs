using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYGeneradorDeObjetos : MonoBehaviour {

	public float velocidad = 5f; // Velocidad de movimiento en X
    public List<GameObject> objetosParaGenerar; // Lista de prefabs
    public float intervaloGeneracion = 1f; // Tiempo entre generación de objetos

    private float tiempoSiguienteGeneracion;
    private float altura;

    private void Start()
    {
        altura = GetComponent<SpriteRenderer>().bounds.size.y; // O usa Collider.bounds.size.y si prefieres
        tiempoSiguienteGeneracion = Time.time + intervaloGeneracion;
    }

    private void Update()
    {
        // Movimiento en X positiva
        transform.position += Vector3.right * velocidad * Time.deltaTime;

        // Generación de objetos
        if (Time.time >= tiempoSiguienteGeneracion)
        {
            GenerarObjeto();
            tiempoSiguienteGeneracion = Time.time + intervaloGeneracion;
        }
    }

    private void GenerarObjeto()
    {
        if (objetosParaGenerar.Count == 0) return; // Seguridad por si no hay prefabs

        // Elegir un prefab aleatorio
        int indiceAleatorio = Random.Range(0, objetosParaGenerar.Count);
        GameObject prefabSeleccionado = objetosParaGenerar[indiceAleatorio];

        // Calcular una posición aleatoria en Y dentro del tamaño del objeto
        float minY = transform.position.y - altura / 2f;
        float maxY = transform.position.y + altura / 2f;
        float posicionY = Random.Range(minY, maxY);

        // Instanciar el objeto
        Vector3 posicionDeGeneracion = new Vector3(transform.position.x, posicionY, transform.position.z);
        Instantiate(prefabSeleccionado, posicionDeGeneracion, Quaternion.identity);
    }
}
