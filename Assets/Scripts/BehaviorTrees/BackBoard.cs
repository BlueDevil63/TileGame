using UnityEngine;
using System.Collections;


namespace BehaviourTree
{
    public enum personality
    {
        Aggressive,
        Defensive,
        SafetyFirst
    }


    public abstract class BlackBoard : MonoBehaviour
    {
        public GameObject target;
        //public float maxHp;
        //public float maxMp;
        //public float dHp;
        //public float dMp;
        //public float def;
        //public float level;
        public personality peronsa;
    
    }
}
