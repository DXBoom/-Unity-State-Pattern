using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    [CreateAssetMenu]
    public class EndState : State
    {
        public override void Init()
        {
            Character.StartCoroutine(ScaleDownAnimation(1.0f));
        }

        public override void Run()
        {
            
        }

        IEnumerator ScaleDownAnimation(float time)
        {
            yield return new WaitForSeconds(1.0f);
            float i = 0;
            float rate = 1 / time;

            Vector3 fromScale = Character.transform.localScale;
            Vector3 toScale = Vector3.zero;
            while (i < 1)
            {
                i += Time.deltaTime * rate;
                Character.transform.localScale = Vector3.Lerp(fromScale, toScale, i);
                yield return 0;
            }
            Character.particle.Play();
            Character.StartCoroutine(EndGame());
        }

        IEnumerator EndGame()
        {
            Character.transform.position = Character.defaultPosition;
            float totalDuration = 1.5f;

            yield return new WaitForSeconds(totalDuration);



            float i = 0;
            float rate = 1 / 1.0f;

            Vector3 fromScale = Vector3.zero;
            Vector3 toScale = new Vector3(1, 1, 1);
            Character.win.SetActive(true);

            while (i < 1)
            {
                i += Time.deltaTime * rate;
                Character.win.transform.localScale = Vector3.Lerp(fromScale, toScale, i);
                yield return 0;
            }
            Character.transform.position = Character.StartPosition;
            Character.btn.SetActive(true);
        }
    }
}
