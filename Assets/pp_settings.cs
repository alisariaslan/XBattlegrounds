using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class pp_settings : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public Toggle t1, t2, t3, t4, t5;

    private AmbientOcclusion ambientOcclusion;
    private Bloom bloom;
    private DepthOfField depthOfField;
    private MotionBlur motionBlur;
    private LensDistortion lensDistortion;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings<AmbientOcclusion>(out ambientOcclusion);
        postProcessVolume.profile.TryGetSettings<Bloom>(out bloom);
        postProcessVolume.profile.TryGetSettings<DepthOfField>(out depthOfField);
        postProcessVolume.profile.TryGetSettings<MotionBlur>(out motionBlur);
        postProcessVolume.profile.TryGetSettings<LensDistortion>(out lensDistortion);

        t1.isOn = PlayerPrefs.GetInt("Bloom", 1) == 1 ? true : false;
        t2.isOn = PlayerPrefs.GetInt("AmbientOcclusion", 1) == 1 ? true : false;
        t3.isOn = PlayerPrefs.GetInt("DepthOfField", 1) == 1 ? true : false;
        t4.isOn = PlayerPrefs.GetInt("MotionBlur", 1) == 1 ? true : false;
        t5.isOn = PlayerPrefs.GetInt("LensDistortion", 1) == 1 ? true : false;

    }

    public void Bloom()
    {
        bloom.active = t1.isOn;
        PlayerPrefs.SetInt("Bloom", t1.isOn ? 1 : 0);
    }

    public void SetAmbientOcclusion()
    {
        ambientOcclusion.active = t2.isOn;
        PlayerPrefs.SetInt("AmbientOcclusion", t2.isOn ? 1 : 0);
    }

    public void SetDepthOfField()
    {
        depthOfField.active = t3.isOn;
        PlayerPrefs.SetInt("DepthOfField", t3.isOn ? 1 : 0);
    }

    public void SetMotionBlur()
    {
        motionBlur.active = t4.isOn;
        PlayerPrefs.SetInt("MotionBlur", t4.isOn ? 1 : 0);
    }

    public void SetLensDistortion()
    {
        lensDistortion.active = t5.isOn;
        PlayerPrefs.SetInt("LensDistortion", t5.isOn ? 1 : 0);
    }

}
