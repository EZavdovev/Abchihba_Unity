using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distToAttack;
    [SerializeField]
    private float viewDist;
    [SerializeField]
    private float speed;
    private void Update()
    {
        if (target == null)
        {
            return;
        }
        if(Vector3.Distance(target.position, transform.position) > distToAttack && Vector3.Distance(target.position, transform.position) < viewDist)
        {
            transform.LookAt(target.transform);
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
    }
}
