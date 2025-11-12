using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    [SerializeField] List<LineRenderer> line = new List<LineRenderer>();

    public void SetPosition(Transform startPos, Transform endPos)
    {
        if(lineRenderers.Count > 0)
        {
            for (int i = 0; i < lineRenderers.Count; i++)
            {
                if (LineRenderers[i].positionCount >= 2)
                {
                    LineRenderers[i].SetPosition(0, startPos.position);
                    LineRenderers[i].SetPosition(0, endPos.position);
                }
            }
        }
    }
}
