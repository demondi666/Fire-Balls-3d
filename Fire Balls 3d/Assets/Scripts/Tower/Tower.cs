using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;

    private List<Block> _blocks;

    public List<Block> Blocks => _blocks;

    public event UnityAction<int> SizeUpdate;
    
    private void Start()
    {
        _towerBuilder = GetComponent<TowerBuilder>();
        _blocks = _towerBuilder.Build();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;

        }
        SizeUpdate?.Invoke(_blocks.Count);
    }

    private void OnBulletHit(Block enemyBlock)
    {
        enemyBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(enemyBlock);

        foreach (var block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y, block.transform.position.z);
        }
        SizeUpdate?.Invoke(_blocks.Count);
    }
   
}
