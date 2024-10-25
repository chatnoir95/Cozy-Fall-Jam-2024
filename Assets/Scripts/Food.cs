using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static bool showDirectionArrow;

    // Start is called before the first frame update
    void Start()
    {
        showDirectionArrow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(true); // changed
        }

        if (!showDirectionArrow)
        {
            SelectCharacter.directionArrow.SetActive(false); // changed
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);

            gameObject.transform.SetParent(collision.transform, true);

            showDirectionArrow = true;
        }

        if (collision.gameObject.tag == "Store" && SelectCharacter.directionArrow.activeInHierarchy) // changed
        {
            GoldScript.instance.AddRemouveGold(10); // add gold 
            Destroy(gameObject);

            SelectCharacter.directionArrow.SetActive(false); // changed

            showDirectionArrow = false;
        }
    }
}
