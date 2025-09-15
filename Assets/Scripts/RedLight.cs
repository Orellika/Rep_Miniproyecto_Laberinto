using System.Collections;
using UnityEngine;

public class RedLight : MonoBehaviour
{
    [SerializeField] Light redLight;
    [SerializeField] float timeToTurnOn = 3;
    [SerializeField] float currentTime = 0;
    [SerializeField] float customIntensity = 3660;
    [SerializeField] float currentIntensity;
    [SerializeField] Coroutine activeCoroutine;
    [SerializeField] int triggerCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redLight = GetComponent<Light>();
        redLight.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        if (other.tag == "Player")
        {
            triggerCount++;
            if(triggerCount == 1)
            {
                currentIntensity = redLight.intensity;
                if (activeCoroutine != null) StopCoroutine(activeCoroutine);
                activeCoroutine = StartCoroutine(TurnOnAndOff(currentIntensity, customIntensity, true));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit");
        if (other.tag == "Player")
        {
            triggerCount--;
            if(triggerCount == 0)
            {
                currentIntensity = redLight.intensity;
                if (activeCoroutine != null) StopCoroutine(activeCoroutine);
                activeCoroutine = StartCoroutine(TurnOnAndOff(currentIntensity, 0, false));
            }
        }
    }
    IEnumerator TurnOnAndOff(float A, float B, bool toggle)
    {
        if (toggle) redLight.enabled = true;
        
        currentTime = 0;
        while (currentTime < timeToTurnOn)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / timeToTurnOn;
            redLight.intensity = Mathf.Lerp(A, B, t);

            yield return null;
        }

        if (!toggle) redLight.enabled = false;
    }
}
