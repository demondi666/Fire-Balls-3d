using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private LevelConfiguration _levelConfiguration;
   

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void LoadLevel()
    {
        _levelConfiguration.LevelStarted = true;
        Game.Load(_levelConfiguration);


    }
    private void Update()
    {
        if (_levelConfiguration.LevelPassed == true)
        {
            _button.image.color = Color.red;
        }
    }


}
