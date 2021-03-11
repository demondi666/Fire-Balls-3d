using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;
    private MeshRenderer _renderer;

    public event UnityAction<Block> BulletHit;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
    }
    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    public void Break()
    {
        BulletHit?.Invoke(this);
        ParticleSystemRenderer particleSystem= Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        particleSystem.material.color = _renderer.material.color;
        Destroy(gameObject);
    }
}
