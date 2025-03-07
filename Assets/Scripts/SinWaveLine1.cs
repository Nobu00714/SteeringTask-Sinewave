using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveLine1 : MonoBehaviour
{
    public int resolution = 1920; // Resolution of the line
    public float amplitude = 1f;  // 振幅
    public float frequency = 1f;  // 周波数
    public LineRenderer TaskLineRenderer;
    public List<Vector2> sinWavePointList = new List<Vector2>();
    private float prevX = -1920/2;
    private float prevY = 0;
    public float width = 100;
    public float color;
    public int layer;
    private void Start()
    {

    }

    private void Update()
    {

    }

    public void DrawSineWave(int TaskAmplitude, int TaskWidth)
    {

        // サイン波の分割数を指定
        int taskAreaResolution = 1920;
        int startAreaResolution = (int)(1920/frequency/4 * 3);
        int endAreaResolution = (int)(1920/frequency/4) * ((int)frequency*4 - 3 - (int)(TaskAmplitude*4));
        TaskLineRenderer.positionCount = taskAreaResolution;

        // サイン波の周期を指定
        float taskAreaFrequency = frequency;
        float startAreaFrequency = 3f/4f;
        float endAreaFrequency = frequency - 3f/4f - TaskAmplitude;

        float SinWaveLength = 0;
        
        
        for (int i = 0; i < taskAreaResolution; i++)
        {
            float x = (float)i / taskAreaResolution;
            float y = amplitude * Mathf.Sin(taskAreaFrequency * x * 2 * Mathf.PI);

            // タスクのサイン波の制御点を指定
            TaskLineRenderer.SetPosition(i, new Vector3(x * 1920 - 1920/2, y, layer));

            sinWavePointList.Add(new Vector2(x * 1920 - 1920/2,y));

            SinWaveLength += Vector2.Distance(new Vector2(x * 1920f - 1920f/2f,y), new Vector2(prevX,prevY));

            // 幅を決定
            TaskLineRenderer.startWidth = width;
            TaskLineRenderer.endWidth = width;

            // 色を白に
            TaskLineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            // TaskLineRenderer.startColor = UnityEngine.Color.white;
            // TaskLineRenderer.endColor = UnityEngine.Color.white;
            TaskLineRenderer.material.SetColor("_Color", new UnityEngine.Color(color,color,color));

            prevX = x * 1920 - 1920/2;
            prevY = y;
        }

        //Debug.Log((SinWaveLength/frequency));

    }
}
