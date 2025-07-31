using UnityEngine;

public class DialogueTriggerZone : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private bool playerInRange = false;
    [SerializeField] private Transform npcHead;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger");
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E pressed in range, starting dialogue");
            if (!dialogueManager.IsDialogueActive)
            {
                dialogueManager.StartDialogue();
            }
        }
    }

}
