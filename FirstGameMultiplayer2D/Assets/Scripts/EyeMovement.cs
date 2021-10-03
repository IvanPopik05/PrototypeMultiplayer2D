using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] Transform target;
    [SerializeField] Transform center;
    Vector3 velocity;

    void Update()
    {
        if (Vector2.Distance(transform.position, center.position) < distance) // если зрачки находятся в радиусе глаз - то они следуют за персонажем
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            velocity = center.position - transform.position;
            transform.position += velocity * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(center.position, speed);
        }
    }
}
