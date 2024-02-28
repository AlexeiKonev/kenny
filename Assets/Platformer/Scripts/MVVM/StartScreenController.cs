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
            // ��������� ����������� ������� �� ������
            startButton.OnClickAsObservable().Subscribe(_ => StartGame()).AddTo(this);
            settingsButton.OnClickAsObservable().Subscribe(_ => OpenSettings()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ExitGame()).AddTo(this);

            // ��������� ���������� ������� �� ������ �����
            soundButton.OnClickAsObservable().Subscribe(_ => ToggleSound()).AddTo(this);

            // ������������� ��������� �����
            soundManager = new SoundManager(); 
            // ������������� ��������� start
            startManager = new StartManager();
        }

        void StartGame()
        {
            startManager.StartGame();
            Debug.Log("���� ������!");
            //  
        }

        void OpenSettings()
        {
            Debug.Log("������� ���������");
            // 
        }

        void ToggleSound()
        {
            bool soundActive = soundManager.ToggleSound();
            Debug.Log("���� " + (soundActive ? "�������" : "��������"));
        }

        void ExitGame()
        {
            Debug.Log("���� ���������!");
            // ������� ����������
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }

    // ��������� ��� ��������� �����
    public interface ISoundManager
    {
        bool ToggleSound();
    }
    // ��������� ��� ��������� �����
    public interface IStartManager
    {
        void StartGame();
    }

    // ���������� ��������� �����
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
