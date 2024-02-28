using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using System;
using UnityEngine.SceneManagement;

namespace Kenny
{
    

    public class StartScreenController : MonoBehaviour
    {
        public Button startButton;
        public Button settingsButton;
        public Button exitButton;
        public Button soundButton;

        private ISoundManager soundManager;
        private IStartManager startManager;

        void Start()
        {
            // Назначаем обработчики нажатия на кнопки
            startButton.OnClickAsObservable().Subscribe(_ => StartGame()).AddTo(this);
            settingsButton.OnClickAsObservable().Subscribe(_ => OpenSettings()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ExitGame()).AddTo(this);

            // Назначаем обработчик нажатия на кнопку звука
            soundButton.OnClickAsObservable().Subscribe(_ => ToggleSound()).AddTo(this);

            // Инициализация менеджера звука
            soundManager = new SoundManager(); 
            // Инициализация менеджера start
            startManager = new StartManager();
        }

        void StartGame()
        {
            startManager.StartGame();
            Debug.Log("Игра начата!");
            //  
        }

        void OpenSettings()
        {
            Debug.Log("Открыть настройки");
            // 
        }

        void ToggleSound()
        {
            bool soundActive = soundManager.ToggleSound();
            Debug.Log("Звук " + (soundActive ? "включен" : "выключен"));
        }

        void ExitGame()
        {
            Debug.Log("Игра завершена!");
            // Закрыть приложение
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    // Интерфейс для менеджера звука
    public interface ISoundManager
    {
        bool ToggleSound();
    }
    // Интерфейс для менеджера звука
    public interface IStartManager
    {
        void StartGame();
    }

    // Реализация менеджера звука
    public class SoundManager : ISoundManager
    {
        private bool soundActive = true;

        public bool ToggleSound()
        {
            soundActive = !soundActive;
            return soundActive;
        }
    }

    public class StartManager : IStartManager
    {
        public void StartGame()
        {
            SceneManager.LoadScene("mvvm", LoadSceneMode.Single);
        }
    }

}
