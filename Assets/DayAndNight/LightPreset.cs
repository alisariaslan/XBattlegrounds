using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Day and Night/Lighting Preset", order = 1)]
public class LightPreset : MonoBehaviour
{
    public Gradient ambientColor;
    public Gradient directionalColor;
    public Gradient fogColor;
    public AnimationCurve fogDensity;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
