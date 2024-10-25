using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    private Canvas characterSelectorCanvas;
    private Canvas level1Canvas;

    private GameObject squirrel1, squirrel2, squirrel3;
    private GameObject directionArrow;

    private GameObject store;

    private GameObject apple;

    private bool isGamePaused;

    static bool choseSquirrel1, choseSquirrel2, choseSquirrel3;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the canvas objects to find our objects inside the scene
        characterSelectorCanvas = GameObject.Find("Character Select Canvas").GetComponent<Canvas>();
        level1Canvas = GameObject.Find("Level 1 Canvas").GetComponent<Canvas>();

        // These squirrels are just prototype objects, we don't have squirrel sprites just yet
        squirrel1 = GameObject.Find("Player Characters/Circle for Squirrel 1");
        squirrel2 = GameObject.Find("Player Characters/Square for Squirrel 2");
        squirrel3 = GameObject.Find("Player Characters/Triangle for Squirrel 3");

        directionArrow = GameObject.Find("Direction Arrow");

        apple = GameObject.Find("Apple");

        store = GameObject.Find("Store");

        // Let's hide the squirrels at start
        squirrel1.SetActive(false);
        squirrel2.SetActive(false);
        squirrel3.SetActive(false);

        directionArrow.SetActive(false);
        store.SetActive(false);

        apple.SetActive(false);

        // Show the character selector canvas but hide level 1 canvas
        characterSelectorCanvas.gameObject.SetActive(true);
        level1Canvas.gameObject.SetActive(false);

        // We want to set game paused to true at start of game
        isGamePaused = true;

        choseSquirrel1 = false;
        choseSquirrel2 = false;
        choseSquirrel3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If game paused is set to true, then pause the game
        if (isGamePaused == true)
        {
            Time.timeScale = 0.0f;
        }

        // If game paused is set to false, then resume the game
        else if (isGamePaused == false)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void PressSquirrel1Button()
    {
        // Hide the character selector canvas
        characterSelectorCanvas.gameObject.SetActive(false);

        // Show the 1st squirrel in gameplay when player presses squirrel 1 button (hide others just in case)
        squirrel1.SetActive(true);
        squirrel2.SetActive(false);
        squirrel3.SetActive(false);

        if (Food.showDirectionArrow)
        {
            directionArrow.SetActive(true);
        }

        if (!apple.IsDestroyed())
        {
            apple.SetActive(true);
        }

        store.SetActive(true);

        // Show the level 1 canvas
        level1Canvas.gameObject.SetActive(true);

        isGamePaused = false; // Resume the game for us
    }

    public void PressSquirrel2Button()
    {
        // Hide the character selector canvas
        characterSelectorCanvas.gameObject.SetActive(false);

        // Show the 2nd squirrel in gameplay when player presses squirrel 2 button (hide others just in case)
        squirrel1.SetActive(false);
        squirrel2.SetActive(true);
        squirrel3.SetActive(false);

        if (Food.showDirectionArrow)
        {
            directionArrow.SetActive(true);
        }

        if (!apple.IsDestroyed())
        {
            apple.SetActive(true);
        }

        store.SetActive(true);

        // Show the level 1 canvas
        level1Canvas.gameObject.SetActive(true);

        isGamePaused = false; // Resume the game for us
    }

    public void PressSquirrel3Button()
    {
        // Hide the character selector canvas
        characterSelectorCanvas.gameObject.SetActive(false);

        // Show the 3rd squirrel in gameplay when player presses squirrel 3 button (hide others just in case)
        squirrel1.SetActive(false);
        squirrel2.SetActive(false);
        squirrel3.SetActive(true);

        if (Food.showDirectionArrow)
        {
            directionArrow.SetActive(true);
        }

        if (!apple.IsDestroyed())
        {
            apple.SetActive(true);
        }

        store.SetActive(true);

        // Show the level 1 canvas
        level1Canvas.gameObject.SetActive(true);

        isGamePaused = false; // Resume the game for us
    }

    public void PressCharacterSelectorButton()
    {
        // Show the character selector canvas
        characterSelectorCanvas.gameObject.SetActive(true);

        // Hide all the squirrels
        squirrel1.SetActive(false);
        squirrel2.SetActive(false);
        squirrel3.SetActive(false);

        if (Food.showDirectionArrow)
        {
            directionArrow.SetActive(false);
        }

        if (!apple.IsDestroyed())
        {
            apple.SetActive(false);
        }

        store.SetActive(false);

        // Hide the level 1 canvas
        level1Canvas.gameObject.SetActive(false);

        directionArrow.SetActive(false);

        isGamePaused = true; // Pause the game for us
    }
}
