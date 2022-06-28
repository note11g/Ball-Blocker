using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject prefab;
    private GameObject _nowBlocker;

    private float _reloadTime = 0.0f;

    private Text _timerUIText;

    public float timerTime = 10f;
    public float controlSpeed = 1f;

    void Start()
    {
        _nowBlocker = createBlocker();
        _timerUIText = GameObject.Find("Timer").GetComponent<Text>();
    }

    void Update()
    {
        _timerUIText.text = timerTime.ToString("F2") + "s";

        if (timerTime == 0)
        {
            Text t = GameObject.Find("Win_Text").GetComponent<Text>();
            if (t.color != Color.black)
            {
                t.color = Color.black;
                t.text = "blocker win!";
            }
        }
        else if (timerTime > 0)
        {
            timerTime -= Time.deltaTime;
        }
        else
        {
            timerTime = 0;
        }

        if (_reloadTime > 0f)
        {
            _reloadTime += Time.deltaTime;
            if (_reloadTime > (0.5f / controlSpeed))
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
                _nowBlocker.transform.position = new Vector2(nowPosition.x - (0.05f * controlSpeed), nowPosition.y);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 nowPosition = _nowBlocker.transform.position;
            if (nowPosition.x <= 7.5)
            {
                _nowBlocker.transform.position = new Vector2(nowPosition.x + (0.05f * controlSpeed), nowPosition.y);
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