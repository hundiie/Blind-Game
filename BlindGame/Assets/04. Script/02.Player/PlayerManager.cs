using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerInput _PlayerInput;
    //private SoundManager _SoundManager;
    private WaveManager _WaveManager;
    //private UIManager _UIManager;

    [Header("GameObject")]
    public GameObject Camera;
    public GameObject SoundManager;
    public GameObject WaveManager;
    public GameObject UiManager;

    [Header("Move")]
    public float moveSpeed;

    private void Awake()
    {
        _PlayerInput = GetComponent<PlayerInput>();
        //_SoundManager = SoundManager.GetComponent<SoundManager>();
        _WaveManager = WaveManager.GetComponent<WaveManager>();
        //_UIManager = UiManager.GetComponent<UIManager>();
    }

    void Update()
    {
        Debug.Log(GetTile());
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 pos = transform.position - new Vector3(0, 2, 0);
            _WaveManager.SetWave(pos, 100,100,Color.red,WAVETAG.NOMALSOUND);
        }

    }

    public int GetTile()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            switch (hit.collider.gameObject.tag)
            {
                case "NomalTile":
                    return 1;
                case "WaterTile":
                    return 2;
                case "SoilTile":
                    return 3;
                default:
                    break;
            }
        }
        return 0;
    }

}
