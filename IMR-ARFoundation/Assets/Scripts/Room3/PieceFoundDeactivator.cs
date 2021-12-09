using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFoundDeactivator : MonoBehaviour
{
    public void Interact(){


        transform.gameObject.SetActive(false);
    }
}
