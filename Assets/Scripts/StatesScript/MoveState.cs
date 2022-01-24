using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu]
    public class MoveState : State
    {
        private Vector3 oldPosition = new Vector3(0, 0, 0);

        public override void Init()
        {

        }

        public override void Run()
        {
            if (isFinished)
                return;

            SphereMovement();
            
        }

        void SphereMovement()
        {
            Character.StartCoroutine(changeColor());

            Character.transform.localScale = new Vector3(1, 1, 1);
            Quaternion direction = Quaternion.LookRotation(Character.EndPosition - Character.StartPosition) * Quaternion.Euler(90f, 0f, 0f);

            float nrm = Character.timer / Character.TimeToArive;

            oldPosition = Character.transform.position;

            Character.transform.position = Vector3.Lerp(Character.StartPosition, Character.EndPosition, nrm) + 
                direction * Quaternion.Euler(0f, Mathf.Lerp(0, Character.EndAngle, Character.timer / Character.TimeToArive), 0f) * Vector3.right *
                Mathf.Lerp(Character.StartRadius, Character.EndRadius, nrm) * Mathf.Lerp(Character.EndRadius, Character.StartRadius, nrm);

            Character.dist += Vector3.Distance(oldPosition, Character.transform.position);

            Character.acceleration = Mathf.Lerp(Character.acceleration, 1.0f, Time.deltaTime * 1.0f);

            Character.timer += Time.deltaTime * Character.acceleration;

            if (Character.transform.position == Character.EndPosition)
            {
                Character.SetState(Character.EndState);
            }
        }

        IEnumerator changeColor()
        {
            while (true)
            {
                Character.rgbMat.color = new Color(Character.transform.position.x,
                    Character.transform.position.y,
                    Character.transform.position.z);

                yield return null;
            }
        }
    }
}
