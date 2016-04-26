using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    ///Composite 자식노드를 추가하고 자식 노드의 조건을 검사한다.
    ///Selector이면 검사 후 실패라면 순대로 실행 및 검사한다.
    ///성공이 나올때 까지 실행한다. 전부다 실패이면 false를 리턴한다.
    ///Sequnce는 검사 후 성공이라도 순서대로 실행한다, 순서대로 한개라도 실패하면 false를 리턴한다.
    public class Composite : Node
    {

        protected List<Node> children;
        protected int curChild;

        public List<Node> GetChildern() { return children; }
        public Composite()
        {
            children = new List<Node>();
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }
    }
    //만약 검사 후 실패라면 순서대로 실행, 성공이 나올때 까지 실행, 전부다 조건이 아니면 false
    public class Selector : Composite
    {
        public override bool RunNode(BlackBoard bBoard)
        {
            for(int i = 0; i< children.Count; i++)
            {
                if(children[i].type == Type.Condition)
                {
                    if(children[i].RunNode(bBoard))
                    {
                        if (i == children.Count - 1)
                            return true;
                        children[i + 1].RunNode(bBoard);
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
    //만약 검사 후 성공이라면 순서대로 실행, 순서대로 한개라도 실패라면 false를 리턴
    public class Sequence : Composite
    {
        public override bool RunNode(BlackBoard bBoard)
        {
            for(int i = 0; i< children.Count; i++)
            {
                if(!children[i].RunNode(bBoard))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
