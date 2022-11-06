using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    public float timespeed = 1f;
    [SerializeField] private Light dlight;
    [SerializeField] private LightPreset preset;
    [SerializeField, Range(0, 24)] private float time;


    // Start is called before the first frame update
    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying)
        {
            time += Time.deltaTime * timespeed;
            time %= 24; //clamp between 0-24
            UpdateLight(time / 24f);
        }
        else
        {
            UpdateLight(time / 24f);
        }
    }


    // Update is called once per frame
    private void UpdateLight(float timepercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timepercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timepercent);
        if (dlight != null)
        {
            dlight.color = preset.directionalColor.Evaluate(timepercent);
            dlight.transform.localRotation = Quaternion.Euler(new Vector3((timepercent * 360f) - 90f, 170f, 0));
        }
    }

    private void OnValidate()
    {
        if (dlight != null)
        {
            return;
        }

        if (RenderSettings.sun != null)
        {
            dlight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            {
                foreach (Light light in lights)
                {
                    if (light.type == LightType.Directional)
                    {
                        dlight = light;
                        return;
                    }
                }
            }


        }
    }
}
