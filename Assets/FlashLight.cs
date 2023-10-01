using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light2D flashLight;
    [SerializeField] private float maxIntensity = 1f;
    [SerializeField] private float maxOuter = 5f;
    [SerializeField] private float initialBatteryLevel = 100f;
    [SerializeField] private float batteryDrainRate = 0.1f;
    [SerializeField] private float currentBatteryLevel;
    public CanvasScript canvas;

    private void Start()
    {
        currentBatteryLevel = initialBatteryLevel;
        UpdateFlashLight();
        canvas.UpdateFlashLightBattery(currentBatteryLevel,initialBatteryLevel);
    }

    private void Update()
    {
        if (currentBatteryLevel > 0 || flashLight.intensity > 0.25f)
        {
            currentBatteryLevel -= batteryDrainRate * Time.deltaTime;
            currentBatteryLevel = Mathf.Max(currentBatteryLevel, 0f);

            UpdateFlashLight();
        }
        currentBatteryLevel = Mathf.Clamp(currentBatteryLevel, 0f, initialBatteryLevel);
    }

    private void UpdateFlashLight()
    {
        float intensity = currentBatteryLevel / initialBatteryLevel * maxIntensity;
        float outerRadius = currentBatteryLevel / initialBatteryLevel * maxOuter;

        // Aplica los límites mínimos
        intensity = Mathf.Max(intensity, 0.25f);
        outerRadius = Mathf.Max(outerRadius, 3f);

        flashLight.intensity = intensity;
        flashLight.pointLightOuterRadius = outerRadius;
        canvas.UpdateFlashLightBattery(currentBatteryLevel, initialBatteryLevel);
    }

    public void RechargeBattery(float amount)
    {
        currentBatteryLevel += amount;
        currentBatteryLevel = Mathf.Clamp(currentBatteryLevel, 0f, initialBatteryLevel);
        UpdateFlashLight();
        canvas.UpdateFlashLightBattery(currentBatteryLevel, initialBatteryLevel);
    }
}
