using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveRenderer : MonoBehaviour
{
    Texture2D texture;
    Color[] sin_wave_color;
    public TaskController taskController;
    Sprite sprite;
    
    void Start()
    {
        texture = new Texture2D(1920, 1080, TextureFormat.RGBA32, false);
        sin_wave_color = new Color[1920*1080];

        Material mat = new Material(Shader.Find("Unlit/Texture"));
        for(int y = 0; y < texture.height; y++)
        {
            for(int x = 0; x < texture.width; x++)
            {
                Color color = new Color(0,0,0);
                if(Mathf.Abs((y-1080/2)-100*Mathf.Sin(x*Mathf.Deg2Rad)) <= 10f/2f || Mathf.Abs(x - (1/Mathf.Deg2Rad)*(Mathf.Asin((y-1080/2)/100))) <= 15f/2f)
                {
                    color = new Color(255,0,0);
                    //color = new Color(255,255,255);
                    for(int x1 = 0; x1<texture.width; x1++)
                    {
                        if(Vector2.Distance(new Vector2(x,y), new Vector2(x1, 1080/2 + 100*Mathf.Sin(x1*Mathf.Deg2Rad))) <= 5f/2f)
                        {
                            color = new Color(0,0,0);
                            break;
                        }
                    }
                }

                texture.SetPixel(x,y,color);
            }
        }
        texture.Apply();
        mat.mainTexture = texture;

        this.GetComponent<MeshRenderer>().material = mat;
    }

    
    void Update()
    {
        
    }
}
