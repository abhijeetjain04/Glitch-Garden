using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonS : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private ButtonS[] buttonArray;
    private Text costText;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        buttonArray = GameObject.FindObjectsOfType<ButtonS>();
        costText = GetComponentInChildren<Text>();
        if (!costText){Debug.LogWarning(name+"No costText found");}

        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
    }

    private void OnMouseDown()
    {
        foreach (ButtonS thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }

    private void CostTextUpdate()
    {
        int cost = defenderPrefab.GetComponent<Defender>().starCost;
        costText.text = cost.ToString();
    } 
}
