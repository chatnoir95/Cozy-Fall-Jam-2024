using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    private Canvas characterSelectorCanvas;
    private Canvas level1Canvas;

    public static GameObject playerCharacters;

    public static GameObject squirrel1, squirrel2;
    public static SpriteRenderer squirrel1Sprite, squirrel2Sprite;

    public static GameObject directionArrow;

    private GameObject pumpkin, pumpkinPie, bread1, candyApple, halloweenCandy;
    public static GameObject bakery, farmHouse, houseParty, superMarket, home;

    private bool isGamePaused;

    private Text signControlsText;

    private AudioSource gameMusic;

    private List<float> gameMusicClipTime;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the canvas objects to find our objects inside the scene
        characterSelectorCanvas = GameObject.Find("Character Select Canvas").GetComponent<Canvas>();
        level1Canvas = GameObject.Find("Level Canvas").GetComponent<Canvas>();

        playerCharacters = GameObject.Find("Player Characters");

        // These squirrels are just prototype objects, we don't have squirrel sprites just yet
        squirrel1 = GameObject.Find("Player Characters/Squirrel 1");
        squirrel2 = GameObject.Find("Player Characters/Squirrel 2");

        squirrel1Sprite = GameObject.Find("Player Characters/Squirrel 1").GetComponent<SpriteRenderer>();
        squirrel2Sprite = GameObject.Find("Player Characters/Squirrel 2").GetComponent<SpriteRenderer>();

        directionArrow = GameObject.Find("Player Characters/Direction Arrow");

        pumpkin = GameObject.Find("Cozy Jam 2024 Pumpkin");
        bread1 = GameObject.Find("Cozy Jam 2024 Bread");
        candyApple = GameObject.Find("Cozy Jam 2024 Candied Apple");
        pumpkinPie = GameObject.Find("Cozy Jam 2024 Pumpkin Pie");
        halloweenCandy = GameObject.Find("Halloween Candy");

        bakery = GameObject.Find("Bakery");
        farmHouse = GameObject.Find("Farm House");
        houseParty = GameObject.Find("House Party");
        superMarket = GameObject.Find("Supermarket");
        home = GameObject.Find("Home");

        signControlsText = GameObject.Find("Character Select Canvas/Sign Controls Text").GetComponent<Text>();

        gameMusic = GameObject.Find("GameMusic").GetComponent<AudioSource>();

        // Let's hide the squirrels at start
        squirrel1.SetActive(false);
        squirrel2.SetActive(false);

        playerCharacters.SetActive(false);

        directionArrow.SetActive(false);

        bakery.SetActive(false);
        farmHouse.SetActive(false);
        houseParty.SetActive(false);
        superMarket.SetActive(false);
        home.SetActive(false);

        pumpkin.SetActive(false);
        bread1.SetActive(false);
        candyApple.SetActive(false);
        pumpkinPie.SetActive(false);
        halloweenCandy.SetActive(false);

        // Show the character selector canvas but hide level 1 canvas
        characterSelectorCanvas.gameObject.SetActive(true);
        level1Canvas.gameObject.SetActive(false);

        signControlsText.gameObject.SetActive(false);

        // We want to set game paused to true at start of game
        isGamePaused = true;

        // Play the first cozy track
        gameMusic.clip = Resources.Load<AudioClip>("Music/GGA_CozyTrack_1");

        gameMusicClipTime = new List<float> { 0.0f, 0.0f };
    }

    // Update is called once per frame
    void Update()
    {
        // Set the game music time equal to the first clip time to resume playing the first music
        if (gameMusic.time <= 0.0f && gameMusic.clip == Resources.Load<AudioClip>("Music/GGA_CozyTrack_1"))
        {
            gameMusic.time = gameMusicClipTime[0];
        }

        // Set the game music time equal to the second clip time to resume playing the second music
        else if (gameMusic.time <= 0.0f && gameMusic.clip == Resources.Load<AudioClip>("Music/GGA_CozyTrack_2"))
        {
            gameMusic.time = gameMusicClipTime[1];
        }

        // If the game music clip is equal to the first track, increment the first music clip timer
        if (gameMusic.clip == Resources.Load<AudioClip>("Music/GGA_CozyTrack_1"))
        {
            gameMusicClipTime[0] = gameMusic.time;
            gameMusicClipTime[1] += 0.0f;

            //Debug.Log(gameMusicClipTime[0] + " : " + gameMusicClipTime[1]);

            // Reset the first clip timer once it's equal to the length of the first track
            if (gameMusicClipTime[0] > 32.064f)
            {
                gameMusicClipTime[0] = 0.0f;
            }
        }

        // If the game music clip is equal to the second track, increment the second music clip timer
        else if (gameMusic.clip == Resources.Load<AudioClip>("Music/GGA_CozyTrack_2"))
        {
            gameMusicClipTime[0] += 0.0f;
            gameMusicClipTime[1] = gameMusic.time;

            //Debug.Log(gameMusicClipTime[0] + " : " + gameMusicClipTime[1]);

            // Reset the second clip timer once it's equal to the length of the second track
            if (gameMusicClipTime[1] > 37.2f)
            {
                gameMusicClipTime[1] = 0.0f;
            }
        }

        // If the game music isn't playing, then play the game music for us
        if (!gameMusic.isPlaying)
        {
            gameMusic.Play();
        }

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

        playerCharacters.SetActive(true);

        // Show the 1st squirrel in gameplay when player presses squirrel 1 button (hide others just in case)
        squirrel1.SetActive(true);
        squirrel2.SetActive(false);

        if (Pumpkin.showDirectionArrow)
        {
            directionArrow.SetActive(true);
        }

        if (!pumpkin.IsDestroyed())
        {
            pumpkin.SetActive(true);
        }

        if (!bread1.IsDestroyed())
        {
            bread1.SetActive(true);
        }

        if (!candyApple.IsDestroyed())
        {
            candyApple.SetActive(true);
        }

        if (!pumpkinPie.IsDestroyed())
        {
            pumpkinPie.SetActive(true);
        }

        if (!halloweenCandy.IsDestroyed())
        {
            halloweenCandy.SetActive(true);
        }

        bakery.SetActive(true); // delivery location will spawn at a random location after picking item
        farmHouse.SetActive(true);
        houseParty.SetActive(true);
        superMarket.SetActive(true);
        home.SetActive(true);

        // Show the level 1 canvas
        level1Canvas.gameObject.SetActive(true);

        isGamePaused = false; // Resume the game for us

        // Play the second cozy track
        gameMusic.clip = Resources.Load<AudioClip>("Music/GGA_CozyTrack_2");
    }

    public void PressSquirrel2Button()
    {
        // Hide the character selector canvas
        characterSelectorCanvas.gameObject.SetActive(false);

        playerCharacters.SetActive(true);

        // Show the 2nd squirrel in gameplay when player presses squirrel 2 button (hide others just in case)
        squirrel1.SetActive(false);
        squirrel2.SetActive(true);

        if (Pumpkin.showDirectionArrow)
        {
            directionArrow.SetActive(true);
        }

        if (!pumpkin.IsDestroyed())
        {
            pumpkin.SetActive(true);
        }

        if (!bread1.IsDestroyed())
        {
            bread1.SetActive(true);
        }

        if (!candyApple.IsDestroyed())
        {
            candyApple.SetActive(true);
        }

        if (!pumpkinPie.IsDestroyed())
        {
            pumpkinPie.SetActive(true);
        }

        if (!halloweenCandy.IsDestroyed())
        {
            halloweenCandy.SetActive(true);
        }

        bakery.SetActive(true);
        farmHouse.SetActive(true);
        houseParty.SetActive(true);
        superMarket.SetActive(true);
        home.SetActive(true);

        // Show the level 1 canvas
        level1Canvas.gameObject.SetActive(true);

        isGamePaused = false; // Resume the game for us

        // Play the second cozy track
        gameMusic.clip = Resources.Load<AudioClip>("Music/GGA_CozyTrack_2");
    }

    public void PressCharacterSelectorButton()
    {
        // Show the character selector canvas
        characterSelectorCanvas.gameObject.SetActive(true);

        playerCharacters.SetActive(false);

        // Hide all the squirrels
        squirrel1.SetActive(false);
        squirrel2.SetActive(false);

        if (Pumpkin.showDirectionArrow)
        {
            directionArrow.SetActive(false);
        }

        if (!pumpkin.IsDestroyed())
        {
            pumpkin.SetActive(false);
        }

        if (!bread1.IsDestroyed())
        {
            bread1.SetActive(false);
        }

        if (!candyApple.IsDestroyed())
        {
            candyApple.SetActive(false);
        }

        if (!pumpkinPie.IsDestroyed())
        {
            pumpkinPie.SetActive(false);
        }

        if (!halloweenCandy.IsDestroyed())
        {
            halloweenCandy.SetActive(false);
        }

        bakery.SetActive(false);
        farmHouse.SetActive(false);
        houseParty.SetActive(false);
        superMarket.SetActive(false);
        home.SetActive(false);

        // Hide the level 1 canvas
        level1Canvas.gameObject.SetActive(false);

        directionArrow.SetActive(false);

        isGamePaused = true; // Pause the game for us

        // Play the first cozy track
        gameMusic.clip = Resources.Load<AudioClip>("Music/GGA_CozyTrack_1");
    }

    public void OnMouseDown()
    {
        if (signControlsText.gameObject.activeInHierarchy)
        {
            signControlsText.gameObject.SetActive(false);
        }

        else if (!signControlsText.gameObject.activeInHierarchy)
        {
            signControlsText.gameObject.SetActive(true);
        }
    }
}
