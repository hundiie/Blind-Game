using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMaov : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    private float mouseX;
    private float mouseY;

    [SerializeField] private float MouseSpeed;

    private void Update()
    {
        CrameraMove();
    }

    private void CrameraMove()
    {
        mouseX += Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime;
        mouseY += Input.GetAxis("Mouse Y") * MouseSpeed * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -65f, 55f);//?þ߰?
        transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
