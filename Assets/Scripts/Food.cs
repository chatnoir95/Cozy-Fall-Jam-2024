using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject directionArrow;
    public static bool showDirectionArrow;

    // Start is called before the first frame update
    void Start()
    {
        directionArrow = GameObject.Find("Direction Arrow");

        showDirectionArrow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showDirectionArrow)
        {
            directionArrow.SetActive(true);
        }

        if (!showDirectionArrow)
        {
            directionArrow.SetActive(false);
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

        if (collision.gameObject.tag == "Store" && directionArrow.activeInHierarchy)
        {
            Destroy(gameObject);

            directionArrow.SetActive(false);

            showDirectionArrow = false;
        }
    }
}
