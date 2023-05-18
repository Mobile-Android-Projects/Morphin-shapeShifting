using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInputHandler : MonoBehaviour
{
    public void HandleCubeButtonClicked()
    {
        FindAnyObjectByType<BlobShape>().HandleShapeMorph(Shapes.Cube);
    }
    public void HandleCylinderButtonClicked()
    {
        FindAnyObjectByType<BlobShape>().HandleShapeMorph(Shapes.Cylinder);

    }
}
