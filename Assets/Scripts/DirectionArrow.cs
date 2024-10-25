using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class DirectionArrow : MonoBehaviour
{
    private GameObject store;

    // Start is called before the first frame update
    void Start()
    {
        store = GameObject.Find("Store");
    }

    // Update is called once per frame
    void Update()
    {
        /* If the store's y position is equal to the player's y position and player's x position is greater than
        the store's x position */
        if (store.transform.position.x < Player.playerCharacters.transform.position.x &&
            store.transform.position.y == Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }

        /* If the store's y position is equal to the player's y position and player's x position is less than
        the store's x position */
        else if (store.transform.position.x > Player.playerCharacters.transform.position.x &&
            store.transform.position.y == Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is greater than
        the store's x position */
        else if (store.transform.position.x < Player.playerCharacters.transform.position.x &&
            store.transform.position.y < Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is greater than
        the store's x position */
        else if (store.transform.position.x < Player.playerCharacters.transform.position.x &&
            store.transform.position.y > Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is less than
        the store's x position */
        else if (store.transform.position.x > Player.playerCharacters.transform.position.x &&
            store.transform.position.y < Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 135.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is less than
        the store's x position */
        else if (store.transform.position.x > Player.playerCharacters.transform.position.x &&
            store.transform.position.y > Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -135.0f);
        }

        /* If the store's y position is less than the player's y position and player's x position is equal to
        the store's x position */
        else if (store.transform.position.x == Player.playerCharacters.transform.position.x &&
            store.transform.position.y < Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 180.0f);
        }

        /* If the store's y position is greater than the player's y position and player's x position is equal to
        the store's x position */
        else if (store.transform.position.x == Player.playerCharacters.transform.position.x &&
            store.transform.position.y > Player.playerCharacters.transform.position.y)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
