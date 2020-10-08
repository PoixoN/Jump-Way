using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDecorItems : MonoBehaviour
{
    public GameObject decorItem1;
    public GameObject decorItem2;
    public GameObject decorItem3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    private Vector3 GetRandomPos()
    {
        Vector3 posDItem = Camera.main.ScreenToWorldPoint(
                new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
        return posDItem;
    }

    //Instantiates decor items
    IEnumerator spawn()
    {
        while(true)
        {
            Instantiate(decorItem1, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem1, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem1, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem1, GetRandomPos(), Quaternion.Euler(0, 0, Random.Range(0f, 360f)));

            Instantiate(decorItem2, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem2, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem2, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem2, GetRandomPos(), Quaternion.Euler(0, 0, Random.Range(0f, 360f)));

            Instantiate(decorItem3, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem3, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem3, GetRandomPos(), Quaternion.Euler(0,0, Random.Range(0f, 360f)));
            Instantiate(decorItem3, GetRandomPos(), Quaternion.Euler(0, 0, Random.Range(0f, 360f)));

            yield return new WaitForSeconds(7.01f);
        }
    }
}
