using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Lever : MonoBehaviour
{
    [SerializeField]
    GameObject Movingblock;
    bool isMoved = false;
    public float X;
    public float Y;
    public float Z;
    private Vector3 Translator;
    private void Start()
    {
        Vector3 Translator = new Vector3(X, Y, Z);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isMoved == false)
            {
                Movingblock.transform.Translate(Translator * Time.deltaTime, Space.Self);
                isMoved = true;
            }
            if (isMoved == true)
            {
                Movingblock.transform.Translate(-Translator * Time.deltaTime, Space.Self);
                 isMoved = false;
            }
        }   
    }
}