using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

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

    [Range(1f, 10f)]
    [SerializeField] private float walkSpeed;

    [Range(3f, 15f)]
    [SerializeField] private float runSpeed;

    [Space(5f)]

    [Tooltip("How long does the mercy stay stund when she found the chiken")]
    [Range(0f, 2f)]
    [SerializeField] private float timeStund;

    [Tooltip("How often does the mercy change her direction to go to the player position (in seconds)")]
    [Range(0f, 2f)]
    [SerializeField] private float refreshPlayerPosRate;

    [Space]

    [Tooltip("Scripable object for the path the mercy will follow when she haven't found the chicken")]
    [SerializeField] public MercyPathScriptableObject path;


    [HideInInspector] private float refreshTimeLeft;
    [HideInInspector] private float timeLeftStund;
    [HideInInspector] private int index;
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public bool isAngry;
    [HideInInspector] public bool isStunded;
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
                agent.SetDestination(player.position + player.position / 10);
                refreshTimeLeft = refreshPlayerPosRate;
            }else
            {
                refreshTimeLeft -= Time.deltaTime;
            }

        }
        else
        {
            if(Vector3.Distance(path.points[index],transform.position) < 1)
            {
                index++;
                if(index >= path.points.Count)
                { 
                    index = 0;
                }
                SetNewPoint();
            }
        }

        StundCheck();
    }

    public void SetNewPoint()
    {
        agent.SetDestination(path.points[index]);
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
