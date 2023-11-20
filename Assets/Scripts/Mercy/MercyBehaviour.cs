using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MercyBehaviour : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;

    [HideInInspector] public bool isAngry;
    [HideInInspector] public bool isStunded;

    [SerializeField] private float timeStund;
    private float speed;
    private float timeLeftStund;
    public MercyPathScriptableObject path;
    private int index;
    public Transform player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = agent.speed;
        timeLeftStund = timeStund;
        SetNewPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAngry)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if(Vector3.Distance(path.points[index],transform.position) < 1)
            {
                Debug.Log("Uwu");
                index++;
                if(index >= path.points.Count)
                { 
                    index = 0;
                }
                SetNewPoint();
            }
        }

        Stund();
    }

    public void SetNewPoint()
    {
        agent.SetDestination(path.points[index]);
    }

    public void Stund()
    {
        if(isStunded)
        {
            timeLeftStund -= Time.deltaTime;
            agent.speed = 0;
            if(timeLeftStund < 0)
            {
                isStunded = false;
                agent.speed = speed;
                timeLeftStund = timeStund;
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            for(int i = 0; i < col.transform.childCount; i++)
            {
                Debug.Log(i + " / " + col.transform.childCount);
                if(col.transform.GetChild(i).CompareTag("Baby"))
                {
                    if(isAngry && !isStunded)
                    {
                        Transform baby = col.transform.GetChild(i);
                        baby.parent = null;
                        baby.position = baby.GetComponent<BabyBehaviour>().startPos;
                        i--;
                        if(i == col.transform.childCount - 1)
                        {
                            isAngry = false;
                            SetNewPoint();
                        }
                    }else
                    {
                        isAngry = true;
                        isStunded = true;
                    }
                }
            }
        }
    }
}
