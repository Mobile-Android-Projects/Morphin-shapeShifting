using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobShape : MonoBehaviour
{
    [SerializeField] float valToSet = 0;
    [SerializeField] float morphSpeed;
    [SerializeField] float morphStateTime;
    [SerializeField] float timeInMorphedState;
    SkinnedMeshRenderer skinnedMeshRenderer;
    SwipeInputHandler swipeInputHandler;
  
    public bool isShapeActivated = false;//ToDo:public for testing
    Shapes activeShape;
    private void Awake()
    {
        swipeInputHandler = FindAnyObjectByType<SwipeInputHandler>();
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void OnEnable()
    {
        swipeInputHandler.OnShapeMorph += HandleShapeMorph;
    }

    private void Start()
    {
        timeInMorphedState = morphStateTime;
    }
    public void HandleShapeMorph(Shapes shape)
    {
        isShapeActivated = true;
        activeShape = shape;
        //valToSet = 0;
        ////switch (shape)
        ////{
        ////    case Shapes.Cube:

        ////        skinnedMeshRenderer.SetBlendShapeWeight(0, valToSet);
        ////        skinnedMeshRenderer.SetBlendShapeWeight(1, 0);
        ////        break;
        ////    case Shapes.Cylinder:

        ////        skinnedMeshRenderer.SetBlendShapeWeight(1, valToSet);
        ////        skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
        ////        break;
        ////}
        //StartCoroutine(ShapeShift(shape));
    }

    private void Update()
    {
        if (isShapeActivated == true)
        {
            
            valToSet += morphSpeed;
            if(valToSet >= 100f)
            {
                valToSet = 100f;
               
            }
            switch (activeShape)
            {
                case Shapes.Cube:
                    skinnedMeshRenderer.SetBlendShapeWeight(0, valToSet);
                    skinnedMeshRenderer.SetBlendShapeWeight(1, 0);
                  
                    timeInMorphedState -= Time.deltaTime;

                    if (timeInMorphedState < 0)
                    {
                        
                        isShapeActivated = false;
                        
                    }
                    break;
                case Shapes.Cylinder:
                    skinnedMeshRenderer.SetBlendShapeWeight(1,valToSet);
                    skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
                    
                    timeInMorphedState -= Time.deltaTime;

                    if (timeInMorphedState < 0)
                    {
                      
                        isShapeActivated = false;
                    }
                    break;

            }


        }
        if (isShapeActivated == false)
        {
            valToSet -= morphSpeed;
            if (valToSet < 0)
            {
                valToSet = 0;
            }
            skinnedMeshRenderer.SetBlendShapeWeight(0, valToSet);
            skinnedMeshRenderer.SetBlendShapeWeight(1, valToSet);
            timeInMorphedState = morphStateTime;
        }

    }
    //private IEnumerator ShapeShift(Shapes shape)
    //{
    //    valToSet = 0;
    //    switch (shape)
    //    {
    //        case Shapes.Cube:
    //            yield return new WaitForSeconds(0.01f);
    //            skinnedMeshRenderer.SetBlendShapeWeight(0, valToSet);
    //            skinnedMeshRenderer.SetBlendShapeWeight(1, 0);
    //            break;
    //        case Shapes.Cylinder:

    //            skinnedMeshRenderer.SetBlendShapeWeight(1, valToSet);
    //            skinnedMeshRenderer.SetBlendShapeWeight(0, 0);
    //            break;
    //    }

    //}
}
