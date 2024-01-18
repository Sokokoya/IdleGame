using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountUpdate : MonoBehaviour
{
    public ButtonManager Manager;

    public int Count;
    public TextMeshProUGUI CountText;

    public TextMeshProUGUI TilClickUpText;
    public int TilClickUp = 5;

    public TextMeshProUGUI TilAutoUpText;
    public int TilAutoUp = 6;


    // Start is called before the first update
    void Start()
    {
        Manager = FindObjectOfType<ButtonManager>();

        InvokeRepeating("RiseAutoCount", 0f, 1f);

        TilClickUp = 5;
        TilAutoUp = 6;
    }


    // Update is called once per frame
    void Update()
    {
        CountText.text = Count + " sheeps";

        TilClickUpText.text = "NEXT AT " + TilClickUp;
        TilAutoUpText.text = "NEXT AT " + TilAutoUp;
    }


    // The sheep count rises for each click
    private void OnMouseDown()
    {
        RiseCount(Manager.CurrentMultiplier);
    }


    // A function that rises the count of any number passed in its parameters
    private void RiseCount(int count)
    {
        Count += count;
    }


    // A function that rises the count of the autoclick multiplier
    private void RiseAutoCount()
    {
        if (Manager.AutoclickMultiplier > 0)
        {
            RiseCount(Manager.AutoclickMultiplier);
        }
    }
}


