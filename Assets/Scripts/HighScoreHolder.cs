using UnityEngine;

public class HighScoreHolder : MonoBehaviour
{
    public int highscore;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject); //will not be destroyed when we reload new game
    }

   
}
