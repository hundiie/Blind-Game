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
    public float Idle_WaveSize;//Idle 상태 웨이브 사이즈
    public float Idle_WaveSpeed;//Idle 상태 웨이브 스피드
    public float Idle_WaveInterval;//Idle 상태 웨이브 간격

    public float Move_WaveSize;//Move 상태 웨이브 사이즈
    public float Move_WaveSpeed;//Move 상태 웨이브 스피드
    public float Move_WaveInterval;//Move 상태 웨이브 간격

    public WAVETAG WaveTag; //웨이브 태그
    public int SoundImageNumber;// 웨이브 이미지넘버
    public int WaveSoundNumber;// 웨이브 소리넘버

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

        }

    }
    private float Move_Delta;
    private void Update_Move()
    {
        Move_Delta += Time.deltaTime;
        if (Move_Delta >= Move_WaveInterval)
        {
            Move_Delta = 0f;

        }
    }

    public void ChangeState(WAVESTATE State)
    {
        ObjectState = State;
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
