using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinPie : MonoBehaviour
{
    private GameObject pumpkinPieKey;
    private GameObject housePartyKey2;

    private bool collectedPumpkinPie = false;

    private bool showKeyForPumpkinPie;
    private bool showHousePartyKey;

    // Start is called before the first frame update
    void Start()
    {
        pumpkinPieKey = GameObject.Find("Cozy Jam 2024 Pumpkin Pie/P key pumpkin pie");
        housePartyKey2 = GameObject.Find("House Party/P key 2");

        pumpkinPieKey.SetActive(false);
        housePartyKey2.SetActive(false);

        showKeyForPumpkinPie = false;
        showHousePartyKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedPumpkinPie)
        {
            LookAtHouseParty();
        }

        // Show or hide the direction arrows on top of player
        if (Pumpkin.showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(true);
        }

        else if (!Pumpkin.showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(false);
        }

        // If the player collided with the food and pressed the P key
        if (showKeyForPumpkinPie && Input.GetKeyDown(KeyCode.P))
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the pumpkin to 0 across all axes to hide the pumpkin from the player's view
            gameObject.transform.localScale = Vector3.zero;

            showKeyForPumpkinPie = false;
            collectedPumpkinPie = true;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Pumpkin Pie Cart");
        }

        if (showHousePartyKey && Input.GetKeyDown(KeyCode.P) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            collectedPumpkinPie = false;

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            housePartyKey2.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
        }

        // Show or hide the keys for food on screen
        if (showKeyForPumpkinPie)
        {
            pumpkinPieKey.SetActive(true);
        }

        else if (!showKeyForPumpkinPie)
        {
            pumpkinPieKey.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showHousePartyKey)
        {
            housePartyKey2.SetActive(true);
        }

        else if (!showHousePartyKey)
        {
            housePartyKey2.SetActive(false);
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
            showKeyForPumpkinPie = true;
        }

        if (collision.gameObject.tag == "HouseParty")
        {
            showHousePartyKey = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkinPie = true;
        }

        if (collision.gameObject.tag == "HouseParty")
        {
            showHousePartyKey = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkinPie = false;
        }

        if (collision.gameObject.tag == "HouseParty")
        {
            showHousePartyKey = false;
        }
    }
}
