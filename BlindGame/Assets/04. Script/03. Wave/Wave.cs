using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    Material Mat;

    private void Awake()
    {
        Mat = GetComponent<Renderer>().material;
    }
    public void StartWave(float WaveSize, float WaveSpeed, Color Wavecolor)
    {
        gameObject.SetActive(true);
        Mat.SetColor("_HighlightColor", Wavecolor);
        Mat.color = Wavecolor;
        StartCoroutine(BlowUp(WaveSize, WaveSpeed));
        StartCoroutine(Pade(WaveSize, WaveSpeed));
        
    }
    private IEnumerator BlowUp(float WaveSize, float WaveSpeed)
    {
        for (float Blow = 0; Blow < WaveSize; Blow += WaveSpeed * Time.deltaTime)
        {
            transform.localScale = new Vector3(1, 1, 1) * Blow;
            yield return null;
        }
    }

    private IEnumerator Pade(float WaveSize, float WaveSpeed)
    {
        Color HighlightColor = Mat.GetColor("_HighlightColor");
        Color color = Mat.color;

        for (float pade = 1; pade >= 0; pade -= WaveSpeed / WaveSize * Time.deltaTime)
        {
            HighlightColor.a = pade;
            Mat.SetColor("_HighlightColor", HighlightColor);

            color.a = pade;
            Mat.color = color;

            yield return null;
        }
        gameObject.SetActive(false);
    }
}
