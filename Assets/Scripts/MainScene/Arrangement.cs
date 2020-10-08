using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrangement : MonoBehaviour
{
    public GameObject[] cubes;
    public Animation cubes_anim, startBlockResize_anim;
    public GameObject buttons, mainCube, spawnBlocks;
    public Light dirLight1, dirLight2;
    public Text playTxt, gameName;

    private bool clicked = false;

    private void Update()
    {
        if (clicked && dirLight1.intensity != 0)
            dirLight1.intensity -= 0.03f;
        if (clicked && dirLight2.intensity >= 0.8)
            dirLight2.intensity -= 0.025f;
    }

    private void OnMouseDown()
    {
        if (!clicked)
        {
            StartCoroutine(delCubes());
            clicked = true; //Works only once
            playTxt.gameObject.SetActive(false);
            gameName.text = "0";
            buttons.GetComponent<ScrollObjects>().speed = -10f;
            buttons.GetComponent<ScrollObjects>().chekPos = -150;
            mainCube.GetComponent<Animation>().Play("StartGameCube");
            StartCoroutine(cubeToBlock());
            mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
            cubes_anim.Play("CubesPosition");
        }
    }

    IEnumerator delCubes()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.5f);
            cubes[i].GetComponent<FallCube>().enabled = true;
        }

        spawnBlocks.GetComponent<SpawnBlocks>().enabled = true;
    }

    IEnumerator cubeToBlock()
    {
        yield return new WaitForSeconds(mainCube.GetComponent<Animation>().clip.length + 1f);
        startBlockResize_anim.Play();
    }
}
