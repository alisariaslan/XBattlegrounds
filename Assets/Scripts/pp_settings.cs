using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class pp_settings : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public Toggle tg_blom, tg_ambocc, tg_doff, tg_mtb, tg_lnsd;

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

        tg_blom.isOn = PlayerPrefs.GetInt("Bloom", 1) == 1 ? true : false;
        tg_ambocc.isOn = PlayerPrefs.GetInt("AmbientOcclusion", 1) == 1 ? true : false;
        tg_doff.isOn = PlayerPrefs.GetInt("DepthOfField", 1) == 1 ? true : false;
        tg_mtb.isOn = PlayerPrefs.GetInt("MotionBlur", 1) == 1 ? true : false;
        tg_lnsd.isOn = PlayerPrefs.GetInt("LensDistortion", 1) == 1 ? true : false;

    }

    public void Bloom()
    {
        bloom.active = tg_blom.isOn;
        PlayerPrefs.SetInt("Bloom", tg_blom.isOn ? 1 : 0);
    }

    public void SetAmbientOcclusion()
    {
        ambientOcclusion.active = tg_ambocc.isOn;
        PlayerPrefs.SetInt("AmbientOcclusion", tg_ambocc.isOn ? 1 : 0);
    }

    public void SetDepthOfField()
    {
        depthOfField.active = tg_doff.isOn;
        PlayerPrefs.SetInt("DepthOfField", tg_doff.isOn ? 1 : 0);
    }

    public void SetMotionBlur()
    {
        motionBlur.active = tg_mtb.isOn;
        PlayerPrefs.SetInt("MotionBlur", tg_mtb.isOn ? 1 : 0);
    }

    public void SetLensDistortion()
    {
        lensDistortion.active = tg_lnsd.isOn;
        PlayerPrefs.SetInt("LensDistortion", tg_lnsd.isOn ? 1 : 0);
    }

}
