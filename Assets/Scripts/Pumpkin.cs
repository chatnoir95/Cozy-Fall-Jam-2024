using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Pumpkin : MonoBehaviour
{
    private GameObject pPumpkinKey;
    private GameObject pPumpkinKeyStore;

    public static bool showDirectionArrow;

    private bool showKeyForPumpkin;
    private bool showPumpkinKeyForStore;

    // Start is called before the first frame update
    void Start()
    {
        showDirectionArrow = false;

        pPumpkinKey = GameObject.Find("Cozy Jam 2024 Pumpkin/P key pumpkin");
        pPumpkinKeyStore = GameObject.Find("Store/P key store");

        pPumpkinKey.SetActive(false);
        pPumpkinKeyStore.SetActive(false);

        showKeyForPumpkin = false;
        showPumpkinKeyForStore = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Show or hide the direction arrows on top of player
        if (showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(true);
        }

        else if (!showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(false);
        }

        // If the player collided with the food and pressed the P key
        if (showKeyForPumpkin && Input.GetKeyDown(KeyCode.P))
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the pumpkin to 0 across all axes to hide the pumpkin from the player's view
            gameObject.transform.localScale = Vector3.zero;

            showKeyForPumpkin = false;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            showDirectionArrow = true; // Show the direction arrow for delivery area

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Pumpkin Cart");
        }

        if (showPumpkinKeyForStore && Input.GetKeyDown(KeyCode.P) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            pPumpkinKeyStore.SetActive(false); // Hide the key for delivering food to store

            showDirectionArrow = false; // Set show direction arrow false to hide it

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
        }

        // Show or hide the keys for food on screen
        if (showKeyForPumpkin)
        {
            pPumpkinKey.SetActive(true);
        }

        else if (!showKeyForPumpkin)
        {
            pPumpkinKey.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showPumpkinKeyForStore)
        {
            pPumpkinKeyStore.SetActive(true);
        }

        else if (!showPumpkinKeyForStore)
        {
            pPumpkinKeyStore.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForPumpkin = true;
        }

        if (collision.gameObject.tag == "Store")
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

        if (collision.gameObject.tag == "Store")
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

        if (collision.gameObject.tag == "Store")
        {
            showPumpkinKeyForStore = false;
        }
    }
}
