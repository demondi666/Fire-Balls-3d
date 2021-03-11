using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private LevelConfiguration[] _levelConfigurations;
    [SerializeField] private Texture _continueButtonTexture;

    private LevelConfiguration _level;

    public LevelConfiguration[] LevelConfigurations => _levelConfigurations;

    public void NextLevelGeneration()
    {
        LevelConfiguration _level;
        for (int i = 0; i < _levelConfigurations.Length; i++)
        {
            if (_levelConfigurations[i].LevelStarted == true)
            {
                _level = _levelConfigurations[i];
                _level.LevelPassed = true;
                _level.LevelStarted = false;
                if (i++ < _levelConfigurations.Length-1)
                {
                    _level = _levelConfigurations[i++];
                    _level.LevelStarted = true;
                    Game.Load(_level);
                }
                else
                {
                    _level.LevelStarted = false;
                    Menu.Load();
                }
            }
        }
    }
    public void RestartLevel()
    {
        for (int i = 0; i < _levelConfigurations.Length; i++)
        {
            if (_levelConfigurations[i].LevelStarted == true)
            {
                _level = _levelConfigurations[i];
                Game.Load(_level);
            }
        }
    }

}
