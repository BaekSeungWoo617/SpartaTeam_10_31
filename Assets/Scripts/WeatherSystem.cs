using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeatherType
{
    Sunny,
    Rainy,
    Snowy
}

public class WeatherSystem : MonoBehaviour
{
    private Material sunnySkybox;
    private Material rainySkybox;
    private Material snowySkybox;

    public ParticleSystem rain;
    public ParticleSystem snow;

    private void Awake()
    {
        Camera _camera = Camera.main;

        rain = GameObject.Find("Rain").GetComponent<ParticleSystem>();
        snow = GameObject.Find("Snow").GetComponent<ParticleSystem>();

        rain.transform.SetParent(_camera.transform);
        snow.transform.SetParent(_camera.transform);
    }

    void Start()
    {
        ChangeWeather(WeatherType.Snowy);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeWeather(WeatherType.Sunny);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            ChangeWeather(WeatherType.Rainy);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeWeather(WeatherType.Snowy);
        }
    }

    public void ChangeWeather(WeatherType weather)
    {
        switch (weather)
        {
            case WeatherType.Sunny:
                SetSkybox(sunnySkybox);
                DynamicLighting(Color.white, 1f);
                rain.Stop();
                snow.Stop();
                break;

            case WeatherType.Rainy:
                SetSkybox(rainySkybox);
                DynamicLighting(new Color(0.5f, 0.5f, 0.5f), 0.5f);
                rain.Play();
                snow.Stop();
                break;

            case WeatherType.Snowy:
                SetSkybox(snowySkybox);
                DynamicLighting(new Color(0.75f, 0.75f, 1f), 0.75f);
                rain.Stop();
                snow.Play();
                break;
        }
    }

    private void SetSkybox(Material skybox)
    {
        if (skybox != null)
        {
            RenderSettings.skybox = skybox; // 스카이박스를 설정
            DynamicGI.UpdateEnvironment();  // GI 업데이트
        }
    }

    private void DynamicLighting(Color color, float intensity)
    {
        Light[] lights = FindObjectsOfType<Light>();
        foreach (var light in lights)
        {
            light.color = color;
            light.intensity = intensity;
        }
    }
}
