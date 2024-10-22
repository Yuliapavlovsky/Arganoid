using UnityEngine;
public enum PowerupType { None, Big, Small, ExtraLife };
public class Powerups : MonoBehaviour
{  public PowerupType whichType;

    void OnTriggerEnter2D(Collider2D c) {
        FindObjectOfType<GameManager>().PowerupActivated(whichType);
        Destroy(gameObject);
    }
}
