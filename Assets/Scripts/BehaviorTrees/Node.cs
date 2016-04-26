using UnityEngine;
using System.Collections;

namespace BehaviourTree
{

    public abstract class Node
    {
        public enum Type
        {
            Condition,
            Action,
            Composite
        }
        public Type type;

        public virtual bool RunNode(BlackBoard bBoard)
        {
            return true;
        }
    }

    public class Root : Node
    {
        public Composite composite;
        public Root() { composite = new Composite(); }

        public void RunBehaviourTree(BlackBoard bBoard)
        {
            composite.RunNode(bBoard);
        }
    }

    public class Task : Node
    {
        public Node conditon;
        public Node Action;

        public override bool RunNode(BlackBoard bBoard)
        {
            if (conditon.RunNode(bBoard))
            {
                Action.RunNode(bBoard);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

