using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importa el espacio de nombres para UI

public class Dialogo : MonoBehaviour
{

	[SerializeField, TextArea(4, 6)] private string[] dialogueLines; // Array para almacenar las líneas de diálogo
	[SerializeField] private GameObject dialoguePanel; //referencia al panel del diálogo
    [SerializeField] private GameObject famoso; //referencia al panel del diálogo
	[SerializeField] private Text dialogueText; // Referencia al objeto de texto del diálogo

	private int currentLineIndex = 0;
	private bool isDialogueActive = false;

	// Use this for initialization
	void Start()
	{
		ShowDialogue();
	}

	// Update is called once per frame
	void Update()
    {
        if (isDialogueActive && Input.GetMouseButtonDown(0)) // Clic izquierdo
        {
            ShowNextLine();
        }
    }

    void ShowDialogue()
    {
		Time.timeScale = 0f; // 🟡 Pausa el tiempo
        famoso.SetActive(true); // Activa el objeto famoso
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueLines[currentLineIndex];
        isDialogueActive = true;
    }

    void ShowNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
            famoso.SetActive(false); 
            isDialogueActive = false;
			Time.timeScale = 1f; // 🟢 Reanuda el tiempo
        }
    }
}
