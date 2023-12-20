using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chair : MonoBehaviour
{
    public Button possessButton;

    public Player ghost;

    public EnnemyMovementDungeon ennemy;

    public Rigidbody myRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        possessButton.onClick.AddListener(PossessChair);
    }

    private void PossessChair()
    {
        myRb.AddForce(new Vector3(0, 0.3f, 0));

        ennemy.fearValue += 0.005f;
    }
}
