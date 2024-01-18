using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button ClickButton;
    public Button AutoclickButton;

    public CountUpdate CUpdate;

    public int AutoclickMultiplier = 0;
    public int CurrentMultiplier = 1;


    // Start is called before the first update
    void Start()
    {
        CUpdate = FindObjectOfType<CountUpdate>();

        ClickButton.interactable = false;
        AutoclickButton.interactable = false;
    }
    

    // Update is called once per frame
    private void Update()
    {
        if (CUpdate.Count >= CurrentMultiplier * CurrentMultiplier * 5)
        {
            Debug.Log("bouton clic ok");
            ClickButton.interactable = true;
        }

        if ((AutoclickMultiplier == 0 && CUpdate.Count == 6) || (AutoclickMultiplier > 0 && CUpdate.Count > AutoclickMultiplier * AutoclickMultiplier * 6))
        {
            Debug.Log("bouton autoclic ok");
            AutoclickButton.interactable = true;
        }
    }


    // Upgrade of each click
    public void ClickUpgrade()
    {
        if (CUpdate.Count >= CurrentMultiplier * CurrentMultiplier * 5)
        {
            CurrentMultiplier *= 2;
            Debug.Log("uopgrade clic" + CurrentMultiplier);

            ClickButton.interactable = false;

            CUpdate.TilClickUp = CurrentMultiplier * CurrentMultiplier * 5;
        }        
    }


    // Upgrade of the autoclick
    public void AutoclickUpgrade()
    {
        if (CUpdate.Count > AutoclickMultiplier * AutoclickMultiplier * 6 || CUpdate.Count == 6)
        {
            if (AutoclickButton.interactable)
            {
                AutoclickButton.interactable = false;

                if (AutoclickMultiplier >= 2)
                {
                    AutoclickMultiplier *= 2;
                }
                else
                {
                    AutoclickMultiplier = 2;
                }
                Debug.Log("Upgrade autoclic: " + AutoclickMultiplier);

                CUpdate.TilAutoUp = AutoclickMultiplier * AutoclickMultiplier * 6 + 1;
            }
        }        
    }
}
