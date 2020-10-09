using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeJump : MonoBehaviour
{
    public GameObject mainCube;
    private bool animate = false, nextBlock, lose = false;
    private float scratchSpeed = 0.6f, startTime, yPosCube;

    private void Start()
    {
        StartCoroutine(CanJump());
    }

    private void FixedUpdate()
    {
        if (animate && mainCube.transform.localScale.y > 0.55)
            PressCube(scratchSpeed);
        else if (!animate && mainCube != null)
        {
            if (mainCube.transform.localScale.y < 1)
                PressCube(scratchSpeed * -2f);
            else if (mainCube.transform.localScale.y != 1)
                mainCube.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (mainCube != null && mainCube.transform.localPosition.y < -12f)
        {
            Destroy(mainCube, 1f);
            lose = true;
            print("Player Lose");
        } 
    }

    private void PressCube(float force)
    {
        mainCube.transform.localPosition -= new Vector3(0f, force * Time.deltaTime);
        mainCube.transform.localScale -= new Vector3(0f, force * Time.deltaTime);
    }

    private void OnMouseDown()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = true;
            startTime = Time.time;

            yPosCube = mainCube.transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        if (nextBlock && mainCube.GetComponent<Rigidbody>())
        {
            animate = false;

            float force, diff = Time.time - startTime;
            if (diff < 3f)
                force = 190 * diff;
            else
                force = 300;

            if (force < 60)
                force = 60;

            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.up * force);
            mainCube.GetComponent<Rigidbody>().AddRelativeForce(mainCube.transform.right * -force);

            StartCoroutine(checkCubePos());
            nextBlock = false;
        }
    }

    IEnumerator checkCubePos()
    {
        yield return new WaitForSeconds(1.5f);
        if (mainCube.transform.localPosition.y == yPosCube)
        {
            print("Player LOSE");
            lose = true;
        }
        else
        {
            while (!mainCube.GetComponent<Rigidbody>().IsSleeping())
            {
                yield return new WaitForSeconds(0.05f);
                if (mainCube == null)
                    break;
            }

            if (!lose)
            {
                nextBlock = true;
                print("Next one");

                mainCube.transform.localPosition = new Vector3(-1f, mainCube.transform.localPosition.y, mainCube.transform.localPosition.z);
                mainCube.transform.eulerAngles = new Vector3(0f, mainCube.transform.eulerAngles.y, 0f);
            }
        }
    }

    IEnumerator CanJump()
    {
        while (!mainCube.GetComponent<Rigidbody>())
            yield return new WaitForSeconds(0.05f);
        yield return new WaitForSeconds(1f);
        nextBlock = true;
    }
}
