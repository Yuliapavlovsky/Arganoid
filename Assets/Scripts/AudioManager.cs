using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource sfx;

    public AudioClip ballBump;
    public AudioClip blockDestroyed;


    public void PlaySound(string ID) {
        if (ID == "BallBump") {
            sfx.PlayOneShot(ballBump);
        }
        else if (ID == "BlockDestroyed") {
            sfx.PlayOneShot(blockDestroyed);
        }
        else {
            Debug.LogError("Unknown audio ID");

            void Start() {

            }


            void Update() {

            }
        }
    }
}
