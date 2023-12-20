using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWinZone : MonoBehaviour
{
    public Transform limitL;
    public Transform limitR;

    public float x;
    public float scaleX;

    // Start is called before the first frame update
    void Start()
    {
        GenerateX();

        transform.position = new Vector3(x, 0, -7.5f);

        scaleX = Random.Range(0.2f, 0.7f);

        transform.localScale = new Vector3(scaleX, 0.220f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateX()
    {
        x = Random.Range(limitL.position.x, limitR.position.x);
    }
}
