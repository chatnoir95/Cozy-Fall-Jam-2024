using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalMovement;
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
        float horizontalMovement = Input.GetAxis("Horizontal");

        transform.Translate(horizontalMovement * playerSpeed * Time.deltaTime, 0.0f, 0.0f);
    }
}
