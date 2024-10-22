using UnityEngine;

public class SimpleAudiosource : MonoBehaviour { 

    public AudioSource source;
    void Start()
    {
      //  source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //source.Play();
            source.PlayOneShot(source.clip);
        }

    }
}
