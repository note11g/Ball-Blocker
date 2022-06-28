using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        prefab = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Rigidbody2D g = prefab.gameObject.GetComponent<Rigidbody2D>();
            g.gravityScale = 1;
            g.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
    }
}