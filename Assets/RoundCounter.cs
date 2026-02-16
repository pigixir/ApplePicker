using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int round = 1;

    private Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    void Update()
    {
        if (round > 0 && round < 5) {
            uiText.text = "Round " + round.ToString();
        } else {
            uiText.text = "Game Over";
        }

    }
}