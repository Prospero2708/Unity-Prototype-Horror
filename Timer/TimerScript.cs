using System;
using UnityEngine;

public class TimeTicker : MonoBehaviour
{
    public event Action OnTick;
    [SerializeField] private float tickInterval;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= tickInterval)
        {
            OnTick?.Invoke();
            timer %= tickInterval;
        }
    }
}
