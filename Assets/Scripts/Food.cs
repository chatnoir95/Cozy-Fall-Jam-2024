using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Food : MonoBehaviour
{
    private GameObject pKeyApple;
    private GameObject pKeyStore;

    public static bool showDirectionArrow;

    private bool showKeyForFood;
    private bool showKeyForStore;

    // Start is called before the first frame update
    void Start()
    {
        showDirectionArrow = false;

        pKeyApple = GameObject.Find("Apple/P key apple");
        pKeyStore = GameObject.Find("Store/P key store");

        pKeyApple.SetActive(false);
        pKeyStore.SetActive(false);

        showKeyForFood = false;
        showKeyForStore = false;
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
        if (showKeyForFood && Input.GetKeyDown(KeyCode.P))
        {
            // Place the food object on the player
            gameObject.transform.SetParent(Player.playerCharacters.transform, true);
            
           // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 
            
            showDirectionArrow = true; // Show the direction arrow for delivery area
        }

        if (showKeyForStore && Input.GetKeyDown(KeyCode.P) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue();

            Destroy(gameObject); // Destroy the food

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            pKeyStore.SetActive(false); // Hide the key for delivering food to store

            showDirectionArrow = false; // Set show direction arrow false to hide it
        }

        // Show or hide the keys for food on screen
        if (showKeyForFood)
        {
            pKeyApple.SetActive(true);
        }

        else if (!showKeyForFood)
        {
            pKeyApple.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showKeyForStore)
        {
            pKeyStore.SetActive(true);
        }

        else if (!showKeyForStore)
        {
            pKeyStore.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForFood = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showKeyForStore = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForFood = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showKeyForStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForFood = false;
        }

        if (collision.gameObject.tag == "Store")
        {
            showKeyForStore = false;
        }
    }
}
