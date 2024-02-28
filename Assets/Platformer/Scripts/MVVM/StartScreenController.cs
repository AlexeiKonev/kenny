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
            // ��������� ����������� ������� �� ������
            startButton.OnClickAsObservable().Subscribe(_ => StartGame()).AddTo(this);
            settingsButton.OnClickAsObservable().Subscribe(_ => OpenSettings()).AddTo(this);
            exitButton.OnClickAsObservable().Subscribe(_ => ExitGame()).AddTo(this);
        }

        void StartGame()
        {
            Debug.Log("���� ������!");
            // 

        }

        void OpenSettings()
        {
            Debug.Log("������� ���������");
            // 


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

}
