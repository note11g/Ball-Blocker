using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _mSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mSpeed = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveHorizontal(-1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveHorizontal(1f);
        }
    }

    void MoveHorizontal(float w)
    {
        if ((w < 0 && _rigidbody2D.velocity.x > -3f) || (w > 0 && _rigidbody2D.velocity.x < 3f))
        {
            _rigidbody2D.AddForce(new Vector2(w, 0f) * (Time.deltaTime * _mSpeed));
        }
    }
    
    
}