using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public Transform monTransform;

    public Touch playerTouch;

    public List<bool> possessedObjects;

    public EnnemyMovement ennemy;

    public Ray detection;
    
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public Vector3 playerDestination;
    public Vector3 look;
    
    public LayerMask myLayer;
    public LayerMask objectToPossess;

    public bool isPossessing = false;

    public bool uiClick = false;

    public GameObject detectedObj;

    public string objName;

    public Button possessButton;
    public Button freeButton;
    public Button possessEnnemyButton;

    public float speed = 0.01f;
    public float distance = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        playerDestination = monTransform.position;

        freeButton.gameObject.SetActive(false);

        possessButton.gameObject.SetActive(false);

        possessEnnemyButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {      
        if (isPossessing == true)
        {
            possessButton.gameObject.SetActive(false);

            possessEnnemyButton.gameObject.SetActive(false);

            speed = 0f;

            transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            speed = 0.06f;

            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Input.touchCount > 0)
        {
            playerTouch = Input.GetTouch(0);
            if(playerTouch.phase == TouchPhase.Ended)
            {
                if (Physics.Raycast(ray, out hit, 10, myLayer) && uiClick == false)
                {
                    playerDestination = hit.point;
                    //transform.LookAt(hit.point);

                    //transform.position = playerDestination;

                }
            }
            if (EventSystem.current.IsPointerOverGameObject())
            {
                print("Clicked on the UI");
                uiClick = true;
            }
            else
            {
                uiClick = false;
            }

            
        }

        look = new Vector3(playerDestination.x, transform.position.y, playerDestination.z);
        transform.LookAt(look);

        monTransform.position = Vector3.MoveTowards(monTransform.position, playerDestination, speed);      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            possessEnnemyButton.gameObject.SetActive(true);
        }
       
        if (other.gameObject.tag == "objectToPossess")
        {
            detectedObj = other.transform.gameObject;
            objName = detectedObj.transform.name;
            possessEnnemyButton.gameObject.SetActive(false);

            possessButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ennemy")
        {
            possessEnnemyButton.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "objectToPossess")
        {
            possessButton.gameObject.SetActive(false);
        }
    }
}



