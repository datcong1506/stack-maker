using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonobehaviourSingletonInterface<StackController>
{
    [SerializeField] private Vector3 offsetBetwwenStack;
    [SerializeField] private GameObject character;

    public List<GameObject> stacks = new List<GameObject>();
    
    public void AddStack(GameObject stack)
    {
        stack.GetComponent<BoxCollider>().enabled = false;
        stacks.Add(stack);
        stack.transform.SetParent(this.transform);
        stack.transform.localPosition = offsetBetwwenStack * (stacks.Count-1);

        var newChracterposision = offsetBetwwenStack * stacks.Count;
        newChracterposision.y += 0.2f;
        character.transform.localPosition = newChracterposision;    }

    public void RemoveStack(Transform attach)
    {
        if (stacks.Count > 0)
        {
            var rmStack = stacks[stacks.Count - 1];
            rmStack.GetComponent<BoxCollider>().enabled = true;
            Destroy(rmStack.GetComponent<GroundTakeAble>());
            rmStack.transform.SetParent(attach);
            rmStack.transform.localPosition = new Vector3(0, 2.9f, 0);
            rmStack.transform.localRotation=Quaternion.Euler(-90,0,0);
            
            stacks.RemoveAt(stacks.Count-1);
            var newChracterposision = offsetBetwwenStack * stacks.Count;
            newChracterposision.y += 0.2f;
            character.transform.localPosition = newChracterposision;
        }
    }
}
