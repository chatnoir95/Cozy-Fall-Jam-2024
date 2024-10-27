using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundScrolling : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed;
    [SerializeField] Renderer backGroundRenderer;
    public Transform player;
    private float width;
    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startPosition + Vector2.left * (player.position.x * scrollSpeed);
        transform.position = newPosition;

        if (transform.position.x <= player.position.x - width)
        {
            startPosition += Vector2.right * width; // Déplace le fond
        }

        //float offsetX = Camera.main.transform.position.x * scrollSpeed;
        //float offsetY = Camera.main.transform.position.y * scrollSpeed;

        //backGroundRenderer.material.mainTextureOffset = new Vector2(offsetX, offsetY);
        

    }
}
