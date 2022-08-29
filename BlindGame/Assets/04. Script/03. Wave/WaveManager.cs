using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WAVETAG
{
    NOMALSOUND,
    MONSTERSOUND,
    NATURESOUND
}

public class WaveManager : MonoBehaviour
{
    private GameObject[] Wave = new GameObject[30];

    private void Awake()
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            Wave[i] = transform.GetChild(i).gameObject;
            Wave[i].SetActive(false);
        }
    }
    public void SetWave(Vector3 SoundPosition, float WaveSize, float WaveSpeed, Color Wavecolor, WAVETAG Wavetag)
    {
        for (int i = 0; i < Wave.Length; i++)
        {
            if (Wave[i].activeSelf == false)
            {
                Wave _wave = Wave[i].GetComponent<Wave>();
                Wave[i].transform.position = SoundPosition;

                string TagName = "Untagged";
                switch (Wavetag)
                {
                    case WAVETAG.NOMALSOUND:
                        TagName = "NomalSound";
                        break;
                    case WAVETAG.MONSTERSOUND:
                        TagName = "MonsterSound";
                        break;
                    case WAVETAG.NATURESOUND:
                        TagName = "NatureSound";
                        break;
                    default:
                        break;
                }
                Wave[i].tag = TagName;

                _wave.StartWave(WaveSize, WaveSpeed, Wavecolor);

                return;
            }
        }
    }
}
