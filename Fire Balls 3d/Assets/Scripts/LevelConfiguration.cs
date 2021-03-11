using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="NewConfig", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private int _towerSize;
    [SerializeField] private ObstaclePattern _obstaclePattern;
    [SerializeField] private Block _blockPattern;

    public bool LevelStarted; 
    public bool LevelPassed;
    public int TowerSize => _towerSize;
    public ObstaclePattern ObstaclePattern => _obstaclePattern;
    public Block BlockPattern => _blockPattern;

}
