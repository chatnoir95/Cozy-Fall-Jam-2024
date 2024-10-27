using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Pumpkin : MonoBehaviour
{
    private GameObject pumpkinKey;
    private GameObject housePartyKey1;

    public static bool showDirectionArrow;

    private bool collectedPumpkin = false;

    private bool showKeyForPumpkin;
    private bool showPumpkinKeyForStore;

    // Start is called before the first frame update
    void Start()
    {
        showDirectionArrow = false;

        pumpkinKey = GameObject.Find("Cozy Jam 2024 Pumpkin/P key pumpkin");
        housePartyKey1 = GameObject.Find("House Party/P key 1");

        pumpkinKey.SetActive(false);
        housePartyKey1.SetActive(false);

        showKeyForPumpkin = false;
        showPumpkinKeyForStore = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedPumpkin)
        {
            LookAtHouseParty();
        }

        // Show or hide the direction arrows on top of player
        if (showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(true);
        }

        else if (!showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(false);

            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        // If the player collided with the food and pressed the P key
        if (showKeyForPumpkin && Input.GetKeyDown(KeyCode.P))
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the pumpkin to 0 across all axes to hide the pumpkin from the player's view
            gameObject.transform.localScale = Vector3.zero;

            showKeyForPumpkin = false;
            collectedPumpkin = true;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            showDirectionArrow = true; // Show the direction arrow for delivery area

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Pumpkin Cart");
        }

        if (showPumpkinKeyForStore && Input.GetKeyDown(KeyCode.P) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            collectedPumpkin = false;

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            housePartyKey1.SetActive(false); // Hide the key for delivering food to store

            showDirectionArrow = false; // Set show direction arrow false to hide it

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
        }

        // Show or hide the keys for food on screen
        if (showKeyForPumpkin)
        {
            pumpkinKey.SetActive(true);
        }

        else if (!showKeyForPumpkin)
        {
            pumpkinKey.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showPumpkinKeyForStore)
        {
            housePartyKey1.SetActive(true);
        }

        else if (!showPumpkinKeyForStore)
        {
            housePartyKey1.SetActive(false);
        }
    }

    private void LookAtHouseParty()
    {
        /* If the store's y position is equal to the player's y position and player's x position is greater than
        the store's x position */
        if (SelectCharacter.houseParty.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y == SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }

        /* If the store's y position is equal to the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y == SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is greater than
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is greater than
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -315.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is equal to
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x == SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is equal to
        the store's x position */
        else if (SelectCharacter.houseParty.transform.position.x == SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.houseParty.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkin = true;
        }

        if (collision.gameObject.tag == "HouseParty")
        {
            showPumpkinKeyForStore = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkin = true;
        }

        if (collision.gameObject.tag == "HouseParty")
        {
            showPumpkinKeyForStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkin = false;
        }

        if (collision.gameObject.tag == "HouseParty")
        {
            showPumpkinKeyForStore = false;
        }
    }
}
