using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager
{
    private int _userScores = 0;
    private static Game_Manager _instance;
    public static Game_Manager instance
    {
        get
        {

            if (_instance == null)
            {
                _instance = new Game_Manager();
            }
                return _instance;
           
        }
        
        
    }
    private Game_Manager() { }
    public delegate void EventScoreHandler(int scores);
    public event EventScoreHandler scoreEvent = delegate { };

    public void deadUnit(GameObject unit)
    {
        switch (unit.tag)
        {
            case "Player":
                gameOver ();
                break;
            case "Enemy":
                _userScores += 1;
                scoreEvent(_userScores);
                break;

        }
    }
    private void gameOver()
    {
        scoreEvent = delegate { };
        SceneManager.LoadScene(0);
    }
}
