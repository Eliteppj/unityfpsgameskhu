using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Melee : MonoBehaviour
{

    NavMeshAgent m_enemy = null;
    public Transform[] m_waypoints = null;
    int m_count;
    public GameObject playerhp;




    public string NPC_Name; //이름
    public int hp; // 체력
    public float walkspeed; //이동 속도

    public bool iswalking; //걷는지 안걷는지 판별
    public float walktime; // 걷는 시간
    public float waittime; // 대기 시간
    public bool isaction; //행동중인지 판별

    public float currenttime;


    public float viewangle;
    public float viewdistance;
    public LayerMask targetmask;



    public bool islive;



    ///////////////
    public Animator anim;
    public Rigidbody rigid;
    public CapsuleCollider capsuleCollider;



    private void Start()
    {
        islive = true;
        isaction = false;
        

    }



    private void Update()
    {
        checkhp();
        if (islive&& hp>=1)
        {
  
            View();
            m_enemy = GetComponent<NavMeshAgent>();
            // InvokeRepeating("MoveToNextWayPoint", 0f, 1f);

        }
        else if (!islive)
        {

        }

    }

    private void checkhp()
    {
        if(hp<=0 &&islive)
        {
            islive = false;
            anim.ResetTrigger("forward");
            anim.SetBool("death",true);
        }
    }

    public Vector3 BoundaryAngle(float _angle)
    {
        _angle += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(_angle*Mathf.Deg2Rad),0f,Mathf.Cos(_angle*Mathf.Deg2Rad));
    }

    void View()
    {
        Vector3 _leftBoundary = BoundaryAngle(-viewangle*0.5f);
        Vector3 _rightBoundary = BoundaryAngle(viewangle * 0.5f);
        Debug.DrawRay(transform.position + transform.up, _leftBoundary, Color.red);
        Debug.DrawRay(transform.position + transform.up, _rightBoundary, Color.red);


        Collider[] _target = Physics.OverlapSphere(transform.position, viewdistance, targetmask);

        for(int i = 0; i< _target.Length; i++)
        {
            Transform _targetTf = _target[i].transform;
            if(_targetTf.name=="Player")
            {
                Vector3 _direction = (_targetTf.position - transform.position).normalized;
                float _angle = Vector3.Angle(_direction, transform.forward);

                if(_angle<viewangle *0.5f)
                {
                    RaycastHit _hit;
                    if(Physics.Raycast(transform.position + transform.up, _direction, out _hit, viewdistance))
                    {
                        if(_hit.transform.name=="Player")
                        {
                            Debug.Log("시야내");
                            Debug.DrawRay(transform.position + transform.up, _direction, Color.blue);
                            anim.SetTrigger("forward");
                            m_enemy.SetDestination(_hit.transform.position);

                            if(Vector3.Distance(this.transform.position,_hit.transform.position)<=4)
                            {
                                Debug.Log("tryhit");
                                Tryhit();        
                            }
                        }     
                    }
                   
                }
                else
                {
                    anim.ResetTrigger("forward");
                }
            }

        }
    }

    private void Tryhit()
    {
        playerhp.GetComponent<PlayerStatus>().Player_HP -= 1;
    }

    private void ElapseTime()
    {
        
        if(isaction)
        {
            currenttime -= Time.deltaTime;
            if(currenttime<=0)
            {

            }
        }
    }



 
   

    void testf()
    {
        if(m_enemy.velocity== Vector3.zero)
        {
            m_enemy.SetDestination(m_waypoints[m_count++].position);

            if (m_count >= m_waypoints.Length)
            {
                m_count = 0;
            }
        }
    }
}
