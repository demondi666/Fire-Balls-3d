using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class TowerBuilder : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private float _towerSize;
    [SerializeField] private Transform _buildPoint;
    [SerializeField] private Block _block;
    [SerializeField] private Color[] _colors;
    [SerializeField] private Transform _obstaclePoint;
    [SerializeField] private ObstaclePattern _obstaclePattern;
 
    private List<Block> _blocks;

    private void Start()
    {
        Instantiate(_obstaclePattern, _obstaclePoint);
    }

    public List<Block> Build()
    {
        _blocks = new List<Block>();

        Transform currentPoint = _buildPoint;
        for (int i = 0; i < _towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(_colors[Random.Range(0, _colors.Length)]);
            _blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }
        return _blocks;
    }

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        _towerSize = argument.TowerSize;
        _block = argument.BlockPattern;
        _obstaclePattern = argument.ObstaclePattern;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(_block, GetBuildPoint(currentBuildPoint), Quaternion.identity, _buildPoint);
    }
    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(_buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 2 + _block.transform.localScale.y / 2, _buildPoint.position.z);
    }
}
