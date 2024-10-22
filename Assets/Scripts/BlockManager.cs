using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    public GameManager gm;
    public int nx = 5; //amount of blocks in line
    public int ny = 5;//amount of columns
    public float dx = 2;// distance between centers of the cubes
    public float dy = 1;// distance between centers in columns
    public GameObject blockPrefab;
    public GameObject durableblockPrefab;
    public GameObject immortalblockPrefab;
    public float durableblockChance;
    public float immortallockChance;
    public Transform blockContainer;

    int destructibleBlockLeft;
//
    public float powerupChance = 0.2f;
    public GameObject[] powerupPrefabs;//


    public void BlockWasDestroyed() {
        destructibleBlockLeft--;
        gm.AddScore(100);

       if ( destructibleBlockLeft <= 0) {
            gm.LastBlockWasDestroyed();
        }
    }


    GameObject RandomizeBlocks() {
        float rnd = Random.value; // gives random value
        if (rnd < immortallockChance) {
            return immortalblockPrefab;
        }
        if (rnd < durableblockChance + immortallockChance) {
            return durableblockPrefab;
        }
        return blockPrefab;

    }

    void Start() {

        GenerateBlocks();

        destructibleBlockLeft = DestructibleBlocks(); 
        //var newBlock = Instantiate(blockPrefab);// that how uniti create a new copy of the game object
        //newBlock.transform.position = transform.position;   
    }


    void GenerateBlocks() {

        var c = transform.position;
        float x0 = c.x - (nx - 1) / 2f * dx;
        float y0 = transform.position.y;  // c.y - (ny - 1) * dy;

        for (int j = 0; j < ny; j++) {
            for (int i = 0; i < nx; i++) {
                var newBlock = Instantiate(RandomizeBlocks());// that how uniti create a new copy of the game object
                newBlock.transform.parent = blockContainer; // all genereted blocks in one parent folder called Block Holder
                float x = x0 + i * dx;
                float y = y0 - j * dy; // -j
                newBlock.transform.position =
                new Vector3(x, y, 0);

                var blockScript = newBlock.GetComponent<Block>(); // newBlock.GetComponent<Block>().blockManager = this;
                blockScript.blockManager = this; //for script Block ??
                //
                if (Random.value < powerupChance) {
                    int index = Random.Range(0, powerupPrefabs.Length);
                    blockScript.powerupToSpawn = powerupPrefabs[index];//
                }



            }
        }


    }


    int DestructibleBlocks() {  //find all destructible blocks in the game and return their ammount
        int count = 0;
        Block[] blocks = FindObjectsOfType<Block>();
        foreach (Block block in blocks) {
            if (block.canBeDestroyed) {
                count++;
            }
        }
        return count;
    }


}




