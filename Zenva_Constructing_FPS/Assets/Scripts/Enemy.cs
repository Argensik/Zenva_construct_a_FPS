using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public int curHp;
    public int maxHp;
    public int scoreToGive;

    [Header("Movement")]
    public float moveSpeed;
    public float attackRange;
    public float yPathOffset;

    List<Vector3> path;

    Weapon weapon;
    GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        //get the components
        weapon = GetComponent<Weapon>();
        target = FindObjectOfType<Player>().gameObject;

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        ChaseTarget();
    }

    void ChaseTarget()
    {
        //move towards the closes path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if (transform.position == path[0] + new Vector3(0, yPathOffset, 0)) ;
    }

    void UpdatePath()
    {
        // calculate a path to our target
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        // save that as a list
        path = navMeshPath.corners.ToList();
    }
}
