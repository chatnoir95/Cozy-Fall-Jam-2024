using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    private GameObject pKeyBread1;
    private GameObject pBreadKeyStore;

    private bool showKeyForBread1;
    private bool showBreadKeyForStore;

    private SpriteRenderer bread1Sprite;

    // Start is called before the first frame update
    void Start()
    {
        pKeyBread1 = GameObject.Find("Cozy Jam 2024 Bread/B key bread 1");
        pBreadKeyStore = GameObject.Find("Store/B key store");

        bread1Sprite = GetComponent<SpriteRenderer>();

        pKeyBread1.SetActive(false);
        pBreadKeyStore.SetActive(false);

        showKeyForBread1 = false;
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

        // If the player collided with the bread and pressed the B key
        if (showKeyForBread1 && Input.GetKeyDown(KeyCode.B))
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            bread1Sprite.sortingOrder = 0;

            showKeyForBread1 = false;
            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Cozy Jam 2024 Bread Cart");
        }

        if (showBreadKeyForStore && Input.GetKeyDown(KeyCode.B) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            pBreadKeyStore.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            Player.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
        }

        // Show or hide the keys for food on screen
        if (showKeyForBread1)
        {
            pKeyBread1.SetActive(true);
        }

        else if (!showKeyForBread1)
        {
            pKeyBread1.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showBreadKeyForStore)
        {
            pBreadKeyStore.SetActive(true);
        }

        else if (!showBreadKeyForStore)
        {
            pBreadKeyStore.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForBread1 = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showBreadKeyForStore = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForBread1 = true;
        }

        if (collision.gameObject.tag == "Store")
        {
            showBreadKeyForStore = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForBread1 = false;
        }

        if (collision.gameObject.tag == "Store")
        {
            showBreadKeyForStore = false;
        }
    }
}
