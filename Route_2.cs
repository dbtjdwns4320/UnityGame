using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route_2 : MonoBehaviour
{
    Transform[] childObjects_2;
    public List<Transform> childNodeList_2 = new List<Transform>();
  
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        FillNodes();

        for (int i = 0; i < childNodeList_2.Count; i++)
        {
            Vector3 currentPos = childNodeList_2[i].position;
            if (i > 0)
            {
                Vector3 prevPos = childNodeList_2[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
        Gizmos.DrawLine(childNodeList_2[childNodeList_2.Count - 1].position, childNodeList_2[0].position);
    }
    void FillNodes()
    {
        childNodeList_2.Clear();
        childObjects_2 = GetComponentsInChildren<Transform>();
        foreach (Transform child in childObjects_2)
        {
            if (child != this.transform)
            {
                childNodeList_2.Add(child);
            }
        }
    }
}
