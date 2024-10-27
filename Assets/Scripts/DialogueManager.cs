using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueCharacter
{
    public string characterName;
    [TextArea(5, 10)]
    public string dialogue;
}
[System.Serializable]
public class Dialogues
{
    public List<DialogueCharacter> characters = new List<DialogueCharacter>();
}
public class DialogueManager : MonoBehaviour
{

    [SerializeField] private GameObject _dialoguePanel;
    [SerializeField] TextEffectScript textEffectScript;
    [SerializeField] TextMeshProUGUI characterNameText;

    public Dialogues dialogue;

    private int dialogueIndex = 0;

    public static DialogueManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("careful more than one instance of DialogueManager");
            return;
        }
        instance = this;
    }

    public void startDialogue() // launch the dialogue in a specifique order. the dialogue panel will open, and letter will apears 
    {
        Debug.Log("startdialogue");
        if (dialogue.characters.Count > dialogueIndex)
        {
            Player.canPlayerMove = false;

            Debug.Log(dialogue.characters[dialogueIndex].characterName);
            //DialogueCharacter character = dialogue.characters[dialogueIndex];

            characterNameText.text = dialogue.characters[dialogueIndex].characterName;
            _dialoguePanel.SetActive(true);
            textEffectScript.dialogueText = dialogue.characters[dialogueIndex].dialogue;
            textEffectScript.StartTypingDialogue();

            dialogueIndex++;

            SFXScript.instance.StartTypingSFX(SFXScript.instance.typingSound1);
        }
        else { Debug.LogWarning("NO MORE DIALOGUE AVAILABLE"); }

    }

    public void CloseDialoguePanel()
    {
        SFXScript.typingSFXSource.Stop();

        Player.canPlayerMove = true;

        _dialoguePanel.SetActive(false); 
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
