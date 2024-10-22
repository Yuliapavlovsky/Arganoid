using UnityEngine;

public class Ball : MonoBehaviour {
    Rigidbody2D rb;
    public Vector2 launchDir;
    public float speed;
    ScreenShaker shaker;
    Vector2 initialPosition;

    public AudioSource source;


    //
    public float minAngle;
    bool goingUp; 

    void FixedUpdate() {
        //if (rb.linearVelocity.y > 0) {
        //    goingUp = true;
        //} else {
        //    goingUp = false;
        //}
        goingUp = rb.linearVelocity.y > 0;
    }
    //
    public void ResetBall() {  //code for reseting ball, called in GameManager script
        rb.position = initialPosition;
        LaunchBall();
        //source.PlayOneShot(source.clip);
    }

    void OnCollisionExit2D(Collision2D collision) { //fixed speed so it doesnt change after collisions
        var vel = rb.linearVelocity;

        //
        Quaternion minAngleClockwise = Quaternion.Euler(0, 0, -minAngle);
        Quaternion minAngleCounterClockwise = Quaternion.Euler(0, 0, minAngle);

        if (Vector2.Angle(Vector2.left, vel) < minAngle) {
            print("going too horizontal left");
            if (goingUp) {
                print("correcting angle to left/up");
                vel = minAngleClockwise * Vector2.left;
            }
            else {
                print("correcting angle to left/down");
                vel = minAngleCounterClockwise * Vector2.left;
            }
        }
        if (Vector2.Angle(Vector2.right, vel) < minAngle) {
            print("too close to horizontal towards RIGHT");
            // TODO

            //


            rb.linearVelocity = vel.normalized * speed;
            shaker.Shake();
            //source.PlayOneShot(source.clip);

        }
    }
   
    
        
    void LaunchBall() {
        Vector2 velocity = launchDir.normalized * speed;
        rb.linearVelocity = velocity;
    }

    void Start() {
        shaker = FindAnyObjectByType<ScreenShaker>();
        rb = GetComponent<Rigidbody2D>();      
        initialPosition = rb.position;
        LaunchBall();
       
    }

     }
