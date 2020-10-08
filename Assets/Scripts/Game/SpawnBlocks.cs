using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour
{
    public GameObject block;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        blockPos = new Vector3(Random.Range(0.8f, 1.6f), Random.Range(-2.8f, 0.9f));
        blockInst = Instantiate(block, new Vector3(3.7f, -6f), Quaternion.identity);
        blockInst.transform.localScale = new Vector3(Random.Range(1f, 2f), blockInst.transform.localScale.y, blockInst.transform.localScale.z);
    }

    private void Update()
    {
        if (blockInst.transform.position != blockPos)
        {
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        }
    }
}
