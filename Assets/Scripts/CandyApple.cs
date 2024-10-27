using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CandyApple : MonoBehaviour
{
    private GameObject pKeyCandyApple;
    private GameObject pCandyAppleKeyStore;

    private bool showKeyForCandyApple;
    private bool showCandyAppleKeyForStore;

    // Start is called before the first frame update
    void Start()
    {
        pKeyCandyApple = GameObject.Find("Cozy Jam 2024 Candied Apple/P key candy apple");
        pCandyAppleKeyStore = GameObject.Find("Store/P key store 3");

        pKeyCandyApple.SetActive(false);
        pCandyAppleKeyStore.SetActive(false);

        showKeyForCandyApple = false;
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
        if (showKeyForCandyApple && Input.GetKeyDown(KeyCode.P))
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the candy apple to 0 across all axes to hide the candy apple from the player's view
            gameObject.transform.localScale = Vector3.zero;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location

            showKeyForCandyApple = false;
            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            Player.squirrel1.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Candy Apple Cart");
        }

        if (showCandyAppleKeyForStore && Input.GetKeyDown(KeyCode.P) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            pCandyAppleKeyStore.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            Player.squirrel1.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
        }

        // Show or hide the keys for food on screen
        if (showKeyForCandyApple)
        {
            pKeyCandyApple.SetActive(true);
        }

        else if (!showKeyForCandyApple)
        {
            pKeyCandyApple.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showCandyAppleKeyForStore)
        {
            pCandyAppleKeyStore.SetActive(true);
        }

        else if (!showCandyAppleKeyForStore)
        {
            pCandyAppleKeyStore.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForCandyApple = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showCandyAppleKeyForStore = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForCandyApple = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showCandyAppleKeyForStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForCandyApple = false;
        }

        if (collision.gameObject.tag == "Store")
        {
            showCandyAppleKeyForStore = false;
        }
    }
}
