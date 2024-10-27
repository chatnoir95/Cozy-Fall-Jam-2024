using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinPie : MonoBehaviour
{
    private GameObject pPumpkinPieKey;
    private GameObject pPumpkinPieKeyStore;

    private bool showKeyForPumpkinPie;
    private bool showPumpkinPieKeyForStore;

    // Start is called before the first frame update
    void Start()
    {
        pPumpkinPieKey = GameObject.Find("Cozy Jam 2024 Pumpkin Pie/P key pumpkin pie");
        pPumpkinPieKeyStore = GameObject.Find("Store/P key store 4");

        pPumpkinPieKey.SetActive(false);
        pPumpkinPieKeyStore.SetActive(false);

        showKeyForPumpkinPie = false;
        showPumpkinPieKeyForStore = false;
    }

    // Update is called once per frame
    void Update()
    {
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

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            Player.squirrel1.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Pumpkin Pie Cart");
        }

        if (showPumpkinPieKeyForStore && Input.GetKeyDown(KeyCode.P) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            pPumpkinPieKeyStore.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            Player.squirrel1.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
        }

        // Show or hide the keys for food on screen
        if (showKeyForPumpkinPie)
        {
            pPumpkinPieKey.SetActive(true);
        }

        else if (!showKeyForPumpkinPie)
        {
            pPumpkinPieKey.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showPumpkinPieKeyForStore)
        {
            pPumpkinPieKeyStore.SetActive(true);
        }

        else if (!showPumpkinPieKeyForStore)
        {
            pPumpkinPieKeyStore.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkinPie = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showPumpkinPieKeyForStore = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkinPie = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showPumpkinPieKeyForStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkinPie = false;
        }

        if (collision.gameObject.tag == "Store")
        {
            showPumpkinPieKeyForStore = false;
        }
    }
}
