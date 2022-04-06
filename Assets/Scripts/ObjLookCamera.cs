using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookCamera : MonoBehaviour
{
    public bool needToLoook;
    public Transform targetLook;
    public myEnum Target = new myEnum();

    void Start() {
        if(Target == myEnum.Camera){
            targetLook = Camera.main.transform;
        }
    }

    void Update()
    {
        LookAtTarget(needToLoook, targetLook);
    }

    public void LookAtTarget(bool needLook, Transform target){
        if (needLook){
            this.transform.LookAt(target);
        }
    }
}

public enum myEnum{ // your custom enumeration
    None,
    Camera,
    Player,
    Finish,
    Other
};
