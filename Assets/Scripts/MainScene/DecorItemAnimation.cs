using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorItemAnimation : MonoBehaviour
{
    private SpriteRenderer decorItem;
    private float _movementSpeed = 0.1f;

    private void Start()
    {
        decorItem = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 6.9f);
    }

    private void Update()
    {
        decorItem.color = new Color(decorItem.color.r, decorItem.color.g, decorItem.color.b, Mathf.PingPong(Time.time / 3.5f, 1.0f));

        //Move star
        transform.position += transform.up * Time.deltaTime * _movementSpeed;
    }
}
