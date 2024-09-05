using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
  [SerializeField] Material mat1;
  [SerializeField] Material mat2;

  public bool isMat1 = true;

  public void ChangeMaterial()
  {
    if(isMat1)
    {
      this.GetComponent<Renderer>().material = mat2;
      isMat1 = false;
    }
    else
    {
      this.GetComponent<Renderer>().material = mat1;
      isMat1 = true;
    }
  }
}
