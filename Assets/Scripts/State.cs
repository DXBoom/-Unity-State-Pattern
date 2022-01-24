using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class State : ScriptableObject
    {
        public bool isFinished { get; protected set; }
        [HideInInspector] public Character Character;

        public virtual void Init() {}

        public abstract void Run();
    }
}
