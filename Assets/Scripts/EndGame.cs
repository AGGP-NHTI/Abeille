using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text winner;
    public GameObject exitButton;

    public Guy[] players;

    private void Start()
    {
        players = FindObjectsOfType<Guy>();

        if (players[0].Player2 == true)
        {
            Guy temp = players[0];
            players[0] = players[1];
            players[1] = temp;
        }

        winner.enabled = false;
        exitButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (players[0] == null)
        {
            players[0] = FindObjectOfType<Guy>();
            if (players[0] == players[1])
            {
                ActivateEnding(2);
            }
        }
        else if (players[1] == null)
        {
            players[1] = FindObjectOfType<Guy>();
            if (players[0] == players[1])
            {
                ActivateEnding(1);
            }
        }
    }

    void ActivateEnding(int id)
    {
        winner.text = "<b>Player " + id + " wins!</b>";
        Debug.Log("End");
        winner.enabled = true;
        exitButton.SetActive(true);
        Time.timeScale = 0;
    }
}
