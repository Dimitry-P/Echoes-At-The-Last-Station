using UnityEngine;
using TMPro;
using Echoes_At_The_Last_Station;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textContent;

    public GameObject player;
    private MouseLook mouseLook;
    private FPSInput fpsInput;

    public LookAtSpeaker cameraLookAt;
    public DialogueUIController dialogueUIController;

    public DialogueLine[] dialogueLines;

    private int currentLineIndex = 0;
    private bool isDialogueActive = false;
    public bool IsDialogueActive => isDialogueActive;

    void Start()
    {
        mouseLook = player.GetComponent<MouseLook>();
        fpsInput = player.GetComponent<FPSInput>();
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            ShowNextLine();
        }
    }

    public void StartDialogue()
    {
        if (isDialogueActive) return;

        isDialogueActive = true;
        currentLineIndex = 0;
        if (mouseLook != null) 
            mouseLook.enabled = false;

        if (fpsInput != null)
            fpsInput.enabled = false;

        ShowLine(currentLineIndex);
    }

    void ShowNextLine()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogueLines.Length)
        {
            ShowLine(currentLineIndex);
        }
        else
        {
            EndDialogue();
        }
    }

    void ShowLine(int index)
    {
        var line = dialogueLines[index];

        textName.text = line.speakerName;
        textContent.text = line.content;

        if (line.lookTarget != null && cameraLookAt != null)
        {
            cameraLookAt.SetTarget(line.lookTarget);
        }

        if (dialogueUIController != null)
        {
            dialogueUIController.ShowDialogue(line.speakerName, line.content, line.lookTarget);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;

        if (cameraLookAt != null)
            cameraLookAt.ClearTarget();

        if (mouseLook != null)
            mouseLook.enabled = true;

        if (fpsInput != null)
            fpsInput.enabled = true;

        if (dialogueUIController != null)
            dialogueUIController.HideDialogue();
    }
}
