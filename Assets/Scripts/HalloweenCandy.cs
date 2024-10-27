using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalloweenCandy : MonoBehaviour
{
    private GameObject halloweenCandyKey;
    private GameObject superMarketKey;

    private bool collectedHalloweenCandy = false;
    public static bool canCollectHalloweenCandy = true;

    private bool showKeyForHalloweenCandy;
    private bool showSuperMarketKey;

    // Start is called before the first frame update
    void Start()
    {
        halloweenCandyKey = GameObject.Find("Halloween Candy/C key halloween candy");
        superMarketKey = GameObject.Find("Supermarket/C key 2");

        halloweenCandyKey.SetActive(false);
        superMarketKey.SetActive(false);

        showKeyForHalloweenCandy = false;
        showSuperMarketKey = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedHalloweenCandy)
        {
            LookAtSuperMarket();

            Pumpkin.canCollectPumpkin = false;
            PumpkinPie.canCollectPumpkinPie = false;
            Bread.canCollectBread = false;
            CandyApple.canCollectCandyApple = false;
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

        // If the player collided with the food and pressed the C key
        if (showKeyForHalloweenCandy && Input.GetKeyDown(KeyCode.C) && canCollectHalloweenCandy)
        {
            // Place the food object on the player
            gameObject.transform.SetParent(SelectCharacter.playerCharacters.transform, true);

            // Scale the pumpkin to 0 across all axes to hide the pumpkin from the player's view
            gameObject.transform.localScale = Vector3.zero;

            showKeyForHalloweenCandy = false;
            collectedHalloweenCandy = true;

            // DeliveryManager.instance.SpawnDeliveryArea(); // spawn the delivery target at a ramdom location 

            Pumpkin.showDirectionArrow = true; // Show the direction arrow for delivery area

            SelectCharacter.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel Halloween Candy");
            SelectCharacter.squirrel2Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/GSquirrel Halloween Candy");
        }

        if (showSuperMarketKey && Input.GetKeyDown(KeyCode.C) && SelectCharacter.directionArrow.activeInHierarchy)
        {
            Pumpkin.canCollectPumpkin = true;
            PumpkinPie.canCollectPumpkinPie = true;
            Bread.canCollectBread = true;
            CandyApple.canCollectCandyApple = true;

            SFXScript.eatingSounds.clip = Resources.Load<AudioClip>("SFX/GGA_HardCandyBite");
            SFXScript.eatingSounds.Play();

            GoldScript.instance.AddRemouveGold(10); // add gold 
            DialogueManager.instance.startDialogue(); // launch a dialogue after the delivery 

            Destroy(gameObject); // Destroy the food

            collectedHalloweenCandy = false;

            SelectCharacter.directionArrow.SetActive(false); // Hide the direction arrow after completing delivery
            superMarketKey.SetActive(false); // Hide the key for delivering food to store

            Pumpkin.showDirectionArrow = false; // Set show direction arrow false to hide it

            SelectCharacter.squirrel1Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");
            SelectCharacter.squirrel2Sprite.sprite = Resources.Load<Sprite>("Sprites/Characters/GSquirrel Empty");
        }

        // Show or hide the keys for food on screen
        if (showKeyForHalloweenCandy)
        {
            halloweenCandyKey.SetActive(true);
        }

        else if (!showKeyForHalloweenCandy)
        {
            halloweenCandyKey.SetActive(false);
        }

        // Show or hide the keys for store on screen
        if (showSuperMarketKey)
        {
            superMarketKey.SetActive(true);
        }

        else if (!showSuperMarketKey)
        {
            superMarketKey.SetActive(false);
        }
    }

    private void LookAtSuperMarket()
    {
        /* If the store's y position is equal to the player's y position and player's x position is greater than
        the store's x position */
        if (SelectCharacter.superMarket.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y == SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }

        /* If the store's y position is equal to the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y == SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is greater than
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is greater than
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x < SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 315.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is less than
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x > SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -315.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is equal to
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x == SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y < SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is equal to
        the store's x position */
        else if (SelectCharacter.superMarket.transform.position.x == SelectCharacter.playerCharacters.transform.position.x &&
            SelectCharacter.superMarket.transform.position.y > SelectCharacter.playerCharacters.transform.position.y)
        {
            SelectCharacter.directionArrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForHalloweenCandy = true;
        }

        if (collision.gameObject.tag == "SuperMarket")
        {
            showSuperMarketKey = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForHalloweenCandy = true;
        }

        if (collision.gameObject.tag == "SuperMarket")
        {
            showSuperMarketKey = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            showKeyForHalloweenCandy = false;
        }

        if (collision.gameObject.tag == "SuperMarket")
        {
            showSuperMarketKey = false;
        }
    }
}
