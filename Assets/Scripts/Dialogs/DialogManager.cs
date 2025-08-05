using UnityEngine;
using TMPro;
using Echoes_At_The_Last_Station;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    [Header("UI Elements")]
    public TextMeshProUGUI textName;
    public TextMeshProUGUI textContent;

    [Header("Player Controls")]
    public GameObject player;
    private MouseLook mouseLook;
    private FPSInput fpsInput;

    [Header("Dialogue Settings")]
    public LookAtSpeaker cameraLookAt;
    public DialogueUIController dialogueUIController;
    public float continueCooldown = 0.3f;

    private DialogueLine[] currentDialogueLines;
    private int currentLineIndex;
    private bool isDialogueActive;
    private bool canContinue = false;
    public System.Action OnDialogueContinue;
    private bool wasKeyPressedBeforeDialogue = false;

    public bool IsDialogueActive => isDialogueActive;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (player != null)
        {
            mouseLook = player.GetComponent<MouseLook>();
            fpsInput = player.GetComponent<FPSInput>();
        }
    }

    void Update()
    {
        if (!isDialogueActive) return;

        if (!wasKeyPressedBeforeDialogue)
        {
            wasKeyPressedBeforeDialogue = true;
            Input.ResetInputAxes();
            return;
        }

        if (!canContinue) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            canContinue = false;
            ShowNextLine();
            StartCoroutine(ContinueCooldown());
        }
    }

    public void StartDialogue(DialogueData dialogue)
    {
        if (isDialogueActive || dialogue == null || dialogue.lines == null || dialogue.lines.Length == 0)
        {
            Debug.LogWarning("Failed to start dialogue");
            return;
        }

        wasKeyPressedBeforeDialogue = false;
        currentDialogueLines = dialogue.lines;
        currentLineIndex = 0;
        isDialogueActive = true;
        canContinue = true;

        // Disable player controls
        if (mouseLook != null) mouseLook.enabled = false;
        if (fpsInput != null) fpsInput.enabled = false;

        // Show first line immediately
        ShowLine(currentLineIndex);
    }

    public void ShowNextLine()
    {
        if (!isDialogueActive || currentDialogueLines == null) return;

        currentLineIndex++;

        if (currentLineIndex < currentDialogueLines.Length)
        {
            ShowLine(currentLineIndex);
            OnDialogueContinue?.Invoke();
        }
        else
        {
            EndDialogue();
        }
    }

    void ShowLine(int index)
    {
        if (index < 0 || index >= currentDialogueLines.Length)
        {
            Debug.LogError($"Invalid dialogue index: {index}");
            return;
        }

        var line = currentDialogueLines[index];

        if (textName != null) textName.text = line.speakerName;
        if (textContent != null) textContent.text = line.content;

        if (line.lookTarget != null && cameraLookAt != null)
        {
            cameraLookAt.SetTarget(line.lookTarget.transform);
        }

        if (dialogueUIController != null && line.lookTarget != null)
        {
            dialogueUIController.ShowDialogue(line.speakerName, line.content, line.lookTarget.transform);
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

        currentDialogueLines = null;
        OnDialogueContinue = null; // Clear all subscribers
    }

    IEnumerator ContinueCooldown()
    {
        yield return new WaitForSeconds(continueCooldown);
        canContinue = true;
    }
}