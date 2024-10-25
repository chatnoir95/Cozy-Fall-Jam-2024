using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DirectionArrow : MonoBehaviour
{
    private GameObject store;
    private GameObject playerCharacters;

    // Start is called before the first frame update
    void Start()
    {
        store = GameObject.Find("Store");
        playerCharacters = GameObject.Find("Player Characters");
    }

    // Update is called once per frame
    void Update()
    {
        if (store.transform.position.x < playerCharacters.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }

        if (store.transform.position.x > playerCharacters.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        }
    }
}
