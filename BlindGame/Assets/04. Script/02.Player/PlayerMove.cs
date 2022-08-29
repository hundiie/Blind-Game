using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerManager _PlayerManager;
    private PlayerInput _PlayerInput;

    private GameObject Camera;

    private float moveSpeed;
    private void Awake()
    {
        _PlayerManager = GetComponent<PlayerManager>();
        _PlayerInput = GetComponent<PlayerInput>();

        Camera = _PlayerManager.Camera;
        moveSpeed = _PlayerManager.moveSpeed;
    }
    private void FixedUpdate()
    {
        if (_PlayerInput.X != 0 || _PlayerInput.Z != 0)
        {
            playerMove(_PlayerInput.X, _PlayerInput.Z);
        }
    }
    private void CameraView()
    {
        transform.forward = new Vector3(Camera.transform.forward.x, 0f, Camera.transform.forward.z).normalized;
    }
    private void playerMove(float X, float Z)
    {
        CameraView();
        transform.Translate(X * moveSpeed * Time.deltaTime, 0, Z * moveSpeed * Time.deltaTime);
    }


}
