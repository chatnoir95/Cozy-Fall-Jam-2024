using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bread : MonoBehaviour
{
    private GameObject bBreadKey;
    private GameObject bakeryKey;

    private bool showKeyForBread;
    private bool showKeyForBakery;

    private bool collectedBread = false;
    public static bool canCollectBread = true;

    private SpriteRenderer bread1Sprite;

    // Start is called before the first frame update
    void Start()
    {
        bBreadKey = GameObject.Find("Cozy Jam 2024 Bread/B key bread 1");
        bakeryKey = GameObject.Find("Bakery/B key");

        bread1Sprite = GetComponent<SpriteRenderer>();

        bBreadKey.SetActive(false);
        bakeryKey.SetActive(false);

        showKeyForBread = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedBread)
        {
            LookAtBakery();

            Pumpkin.canCollectPumpkin = false;
            PumpkinPie.canCollectPumpkinPie = false;
            CandyApple.canCollectCandyApple = false;
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

        // If the player collided with the bread and pressed the B key
        if (showKeyForBread && Input.GetKeyDown(KeyCode.B) && canCollectBread)
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the bread to 0 across all axes to hide the bread from the player's view
            gameObject.transform.localScale = Vector3.zero;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            bread1Sprite.sortingOrder = 0;

            showKeyForBread = false;
            collectedBread = true;

            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            SelectCharacter.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Cozy Jam 2024 Bread Cart");
            SelectCharacter.squirrel2Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/GSquirrel Bread");
        }

        if (showKeyForBakery && Input.GetKeyDown(KeyCode.B) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            Pumpkin.canCollectPumpkin = true;
            PumpkinPie.canCollectPumpkinPie = true;
            CandyApple.canCollectCandyApple = true;
            HalloweenCandy.canCollectHalloweenCandy = true;

            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            collectedBread = false;

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            bakeryKey.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            SelectCharacter.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
            SelectCharacter.squirrel2Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/GSquirrel Empty");
        }

        // Show or hide the keys for food on screen
        if (showKeyForBread)
        {
            bBreadKey.SetActive(true);
        }

        else if (!showKeyForBread)
        {
            bBreadKey.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showKeyForBakery)
        {
            bakeryKey.SetActive(true);
        }

        else if (!showKeyForBakery)
        {
            bakeryKey.SetActive(false);
        }
    }

    private void LookAtBakery()
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
            showKeyForBread = true;
        }

        if (collision.gameObject.tag == "BakeryStore")
        {
            showKeyForBakery = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForBread = true;
        }

        if (collision.gameObject.tag == "BakeryStore")
        {
            showKeyForBakery = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForBread = false;
        }

        if (collision.gameObject.tag == "BakeryStore")
        {
            showKeyForBakery = false;
        }
    }
}
