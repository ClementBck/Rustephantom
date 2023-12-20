using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Button possessButton;

    public Player ghost;

    public Rigidbody ballRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        possessButton.onClick.AddListener(PossessBall);
    }

    private void PossessBall()
    {
        if (ghost.objName == gameObject.transform.name)
        {
            ballRb.AddForce(new Vector3(0, 0, -0.03f));
        }
    }
}
