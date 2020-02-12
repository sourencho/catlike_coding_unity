using UnityEngine;
using System;



public class Clock : MonoBehaviour
{
    const float DEGREES_PER_HOUR = 30f;
    const float DEGREES_PER_MIN = 6f;
    const float DEGREES_PER_SEC = 6f;
    public bool continuous;
    public Transform hoursTransform, minutesTransform, secondsTransform;

    void Update()
    {
        if (continuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    void UpdateDiscrete()
    {
        DateTime time = DateTime.Now;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, time.Hour * DEGREES_PER_HOUR, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, time.Minute * DEGREES_PER_MIN, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, time.Second * DEGREES_PER_SEC, 0f);
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalHours * DEGREES_PER_HOUR, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalMinutes * DEGREES_PER_MIN, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(0f, (float)time.TotalSeconds * DEGREES_PER_SEC, 0f);
    }
}