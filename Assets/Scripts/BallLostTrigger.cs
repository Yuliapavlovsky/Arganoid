using UnityEngine;

public class BallLostTrigger : MonoBehaviour {
    GameManager gm; //call the script GameManager

    private void OnTriggerEnter2D(Collider2D collision) {
        gm.BallLost(); //as ball enter the collider call for BallLost function
    }

    void Start() {
        gm = FindAnyObjectByType<GameManager>(); //fint the script
    }
}

   