using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;

    private float playerSpeed;

    public static GameObject playerCharacters;

    // Start is called before the first frame update
    void Start()
    {
        playerCharacters = GameObject.Find("Player Characters");

        playerSpeed = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        transform.Translate(horizontalMovement * playerSpeed * Time.deltaTime,
            verticalMovement * playerSpeed * Time.deltaTime, 0.0f);
    }
}
