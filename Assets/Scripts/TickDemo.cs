using UnityEngine;

public class TickDemo : MonoBehaviour {
    public float tickTime = 2f;
    float timer = 0f;

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime; //deltaTime is time between updates(or between frames)

        while (timer > tickTime) {
            print("TICK");
            timer -= tickTime;
        }
    }
}
 /* fixed time issue
  timer -= tickTime; */


