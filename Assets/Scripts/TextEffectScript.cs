using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextEffectScript : MonoBehaviour
{
    public float typingSpeed; 
    public string dialogueText;
    public TextMeshProUGUI _TextMeshProUGUI;
    private string currentText = "";
    
    
    // Start is called before the first frame update
    void Start()
    {
        _TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        //StartCoroutine(TextGenerator());
    }

    public void StartTypingDialogue()
    {
        StartCoroutine(TextGenerator());
    }

    IEnumerator TextGenerator()
    {
        Debug.Log(dialogueText.Length);
        for (int i = 0; i <= dialogueText.Length; i++)
        {
            currentText = dialogueText.Substring(0, i);
            _TextMeshProUGUI.text = currentText; // make the letter write on the text 
            yield return new WaitForSeconds(typingSpeed); // time between 2 letter 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.N)) // is here for test + debug 
        //{
        //    StartCoroutine(TextGenerator());
        //}
    }
}
