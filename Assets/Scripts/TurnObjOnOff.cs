using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjOnOff : MonoBehaviour
{
    public GameObject objTarget;
    public bool isOn;

    public void TurnObjectActive(){
        objTarget.SetActive(isOn);
    }
}
