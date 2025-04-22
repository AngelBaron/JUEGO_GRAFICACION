using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GANAR : MonoBehaviour {

	public GameObject panelUI; // El panel que se va a mostrar
    public string sceneToLoad = "MainMenu"; // Escena a la que se quiere regresar
	public string sceneToLoadSiguienteNivel = "SiguienteNivel"; // Escena a la que se quiere regresar

    void Start()
    {
        if (panelUI != null)
            panelUI.SetActive(false); // Asegura que esté oculto al inicio
    }

    public void MOSTRAR_MENU()
    {
        
            if (panelUI != null)
                panelUI.SetActive(true);
        
    }

    // Esta función puede llamarse desde el botón del panel
    public void ReturnToScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

	public void SiguienteNivel()
	{
		SceneManager.LoadScene(sceneToLoadSiguienteNivel);
	}
}
