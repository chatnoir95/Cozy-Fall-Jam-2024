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
    public AudioClip characterVoice;
    public Sprite NPCSprite;
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
    [SerializeField] Image NPCTextImage;
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
      //  Debug.Log("startdialogue");
        if (dialogue.characters.Count > dialogueIndex)
        {
            Player.canPlayerMove = false;

            //Debug.Log(dialogue.characters[dialogueIndex].characterName);
            //DialogueCharacter character = dialogue.characters[dialogueIndex];

            characterNameText.text = dialogue.characters[dialogueIndex].characterName;
            _dialoguePanel.SetActive(true);
            textEffectScript.dialogueText = dialogue.characters[dialogueIndex].dialogue;
            textEffectScript.StartTypingDialogue();

            
            SFXScript.instance.LaunchSoundSFX(dialogue.characters[dialogueIndex].characterVoice);
            SFXScript.instance.StartTypingSFX(SFXScript.instance.typingSound1);

            NPCTextImage.sprite = dialogue.characters[dialogueIndex].NPCSprite ; // put the sprite on screen

            dialogueIndex++;
        }
        else { Debug.LogWarning("NO MORE DIALOGUE AVAILABLE"); }

    }

    public void CloseDialoguePanel()
    {
        SFXScript.instance.typingSFXSource.Stop();

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
