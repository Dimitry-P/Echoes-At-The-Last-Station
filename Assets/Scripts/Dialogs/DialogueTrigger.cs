using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueData dialogueData;
    public DialogueType dialogueType = DialogueType.Conversation;
    public bool playOnlyOnce = true;

    private bool isPlayerInTrigger = false;
    private bool wasPlayed = false;

    private void Update()
    {
        if (!isPlayerInTrigger) return;

        // ��� ������������: ������ �������������
        if (dialogueType == DialogueType.Memory &&
            !DialogueManager.Instance.IsDialogueActive &&
            !(playOnlyOnce && wasPlayed))
        {
            StartMemoryDialogue();
        }

        // ��� ��������: ������ �� ������� E
        if (dialogueType == DialogueType.Conversation &&
            Input.GetKeyDown(KeyCode.E) &&
            !DialogueManager.Instance.IsDialogueActive &&
            !(playOnlyOnce && wasPlayed))
        {
            StartConversationDialogue();
        }
    }

    private void StartMemoryDialogue()
    {
        wasPlayed = true;
        DialogueManager.Instance.StartDialogue(dialogueData);
    }

    private void StartConversationDialogue()
    {
        wasPlayed = true;
        DialogueManager.Instance.StartDialogue(dialogueData);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}