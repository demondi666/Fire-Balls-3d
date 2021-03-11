using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;
using UnityEngine.EventSystems;


public class GameMenu : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Tank _tank;
    [SerializeField] private NextLevelLoader _loader;

    public void Exit()
    {
        Menu.Load();
        Time.timeScale = 1;
        _tank.IsStopped = false;
        foreach (var level in _loader.LevelConfigurations)
        {
            level.LevelStarted = false;
        }

    }
    
    public void ContinueGame()
    {
        Time.timeScale = 1;
        _tank.IsStopped = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Time.timeScale = 0;
        _tank.IsStopped = true;
    }
}
