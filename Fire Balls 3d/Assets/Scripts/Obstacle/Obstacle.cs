using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private WinAndLoss _loss;

    private void Awake()
    {
        _loss = FindObjectOfType<WinAndLoss>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            _loss.IsHit = true;
        }
    }
    
}
