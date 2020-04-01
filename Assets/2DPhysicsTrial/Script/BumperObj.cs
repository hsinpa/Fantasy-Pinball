using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperObj : MonoBehaviour
{
    [SerializeField]
    private float radius = 1.25f;

    [SerializeField]
    private float power = 20f;

    private Collider2D[] cacheCollider = new Collider2D[5];

    private Vector3 _position;

    private float ResetRecord = 0;
    private float ResetDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _position = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int overLapNum = Physics2D.OverlapCircleNonAlloc(_position, radius, cacheCollider, EventFlag.Layer.BallLayer);

        if (overLapNum > 0 && Time.time > ResetRecord) {
            Rigidbody2D rigidBody = cacheCollider[0].GetComponent<Rigidbody2D>();
            if (rigidBody != null)
                AddForceToObject(rigidBody);

            ResetRecord = Time.time + ResetDelay;
        }
    }

    private void AddForceToObject(Rigidbody2D rigidBody2D) {
        Vector3 direction = (rigidBody2D.transform.position - transform.position).normalized;

        Debug.Log(direction);

        rigidBody2D.velocity = (direction * power);
    }
}
