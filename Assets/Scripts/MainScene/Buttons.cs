using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    private void OnMouseDown()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
