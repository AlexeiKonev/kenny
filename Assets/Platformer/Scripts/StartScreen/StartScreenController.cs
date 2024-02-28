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
    // ����������� ���������� ��� ��������� ����
    public interface ISceneManager
    {
        void LoadScene(string sceneName);
    }

    // ���������� ��������� ����
    public class SceneManager : ISceneManager
    {
        public void LoadScene(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }

    // ����������� ���������� ��� ��������� �����
    public interface ISoundManager
    {
        void ToggleSound();
    }

    // ���������� ��������� �����
    public class SoundManager : ISoundManager
    {
        private bool soundActive = true;

        public void ToggleSound()
        {
            soundActive = !soundActive;
            Debug.Log("Sound " + (soundActive ? "enabled" : "disabled"));
        }
    }

    // ���������� ���������� ������
    public class StartScreenController : MonoBehaviour
    {
        public Button startButton;
        public Button settingsButton;
        public Button exitButton;
        public Button soundButton;

        private ISceneManager sceneManager;
        private ISoundManager soundManager;

        void Start()
        {
            sceneManager = new SceneManager();
            soundManager = new SoundManager();

            // ��������� ����������� ������� �� ������
            startButton.OnClickAsObservable().Subscribe(_ => StartGame()).AddTo(this);
            settingsButton.OnClickAsObservable().Subscribe(_ => OpenSettings()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ExitGame()).AddTo(this);
            soundButton.OnClickAsObservable().Subscribe(_ => ToggleSound()).AddTo(this);
        }

        void StartGame()
        {
            sceneManager.LoadScene("GameScene");
        }

        void OpenSettings()
        {
            Debug.Log("Open settings");
        }

        void ExitGame()
        {
            Debug.Log("Exit game");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        void ToggleSound()
        {
            soundManager.ToggleSound();
        }
    }

}
