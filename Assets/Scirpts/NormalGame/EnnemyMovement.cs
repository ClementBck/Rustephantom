using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyMovement : MonoBehaviour
{
    public Camera mainCam;
    public Camera miniGameCam1;

    private Animator anim;

    public GameObject chest;
    public GameObject mirror;
    public GameObject cupboard;
    public GameObject drawers;
    public GameObject pot;
    public GameObject flowers;

    public Mirror possessedMirror;
    
    public List<Transform> waypointList;
    private Transform currentWP => waypointList[choice];
    public LayerMask myLayer;

    private Renderer rend;

    public bool isActive = true;
    public bool isPossessed = false;
    public bool isScared = false;

    public Vector3 lookPosition;

    public int choice;
    public int idleChance;

    public float speed = 0.005f;
    public float distance = 1.2f;
    public float timerA = 5f;
    public float timerPossession = 10f;
    public float fearValue;

    public Button possessEnnemyButton;
    public Button freeButton;
    public Button miniGameButton;

    public Slider fearBar;

    public Canvas victoryMessage;

    public Ray detect;

    public Light lanternLight;

    public Player player;

    public Slider possessionBar;

    // Start is called before the first frame update
    void Start()
    {
        ResetChoice();

        anim = GetComponent<Animator>();

        victoryMessage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fearBar.value = fearValue;

        if (isActive == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWP.position, speed);
            transform.LookAt(currentWP.position);
        }
        else
        {
            timerA -= Time.deltaTime;
            
            if (timerA <= 0)
            {
                timerA = 5f;
                isActive = true;
            }
        }

        detect = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        if (Physics.Raycast(detect, out hit, distance, myLayer))
        {
            var hitObj = hit.transform.gameObject; 

            if (hitObj.tag == "isPossessed")
            {
                isFeared();
            }


        }

        if(fearValue >= 100)
        {
            Destroy(gameObject);

            victoryMessage.gameObject.SetActive(true);

            fearBar.gameObject.SetActive(false);

            DatasScenes.chamber1Won = true;
        }

        if (isPossessed == true)
        {
            speed = 0.01f;

            freeButton.gameObject.SetActive(true);

            timerPossession -= Time.deltaTime;

            fearValue += 0.005f;

            possessionBar.gameObject.SetActive(true);
            possessionBar.value = timerPossession;
        }
        else
        {
            speed = 0.02f;

            freeButton.gameObject.SetActive(false);

            possessionBar.gameObject.SetActive(false);

            timerPossession = 10f;
        }

        possessEnnemyButton.onClick.AddListener(PlayerPossessEnnemy);

        freeButton.onClick.AddListener(PlayerLeavesBody);
    }

    private void ResetChoice()
    {
        choice = Random.Range(0, waypointList.Count);

        isActive = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        var otherIndex = waypointList.IndexOf(other.transform);
        if(otherIndex <0 || otherIndex != choice)
        {
            return;
        }
        while(choice == otherIndex)
        {
            print("oui" + choice);
            ResetChoice();
        }

        if (other.gameObject.tag == "chest")
        {
            lookPosition = new Vector3(chest.transform.position.x, transform.position.y, chest.transform.position.z);
            transform.LookAt(lookPosition);
            isActive = false;
            Invoke("ResetChoice", 5f);
        }

        if (other.gameObject.tag == "mirror")
        {
            lookPosition = new Vector3(mirror.transform.position.x, transform.position.y, mirror.transform.position.z);
            transform.LookAt(lookPosition);
            isActive = false;
            Invoke("ResetChoice", 5f);
        }

        if (other.gameObject.tag == "cupboard")
        {
            lookPosition = new Vector3(cupboard.transform.position.x, transform.position.y, cupboard.transform.position.z);
            transform.LookAt(lookPosition);
            isActive = false;
            Invoke("ResetChoice", 5f);
        }

        if (other.gameObject.tag == "drawers")
        {
            lookPosition = new Vector3(drawers.transform.position.x, transform.position.y, drawers.transform.position.z);
            transform.LookAt(lookPosition);
            isActive = false;
            Invoke("ResetChoice", 5f);
        }

        if (other.gameObject.tag == "pot")
        {
            lookPosition = new Vector3(pot.transform.position.x, transform.position.y, pot.transform.position.z);
            transform.LookAt(lookPosition);
            isActive = false;
            Invoke("ResetChoice", 5f);
        }

        if (other.gameObject.tag == "flowers")
        {
            lookPosition = new Vector3(flowers.transform.position.x, transform.position.y, flowers.transform.position.z);
            transform.LookAt(lookPosition);
            isActive = false;
            Invoke("ResetChoice", 5f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            ResetChoice();
        }
    }

    private void PlayerPossessEnnemy()
    {
        isPossessed = true;

        player.isPossessing = true;

        Invoke("PlayerLeavesBody", 10f);
    }

    private void PlayerLeavesBody()
    {
        isPossessed = false;

        player.isPossessing = false;
        timerPossession = 10f;
    }

    private void isFeared()
    {
        print("VU !!!! ");

        isActive = true;

        fearValue += 20;

        ResetChoice();

        anim.SetTrigger("Scared");

        isScared = true;
    }

}
