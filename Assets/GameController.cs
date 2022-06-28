using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject prefab;
    private GameObject _nowBlocker;

    private float _reloadTime = 0.0f;

    private float _timerTime = 10f;
    private Text _timerUIText;

    private float _controlSpeed = 1f;

    void Start()
    {
        _nowBlocker = createBlocker();
        _timerUIText = GameObject.Find("Timer").GetComponent<Text>();
    }

    void Update()
    {
        _timerUIText.text = _timerTime.ToString("F2") + "s";

        if (_timerTime == 0)
        {
            GameObject.Find("Win_Text").GetComponent<Text>().color = Color.black;
            GameObject.Find("Win_Text").GetComponent<Text>().text = "blocker win!";
        }
        else if (_timerTime > 0)
        {
            _timerTime -= Time.deltaTime;
        }
        else
        {
            _timerTime = 0;
        }

        if (_reloadTime > 0f)
        {
            _reloadTime += Time.deltaTime;
            if (_reloadTime > 0.5f)
            {
                _reloadTime = 0;
                _nowBlocker = createBlocker();
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 nowPosition = _nowBlocker.transform.position;
            if (nowPosition.x >= -7.5)
            {
                _nowBlocker.transform.position = new Vector2(nowPosition.x - (0.05f * _controlSpeed), nowPosition.y);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 nowPosition = _nowBlocker.transform.position;
            if (nowPosition.x <= 7.5)
            {
                _nowBlocker.transform.position = new Vector2(nowPosition.x + (0.05f * _controlSpeed), nowPosition.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _reloadTime = Time.deltaTime;
        }
    }

    GameObject createBlocker()
    {
        GameObject myInstance = Instantiate(prefab);
        myInstance.transform.position = new Vector2(0f, 4.5f);
        myInstance.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        myInstance.SetActive(true);
        return myInstance;
    }
}