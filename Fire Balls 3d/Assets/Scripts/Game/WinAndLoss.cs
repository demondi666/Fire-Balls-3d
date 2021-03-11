using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class WinAndLoss : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Texture _continueButtonTexture;
    [SerializeField] private Texture _restartButtonTexture;
    [SerializeField] private NextLevelLoader _levelLoader;
    [SerializeField] private int offsetX;
    [SerializeField] private int offsetY;
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Tank _tank;
    [SerializeField] private ParticleSystem _salut;

    private float _buttonHeightSize;
    private float _buttonWidthSize;
    private bool _isWin;
    private bool _isLoss;
    private Camera _camera;

    public bool IsHit;
    public bool IsLoss => _isLoss;
    public bool IsWin=>_isWin;

    private void Start()
    {
        _camera = Camera.main;

        _buttonHeightSize = _camera.pixelHeight/4;
        _buttonWidthSize = _camera.pixelWidth/4 ;
    }

    private void OnEnable()
    {
        _tower.SizeUpdate += OnWin;
        
    }
    private void OnDisable()
    {
        _tower.SizeUpdate -= OnWin;
        
    }

    private void OnWin(int count)
    {
        if (count == 0)
        {
            _isWin = true;

        }
    }
    private void OnGUI()
    {
        float posX = _camera.pixelWidth / 2 - _buttonWidthSize / 2;
        float posY = _camera.pixelHeight / 2 - _buttonHeightSize / 2;
        if (_isWin == true)
        {
            _salut.gameObject.SetActive(true);
            _tank.IsStopped = true;
            
            if (GUI.Button(new Rect(posX, posY, _buttonWidthSize, _buttonHeightSize ), _continueButtonTexture))
            {
                _isWin = false;
                _salut.gameObject.SetActive(false);
                _levelLoader.NextLevelGeneration();
                
            }
        }
        if (_isLoss==true)
        {
            _tank.IsStopped = true;
            if (GUI.Button(new Rect(posX, posY, _buttonWidthSize, _buttonHeightSize), _restartButtonTexture)){
                _tank.IsStopped = false;
                _levelLoader.RestartLevel();
                _isLoss = false;
            }
        }
    }
    private void Update()
    {
        if(IsHit == true)
        {
            TakeAwayHeart();
        }
    }
    private void TakeAwayHeart()
    {
        for (int i = _hearts.Length - 1; i >= 0 ; i--)
        {
            if(_hearts[i].enabled == false && i!=0)
            {
                continue;
            }
            _hearts[i].enabled = false;
            IsHit = false;
            if (i == 0)
            {
                _isLoss = true;
            }
            break;
        }
    }
}
