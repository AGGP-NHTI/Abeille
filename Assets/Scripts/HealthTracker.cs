using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public Guy character;
    Text display;

    // Start is called before the first frame update
    void Start()
    {
        display = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        display.text = character.currentHealth.ToString();
    }
}
