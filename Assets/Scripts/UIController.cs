using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoresDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Game_Manager.instance.scoreEvent += ScoreChange;
    }
    void ScoreChange (int scores)
    {
        if (scoresDisplay != null)
            scoresDisplay.text = scores.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
