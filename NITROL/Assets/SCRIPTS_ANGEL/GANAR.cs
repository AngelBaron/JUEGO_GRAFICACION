using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GANAR : MonoBehaviour
{

    public GameObject panelUI; // El panel que se va a mostrar
    public string sceneToLoad = "MainMenu"; // Escena a la que se quiere regresar
    public string sceneToLoadSiguienteNivel = "SiguienteNivel"; // Escena a la que se quiere regresar

    //referencia al sonido del carro
    public AudioSource sonidoCarro; // Asigna el AudioSource en el Inspector
    public AudioSource sonidoCarro2; // Asigna el AudioSource en el Inspector
    public AudioSource sonidoGanador; // Asigna el clip de sonido en el Inspector

    void Start()
    {
        if (panelUI != null)
            panelUI.SetActive(false); // Asegura que esté oculto al inicio
    }

    public void MOSTRAR_MENU()
    {

        if (panelUI != null)
        
            //detiene el tiempo del juego
            Time.timeScale = 0f; // Pausa el juego
                                 // baja el volumen del carro
        sonidoCarro.volume = 0.0f; // Baja el volumen del carro
        sonidoCarro2.volume = 0.0f; // Baja el volumen del carro
                                    // Reproduce el sonido de ganador
        sonidoGanador.Play(); // Reproduce el sonido de ganador

        panelUI.SetActive(true);

    }

    // Esta función puede llamarse desde el botón del panel
    public void ReturnToScene()
    {
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene(sceneToLoad);
    }

    public void SiguienteNivel()
    {
        //regresar el tiempo
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene(sceneToLoadSiguienteNivel);
    }


    //metodo de salir del juego
    public void SalirJuego()
    {
        //salir del juego
        Application.Quit();
        Debug.Log("Saliendo del juego...");
    }

    public void MOSTRAR_MENU_PERDER()
    {
        if (panelUI != null)
        Debug.Log("Mostrar menu de ganador");
            //detiene el tiempo del juego
            Time.timeScale = 0f; // Pausa el juego
            sonidoCarro.volume = 0.0f; // Baja el volumen del carro
        sonidoCarro2.volume = 0.0f; // Baja el volumen del carro
        sonidoGanador.Play(); // Reproduce el sonido de ganador
        panelUI.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        // Reinicia el juego cargando la escena actual
        Time.timeScale = 1f; // Reanuda el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}