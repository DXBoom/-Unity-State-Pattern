using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu]
    public class FreezeState : State
    {
        public override void Init()
        {
            Character.stDistance.gameObject.SetActive(true);
            Character.acceleration = 0;
            Character.StartCoroutine(StopSphere());
        }

        public override void Run()
        {

        }

        IEnumerator StopSphere()
        {
            yield return new WaitForSeconds(5.0f);
            Character.stDistance.gameObject.SetActive(false);
            Character.SetState(Character.MoveState);
        }
    }
}
