using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MercyBehaviour : MonoBehaviour
{
    [Space]

    [Header("Mercy comportement")]
    [Space(5f)]

    [Tooltip("When activate the mercy is angry when she see the chicken")]
    [SerializeField] public bool angryWithoutBaby;

    [Space]

    [Header("Mercy statistics")]
    [Space(5f)]

    [Range(0.5f, 5f)]
    [Tooltip("Mercy speed when she is calm (not angry)")]
    [SerializeField] private float walkSpeed;

    [Range(1f, 8f)]
    [Tooltip("Mercy speed when she is angry")]
    [SerializeField] private float runSpeed;

    [Space(5f)]

    [Tooltip("How long does the mercy stay stund when she found the chiken")]
    [Range(0f, 2f)]
    [SerializeField] private float timeStund;

    [Tooltip("How often does the mercy change her direction to go to the player position (in seconds)")]
    [Range(0f, 2f)]
    [SerializeField] private float refreshRate;

    [Space]

    [Header("Mercy Path")]
    [Space(5f)]
    [Tooltip("Add the gameobject with all the points in children")]
    [SerializeField] private Transform mercyPathObject;

    [Space]

    [Header("Check Mercy state")]
    [Space(5f)]
    [SerializeField] public bool isAngry;
    [SerializeField] public bool isStunded;



    [HideInInspector] private float refreshTimeLeft;
    [HideInInspector] private float timeLeftStund;
    [HideInInspector] private int index;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Transform player;



    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = walkSpeed;
        timeLeftStund = timeStund;
        SetNewPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAngry)
        {
            if(refreshTimeLeft < 0)
            {
                agent.SetDestination(player.position + (player.position / 10));
                refreshTimeLeft = refreshRate;
            }else
            {
                refreshTimeLeft -= Time.deltaTime;
            }
            agent.speed = runSpeed;
            GetComponentInChildren<Animator>().SetBool("isAngry", true);
        }
        else
        {

            if(Vector3.Distance(mercyPathObject.GetChild(index).position ,transform.position) < 1.5)
            {
                index++;
                Debug.Log(index);
                if(index >= mercyPathObject.childCount)
                { 
                    index = 0;
                }
                SetNewPoint();
            }
        }
        GetComponentInChildren<Animator>().SetFloat("moveSpeed", Vector3.Distance(agent.velocity, Vector3.zero));
        StundCheck();
    }

    public void SetNewPoint()
    {
        agent.SetDestination(mercyPathObject.GetChild(index).position);
    }

    public void StundCheck()
    {
        if(isStunded)
        {
            timeLeftStund -= Time.deltaTime;
            agent.speed = 0;
            if(timeLeftStund < 0)
            {
                isStunded = false;
                agent.speed = runSpeed;
                timeLeftStund = timeStund;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if (angryWithoutBaby)
            {
                Debug.Log("Game Over" + gameObject.name + " touched you");
            }
            else
            {
                for (int i = 0; i < col.transform.childCount; i++)
                {
                    if (col.transform.GetChild(i).CompareTag("Baby"))
                    {
                        Debug.Log("Game Over" + gameObject.name + " touched you");
                    }
                }
            }
        }
    }



    private void MercyTouched(Collision col)
    {
        for (int i = 0; i < col.transform.childCount; i++)
        {
            Debug.Log(i + " / " + col.transform.childCount);

            if (col.transform.GetChild(i).CompareTag("Baby"))
            {
                if (isAngry && !isStunded)
                {
                    //Replace the baby
                    Transform baby = col.transform.GetChild(i);
                    baby.parent = null;
                    baby.position = baby.GetComponent<BabyBehaviour>().startPos;
                    i--;
                    if (i == col.transform.childCount - 1)
                    {
                        isAngry = false;
                        SetNewPoint();
                    }
                }
                else
                {
                    isAngry = true;
                    isStunded = true;
                }
            }
        }
    }
}
