using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl; //

public class GameManager : MonoBehaviour {
    Ball ball; //call the script Ball

    [SerializeField] int lives = 3; //public also means that the others scripts could use and change it 
    [SerializeField] TMP_Text livesText; // serialize does the same as public exept could not be called by other scripts
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text extraLifeText;

    public GameObject highscorePrefab;
    HighScoreHolder highscoreHolder; //points to the script HighScoreHolder

    int score = 0;


    //
    public List<PowerupType> paddlePowerups;
    public Paddle paddle;
    public void PowerupActivated(PowerupType whichType) {
        if (whichType == PowerupType.ExtraLife) {
            lives++;
            UpdateLivesText();
            extraLifeText.text = "Extra life!";
        }
        else if (paddlePowerups.Contains(whichType)) {
            paddle.PowerupActivated(whichType);
        }
        else {
            Debug.LogError("unknown powerup type, can't handle");
        }
    }//



    public void AddScore(int toAdd) {
        score += toAdd;
        UpdateScoreText();
    }

    void UpdateScoreText() {
        var paddedScore = score.ToString().PadLeft(8, '0'); // score shows as 00000000
        var paddedHighscore = highscoreHolder.highscore.ToString().PadLeft(8, '0');
        var highScoreToShow = score > highscoreHolder.highscore ?
           paddedScore : paddedHighscore;
        scoreText.text = "Score:\n" + paddedScore + "\nHighscore:\n" + highScoreToShow;
    }


    public void LastBlockWasDestroyed() {
        GameOver(false);
        print("You win the game!");
    }

    void UpdateLivesText() {
        livesText.text = "Lives: " + lives; // in the place UI text it changes every time the player lose life
       
    }

    void GameOver(bool outofLives) {
        if (outofLives) {
            gameOverText.text = "Game Over!\nPress R to restart";
        }
        else 
        {
            gameOverText.text = "You win!\nPress R to restart"; 
        }
        if (score > highscoreHolder.highscore) {
            highscoreHolder.highscore = score;
        }

        Time.timeScale = 0;  //??
        //TODO game over UI

    }


    public void BallLost() {
        lives--;
        UpdateLivesText();    //as a life is lost calles change text function
        if (lives <= 0) {     // TODO: game over
            //Debug.LogError("TODO: handle game over");
            GameOver(true);

        }
        else {
            ball.ResetBall();   // if the player still have lives call ResetBall function in Ball script
        }
    }
    void Start() {
        highscoreHolder = FindAnyObjectByType<HighScoreHolder>();
        if (highscoreHolder == null) {
            var go = Instantiate(highscorePrefab);
            highscoreHolder = go.GetComponent<HighScoreHolder>();
        }

        ball = FindAnyObjectByType<Ball>();
        UpdateLivesText();//find the script
        UpdateScoreText();

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) { //code for reset the game every time R pressed
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }

}