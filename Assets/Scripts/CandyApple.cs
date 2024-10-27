using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CandyApple : MonoBehaviour
{
    private GameObject cKeyCandyApple;
    private GameObject farmHouseKey;

    private bool collectedCandyApple = false;
    public static bool canCollectCandyApple = true;

    private bool showKeyForCandyApple;
    private bool showKeyForFarmHouse;

    // Start is called before the first frame update
    void Start()
    {
        cKeyCandyApple = GameObject.Find("Cozy Jam 2024 Candied Apple/C key candy apple");

        farmHouseKey = GameObject.Find("Farm House/C key");

        cKeyCandyApple.SetActive(false);

        farmHouseKey.SetActive(false);

        showKeyForCandyApple = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedCandyApple)
        {
            LookAtFarmHouse();

            Pumpkin.canCollectPumpkin = false;
            PumpkinPie.canCollectPumpkinPie = false;
            Bread.canCollectBread = false;
            HalloweenCandy.canCollectHalloweenCandy = false;
        }

        // Show or hide the direction arrows on top of player
        if (Pumpkin.showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(true);
        }

        else if (!Pumpkin.showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(false);

            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        // If the player collided with the food and pressed the C key
        if (showKeyForCandyApple && Input.GetKeyDown(KeyCode.C) && canCollectCandyApple)
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the candy apple to 0 across all axes to hide the candy apple from the player's view
            gameObject.transform.localScale = Vector3.zero;

            collectedCandyApple = true;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location

            showKeyForCandyApple = false;
            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            SelectCharacter.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Candy Apple Cart");
            SelectCharacter.squirrel2Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/GSquirrel Candy Apples");
        }

        if (showKeyForFarmHouse && Input.GetKeyDown(KeyCode.C) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            Pumpkin.canCollectPumpkin = true;
            PumpkinPie.canCollectPumpkinPie = true;
            Bread.canCollectBread = true;
            HalloweenCandy.canCollectHalloweenCandy = true;

            SFXScript.eatingSounds.clip = Resources.Load<AudioClip>("SFX/GGA_AppleBite");
            SFXScript.eatingSounds.Play();

            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            collectedCandyApple = false;

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            farmHouseKey.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            SelectCharacter.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
            SelectCharacter.squirrel2Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/GSquirrel Empty");
        }

        // Show or hide the keys for food on screen
        if (showKeyForCandyApple)
        {
            cKeyCandyApple.SetActive(true);
        }

        else if (!showKeyForCandyApple)
        {
            cKeyCandyApple.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showKeyForFarmHouse)
        {
            farmHouseKey.SetActive(true);
        }

        else if (!showKeyForFarmHouse)
        {
            farmHouseKey.SetActive(false);
        }
    }

    private void LookAtFarmHouse()
    {
        /* If the store's y position is equal to the player's y position and player's x position is greater than
        the store's x position */
        if (SelectCharacter.farmHouse.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y == SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }

        /* If the store's y position is equal to the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y == SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is greater than
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is greater than
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -315.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is equal to
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x == SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is equal to
        the store's x position */
        else if (SelectCharacter.farmHouse.transform.position.x == SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.farmHouse.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForCandyApple = true;
        }

        if (collision.gameObject.tag == "FarmHouse")
        {
            showKeyForFarmHouse = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForCandyApple = true;
        }

        if (collision.gameObject.tag == "FarmHouse")
        {
            showKeyForFarmHouse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForCandyApple = false;
        }

        if (collision.gameObject.tag == "FarmHouse")
        {
            showKeyForFarmHouse = false;
        }
    }
}
