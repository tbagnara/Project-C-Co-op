using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform endPostionTransform;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 targetPos;
    [SerializeField] private float speed = 5f;
    [SerializeField] private bool repeating;    
    private bool movingActive;
    private int position;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = rb.transform.position;
        if (endPostionTransform != null)
        {
            endPosition = endPostionTransform.position;     
            targetPos = endPosition;            
        }
    }

    void FixedUpdate()
    {
        if (endPostionTransform == null) return;
        if (repeating == false)
        {
            switch ( position )
            {
                case 1:
                    targetPos = endPosition;
                    break;
                default:
                    targetPos = startPosition;
                    break;

            }
            Vector3 currentPos = rb.position;
            Vector3 newPos = Vector3.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }
        else
        {
            if (movingActive == true)
            {
                Vector3 currentPos = rb.position;
                Vector3 newPos = Vector3.MoveTowards(currentPos, targetPos, speed * Time.fixedDeltaTime);
                rb.MovePosition(newPos);
                if (rb.transform.position == targetPos)
                {
                    if (targetPos == startPosition)
                    {
                        targetPos = endPosition;
                    }
                    else if (targetPos == endPosition)
                    {
                        targetPos = startPosition;
                    }
                }
            }
        }
    }
    public void SwitchPosition(int pos)
    {
        position = pos;
    }
    public void OnOff()
    {
        if (movingActive == false) movingActive = true;
        else movingActive = false;
    }
}
