using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot() 
    {
        _rb.velocity = transform.right * speed * Time.deltaTime;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player1")
        {
            PlayerHealth.TakingLives(6);
            Destroy(gameObject);
        }
        else if (collision.collider.name == "Player2") 
        {
            PlayerHealth2.TakingLives(6);
            //Destroy(gameObject);
        }
    }
}
