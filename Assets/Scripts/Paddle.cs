using UnityEngine;

public class Paddle : MonoBehaviour {
    public float speed;
    //
    public float powerupDuration = 2f;
    float timer = 0f;
    PowerupType currentPowerup = PowerupType.None;

    void Update() {
        timer += Time.deltaTime;
        if (currentPowerup != PowerupType.None && timer > powerupDuration) {
            EndPowerup(currentPowerup);
            currentPowerup = PowerupType.None;
        }
    }

        public void PowerupActivated(PowerupType whichType) {
        timer = 0f;
        EndPowerup(currentPowerup);
        StartPowerup(whichType);
        currentPowerup = whichType;
    }

    void StartPowerup(PowerupType powerup) {
        if (powerup == PowerupType.Big) {
            var scale = transform.localScale;
            scale.x *= 1.5f;
            transform.localScale = scale;
        }
        else if (powerup == PowerupType.Small) {
            var scale = transform.localScale;
            scale.x *= 0.7f;
            transform.localScale = scale;
        }
    }
    void EndPowerup(PowerupType powerup) {
        if (powerup == PowerupType.Big) {
            var scale = transform.localScale;
            scale.x /= 1.5f;
            transform.localScale = scale;
        }
        else if (powerup == PowerupType.Small) {
            var scale = transform.localScale;
            scale.x /= 0.7f;
            transform.localScale = scale;
        }
    }

    //



    void Start() {

    }
    

    void FixedUpdate() {

        float dir = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            dir -= 1;
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            dir += 1;
        }

        Vector3 pos = transform.position;
        float newX = pos.x + dir * speed * Time.deltaTime; // inside FixUpdate Time.deltatime is interpreted as
                                                           //Time.fixdeltatime instead 
        pos.x = newX;
        pos.x = Mathf.Clamp(newX,-3.6f, 3.6f );
        transform.position = pos;




        /*float direction = Input.GetAxis("Horizontal"); //same as ??? ??? ?? ?????? ??????????? ?????????
        Vector3 delta = Vector3.right * speed * Time.deltaTime * direction;
        transform.position += delta;*/


    }
}