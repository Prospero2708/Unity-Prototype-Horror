using UnityEngine;
using UnityEngine.Rendering;

public class GrainEffect : MonoBehaviour
{
    private float dist;
    [SerializeField] private CalculateDistance ReadDistanñe;
    [SerializeField] private TimeTicker timeTicker;

    [SerializeField] private Volume MainVolume;

    [SerializeField] private VolumeProfile GrainLow1;
    [SerializeField] private VolumeProfile GrainLow2;
    [SerializeField] private VolumeProfile Medium1;
    [SerializeField] private VolumeProfile Medium2;

    [SerializeField] private float LongestDistance;
    [SerializeField] private float LongDistance;
    [SerializeField] private float ShortDistance;

    private VolumeProfile currentProfile;

    private void Awake()
    {
        ReadDistanñe = GetComponent<CalculateDistance>();
    }
    private void OnEnable()
    {
        if (timeTicker != null)
        {
            timeTicker.OnTick += UpdateEffect;
        }
    }
    private void OnDisable()
    {
        if (timeTicker != null)
        {
            timeTicker.OnTick -= UpdateEffect;
        }
    }

    private void UpdateEffect()
    {
        dist = ReadDistanñe.distance;

        if (dist > LongestDistance)
        {
            if (currentProfile != GrainLow1) 
            {
                MainVolume.profile = GrainLow1;
                currentProfile = GrainLow1;
            }
        }
        else if (dist >= LongDistance)
        {
            if (currentProfile != GrainLow2)
            {
                MainVolume.profile = GrainLow2;
                currentProfile = GrainLow2;
            }
        }
        else if (dist >= ShortDistance)
        {
            if (currentProfile != Medium1)
            {
                MainVolume.profile = Medium1;
                currentProfile = Medium1;
            }
        }
        else if (dist < ShortDistance)
        {
            if (currentProfile != Medium2)
            {
                MainVolume.profile = Medium2;
                currentProfile = Medium2;
            }
        }
    }
}
