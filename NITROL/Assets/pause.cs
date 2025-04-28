using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour {

    [SerializeField] GameObject pauseMenu;
    public string sceneToLoad = "Menu_Principal"; 
    public AudioSource sonidoCarro; // Asigna el AudioSource en el Inspector
    public AudioSource sonidoCarro2; // Asigna el AudioSource en el Inspector

	public void Pause()
    {
        Time.timeScale = 0f;
        // Baja el volumen del carro
        sonidoCarro.volume = 0.0f; // Baja el volumen del carro
        sonidoCarro2.volume = 0.0f; // Baja el volumen del carro
        pauseMenu.SetActive(true);
        
    }

    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneToLoad);
        
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        // Reanuda el juego

        Time.timeScale = 1f;
        // Regresa el volumen del carro
        sonidoCarro.volume = 1.0f; // Regresa el volumen del carro
        sonidoCarro2.volume = 1.0f; // Regresa el volumen del carro
    }
}
