using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform bulletPrefab;
    readonly float _delayshot = 0.2f;
    float _timer = 0;
    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (Input.GetButton("Fire2"))
        {
            if (_timer > _delayshot)
            {
                _timer = 0;
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            }
        }
    }
}
