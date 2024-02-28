using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kenny
{
    using UnityEngine;
    using UnityEngine.UI;
    using UniRx;
    using UniRx.Triggers;
    using System;

    public class StartScreenController : MonoBehaviour
    {
        public Button startButton;
        public Button settingsButton;
        public Button exitButton;

        void Start()
        {
            // Назначаем обработчики нажатия на кнопки
            startButton.OnClickAsObservable().Subscribe(_ => StartGame()).AddTo(this);
            settingsButton.OnClickAsObservable().Subscribe(_ => OpenSettings()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ExitGame()).AddTo(this);
        }

        void StartGame()
        {
            Debug.Log("Игра начата!");
            // 

        }

        void OpenSettings()
        {
            Debug.Log("Открыть настройки");
            // 


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

}
