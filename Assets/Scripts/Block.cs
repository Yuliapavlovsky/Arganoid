using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour {
    public int hitpoints = 1;
    public bool canBeDestroyed = true;
    public BlockManager blockManager;
    //
    public GameObject powerupToSpawn = null;

    void Start() {
        if (blockManager == null) {
            blockManager = FindObjectOfType<BlockManager>();
        }
    }
    //


    private void OnCollisionEnter2D(Collision2D collision) {

        if (!canBeDestroyed)
            return;          //if cant be destroued stops executions of the function

        hitpoints--;
        if (hitpoints <= 0) {
            //
            if (powerupToSpawn != null) {
                var powerup = Instantiate(powerupToSpawn);
                powerup.transform.position = transform.position;
            }
            //

            blockManager.BlockWasDestroyed();
            Destroy(gameObject);
        }

    }
}
