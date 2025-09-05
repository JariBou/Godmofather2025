using System;
using _project.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _project.Scripts.Menus
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField]
        private GameObject _gameOverScreen;
        
        [SerializeField]
        private Image _panelBg;
        [SerializeField]
        private TMP_Text _stateText;

        [SerializeField] 
        private Color _winColor = new(94, 210, 90, 255);
        
        [SerializeField] 
        private Color _looseColor = new(164, 96, 96, 255);

        private void Awake()
        {
            _gameOverScreen.SetActive(false);
        }

        private void OnEnable()
        {
            GameManager.GameEnded += GameManagerOnGameEnded;
        }

        private void OnDisable()
        {
            GameManager.GameEnded -= GameManagerOnGameEnded;
        }
        
        private void GameManagerOnGameEnded(bool won)
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
            _stateText.text = won ? "GG!!" : "Git Gud :p";
            _panelBg.color = won ? _winColor : _looseColor;
        }
    }
}