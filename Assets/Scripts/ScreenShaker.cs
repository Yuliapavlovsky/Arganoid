using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour {
    Vector3 initialPosition;
    float shake;
    public float shakeLengthSeconds;
    public float shakeMaxY;
    //TODO shake#

    public void Shake() {
        shake = 1.0f;
    }
    void Awake() {
        initialPosition = transform.position;
    }
	void Update () {
        float shakeDecay = 1 / shakeLengthSeconds * Time.deltaTime;
        shake = Mathf.Clamp01(shake - shakeDecay);
        Vector3 offset = Vector3.zero;
        offset.y = Mathf.Sin(Mathf.PI * 7 * shake) * shake * shakeMaxY;
        transform.position = initialPosition + offset;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shake();
        }
	}
}
