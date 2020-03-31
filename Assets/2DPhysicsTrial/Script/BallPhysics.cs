using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Vector2 gravity = new Vector2(0, -9.8f);
    private float DeltaTime = 0.02f;

    [SerializeField]
    private float mass = 0;

    [SerializeField]
    private Vector2 velocity;

    [SerializeField]
    private Vector2 force;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector3 combineVelocity = velocity + gravity;
        transform.position = transform.position + (combineVelocity * DeltaTime);
    }

}
