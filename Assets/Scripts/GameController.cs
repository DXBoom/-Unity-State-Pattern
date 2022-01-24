using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Character.Character rSphere;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rSphere.SetState(rSphere.FreezeState);
        }
    }
}
