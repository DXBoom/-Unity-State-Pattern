using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [Header("Main Settings")]
        public Material rgbMat;
        public Text tDistance;
        public Text stDistance;

        public GameObject btn;
        public GameObject win;

        [Header("States")]
        public State StartState;
        public State MoveState;
        public State FreezeState;
        public State EndState;

        [Header("Actual State")]
        public State CurrentState;

        [Header("Vectors")]
        public Vector3 StartPosition = new Vector3(0, 10, 0);
        public Vector3 EndPosition = new Vector3(0, 1, 0);
        public Vector3 defaultPosition = new Vector3(0, 0, 0);

        [Header("Movement Settings")]
        public float StartRadius = 2.5f;
        public float EndRadius = 0f;
        public float TimeToArive = 5f;
        public float EndAngle = 1000f;
        public float dist = 0;
        public float acceleration;
        public float timer;

        [Header("Particles")]
        public ParticleSystem particle;

        void Start()
        {
            SetState(StartState);
        }

        void Update()
        {
            if (!CurrentState.isFinished)
            {
                CurrentState.Run();
            }

            tDistance.text = "Distance: " + dist.ToString("0");
            stDistance.text = "Distance: " + dist.ToString("0");
        }

        public void SetState(State state)
        {
            CurrentState = Instantiate(state);
            CurrentState.Character = this;
            CurrentState.Init();
        }

        public void StartGame()
        {
            dist = 0;
            acceleration = 0;
            timer = 0;
            rgbMat.color = new Color(defaultPosition.x,
                defaultPosition.y,
                defaultPosition.z);
            btn.SetActive(false);
            stDistance.gameObject.SetActive(false);
            win.SetActive(false);
            SetState(MoveState);
        }
    }
}
