using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeInputHandler : MonoBehaviour
{
    //swip directions -> left, right

    public event Action<Shapes> OnShapeMorph;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.deltaPosition.x < 0)
            {
                MorphShape(Shapes.Cube);
            }
            if (touch.deltaPosition.y > 0)
            {
                MorphShape(Shapes.Cylinder);
            }
        }
    }

    private void MorphShape(Shapes cube)
    {
        switch (cube)
        {
            case Shapes.Cube:
                OnShapeMorph?.Invoke(Shapes.Cube);
                break;
            case Shapes.Cylinder:
                OnShapeMorph?.Invoke(Shapes.Cylinder);
                break;
        }
    }
}

public enum Shapes
{
    Cube, Cylinder
}
