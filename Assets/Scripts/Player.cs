using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;

    private float playerSpeed;

    public static bool canPlayerMove = true;

    // Start is called before the first frame update
    void Start()
    {
        

        playerSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        // The player can move freely whenever we set the can player move variable to true
        if (canPlayerMove == true)
        {
            transform.Translate(horizontalMovement * playerSpeed * Time.deltaTime,
                verticalMovement * playerSpeed * Time.deltaTime, 0.0f);
        }

        // Don't move the player whenever we set the can player move variable to false
        else if (canPlayerMove == false)
        {
            transform.Translate(0.0f, 0.0f, 0.0f);
        }

        // Flip the sprite image when player moves left or right
        if (horizontalMovement <= -0.1f && canPlayerMove && SelectCharacter.squirrel1.activeInHierarchy)
        {
            SelectCharacter.squirrel1Sprite.flipX = false;
        }

        else if (horizontalMovement >= 0.1f && canPlayerMove && SelectCharacter.squirrel1.activeInHierarchy)
        {
            SelectCharacter.squirrel1Sprite.flipX = true;
        }

        if (horizontalMovement <= -0.1f && canPlayerMove && SelectCharacter.squirrel2.activeInHierarchy)
        {
            SelectCharacter.squirrel2Sprite.flipX = false;
        }

        else if (horizontalMovement >= 0.1f && canPlayerMove && SelectCharacter.squirrel2.activeInHierarchy)
        {
            SelectCharacter.squirrel2Sprite.flipX = true;
        }
    }
}
