using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _mSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _mSpeed = 800f;
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

        AutoNegativeMove();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("endPoint"))
        {
            // todo 
            print("도착~!");

            GameObject.Find("Win_Text").GetComponent<Text>().color = Color.black;
        }
        else if (!col.gameObject.CompareTag("side"))
        {
            _rigidbody2D.AddForce(new Vector2(0f, 500f), ForceMode2D.Force);
        }
    }

    void MoveHorizontal(float w)
    {
        if ((w < 0 && _rigidbody2D.velocity.x > -3f) || (w > 0 && _rigidbody2D.velocity.x < 3f))
        {
            _rigidbody2D.AddForce(new Vector2(w, 0f) * (Time.deltaTime * _mSpeed), ForceMode2D.Force);
        }
    }

    void AutoNegativeMove()
    {
        if (_rigidbody2D.velocity.x > 0f)
        {
            _rigidbody2D.AddForce(new Vector2(-0.5f, 0f) * (Time.deltaTime * _mSpeed), ForceMode2D.Force);
        }
        else if (_rigidbody2D.velocity.x < 0f)
        {
            _rigidbody2D.AddForce(new Vector2(0.5f, 0f) * (Time.deltaTime * _mSpeed), ForceMode2D.Force);
        }
    }
}