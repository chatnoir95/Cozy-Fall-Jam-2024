using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour
{
    private int _goldValue;
    [SerializeField] Text _goldText;



    public static GoldScript instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("careful more than one instance of GoldScript");
            return;
        }
        instance = this;
    }

    private void UpdateGoldUI() // update the amount of gold player have
    {
        _goldText.text = _goldValue.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGoldUI();
    }

    public void AddRemouveGold(int goldValueChange) // call this methode with a positiv number for earn gold, and with a negativ number for spent gold
    {
        _goldValue += goldValueChange;
        if (_goldValue < 0)
        {
            Debug.LogWarning("careful player buy something without enough money");
        }
        UpdateGoldUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
