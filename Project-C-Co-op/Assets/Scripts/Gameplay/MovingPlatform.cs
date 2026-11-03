using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform endPostion;
    private Vector3 startPosition;
    [SerializeField] private float speed = 5f;
    private int position;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.transform.position;        
    }

    void FixedUpdate()
    {
        if (endPostion == null) return;
        Vector3 targetPos;
        switch ( position )
        {
            case 1:
                targetPos = endPostion.position;
                break;
            default:
                targetPos = startPosition;
                break;

        }
        Vector3 currentPos = rb.position;
        Vector3 newPos = Vector3.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    public void SwitchPosition(int pos)
    {
        position = pos;
    }
}
