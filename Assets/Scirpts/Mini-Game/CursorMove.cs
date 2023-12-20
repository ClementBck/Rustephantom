using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorMove : MonoBehaviour
{
    public Camera mainCam;
    public Camera miniGameCam1;

    public Transform limitL;
    public Transform limitR;
    public Transform pointerLocation;

    public Button pressButton;

    public bool isStopped = false;

    public float speed = 0.01f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed;

        if (pointerLocation.position.x >= limitR.position.x)
        {
            speed = -0.01f;
        }
        
        if (pointerLocation.position.x <= limitL.position.x)
        {
            speed = 0.01f;
        }
    }

    public void StopCursor()
    {
        speed = 0f;
        isStopped = true;

        miniGameCam1.enabled = false;
        mainCam.enabled = true;

        pressButton.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "winZone" && isStopped == true)
        {
            print("GG !!");
        }
    }
}
