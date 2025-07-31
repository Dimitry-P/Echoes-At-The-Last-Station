using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string speakerName;
    [TextArea(2, 5)] public string content;
    public Transform lookTarget;
}

public class NPCDialogue : MonoBehaviour
{
    public DialogueLine[] lines;
    public Transform focusPoint;
}
