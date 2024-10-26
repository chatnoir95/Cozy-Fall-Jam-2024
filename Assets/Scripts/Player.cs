using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;

    private float playerSpeed;

    public static SpriteRenderer squirrel1;

    // Start is called before the first frame update
    void Start()
    {
        squirrel1 = GameObject.Find("Player Characters/Squirrel 1").GetComponent<SpriteRenderer>();

        squirrel1.sprite = Resources.Load<Sprite>("Sprites/Characters/Squirrel empty cart");

        playerSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(horizontalMovement * playerSpeed * Time.deltaTime,
            verticalMovement * playerSpeed * Time.deltaTime, 0.0f);

        // Flip the sprite image when player moves left or right
        if (horizontalMovement <= -0.1f)
        {
            squirrel1.flipX = false;
        }

        if (horizontalMovement >= 0.1f)
        {
            squirrel1.flipX = true;
        }
    }
}
