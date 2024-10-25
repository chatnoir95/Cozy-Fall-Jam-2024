using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public List<Transform> deliveryZoneAvailable = new List<Transform>();
    // Start is called before the first frame update
    [SerializeField] GameObject _deliveryZone;


    public static DeliveryManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("careful more than one instance of DeliveryManager");
            return;
        }
        instance = this;
    }

    void Start()
    {
        InitAvailableArea();
    }

    void InitAvailableArea() // fill the list of location with existing location place
    {
        deliveryZoneAvailable.Clear();

        GameObject[] areas = GameObject.FindGameObjectsWithTag("DeliveryArea1");
        foreach (GameObject area in areas)
        {
            deliveryZoneAvailable.Add(area.transform);
        }
    }

    public void SpawnDeliveryArea() // take a random location from the list, and make the target delivery apear at this place 
    { 
        int randomIndex = Random.Range(0, deliveryZoneAvailable.Count);
        
        Debug.Log(randomIndex + "  " + deliveryZoneAvailable.Count);

        _deliveryZone.transform.position = deliveryZoneAvailable[randomIndex].position;
        _deliveryZone.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
