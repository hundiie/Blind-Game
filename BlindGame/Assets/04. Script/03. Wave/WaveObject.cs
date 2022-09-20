using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum WAVESTATE
{
    IDLE,
    MOVE
}

public class WaveObject : MonoBehaviour
{
    private WaveManager _WaveManager;

    public WAVESTATE ObjectState;

    [Header("WaveInfo")]
    public WAVETAG WaveTag;         // ���̺� �±�
    public Color32 WaveColor;       // ���̺� ����
    
    [Header("IdleWaveInfo")]
    public float Idle_WaveSize;     //Idle ���� ���̺� ������
    public float Idle_WaveSpeed;    //Idle ���� ���̺� ���ǵ�
    public float Idle_WaveInterval; //Idle ���� ���̺� ����

    [Header("MoveWaveInfo")]
    public float Move_WaveSize;     //Move ���� ���̺� ������
    public float Move_WaveSpeed;    //Move ���� ���̺� ���ǵ�
    public float Move_WaveInterval; //Move ���� ���̺� ����

    private void Awake()
    {
        _WaveManager = GameObject.FindWithTag("WaveManager").gameObject.GetComponent<WaveManager>();
    }
    private void Update()
    {
        switch (ObjectState)
        {
            case WAVESTATE.IDLE: Update_Idle();
                break;
            case WAVESTATE.MOVE: Update_Move();
                break;
            default:
                break;
        }
    }
    private float Idle_Delta;
    private void Update_Idle()
    {
        Idle_Delta += Time.deltaTime;
        if (Idle_Delta >= Idle_WaveInterval)
        {
            Idle_Delta = 0f;
            _WaveManager.SetWave(transform.position, Idle_WaveSize, Idle_WaveSpeed, WaveColor, WaveTag);
        }

    }
    private float Move_Delta;
    private void Update_Move()
    {
        Move_Delta += Time.deltaTime;
        if (Move_Delta >= Move_WaveInterval)
        {
            Move_Delta = 0f;
            _WaveManager.SetWave(transform.position, Move_WaveSize, Move_WaveSpeed, WaveColor, WaveTag);
        }
    }

    public void ChangeState(WAVESTATE State)
    {
        ObjectState = State;
        Idle_Delta = 0f;
        Move_Delta = Move_WaveInterval;
    }

    public void IdleWaveSet(float WaveSize, float WaveSpeed, float WaveInterval)
    {
        Idle_WaveSize = WaveSize;
        Idle_WaveSpeed = WaveSpeed;
        Idle_WaveInterval = WaveInterval;
    }
    public void MoveWaveSet(float WaveSize, float WaveSpeed, float WaveInterval)
    {
        Move_WaveSize = WaveSize;
        Move_WaveSpeed = WaveSpeed;
        Move_WaveInterval = WaveInterval;
    }
}
