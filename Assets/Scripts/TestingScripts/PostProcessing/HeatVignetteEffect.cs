using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HeatVignetteEffect : MonoBehaviour
{
    //0.662
    // intensity
  [SerializeField] PostProcessVolume m_Volume;
   Vignette m_Vignette;

 //   float minIntenisty = 0;
  //  float maxIntenisty = 0.662f;
    void Awake()
    {
        
        
      //  m_Vignette = GetComponent<Vignette>();
      //  m_Vignette = ScriptableObject.CreateInstance<Vignette>();
      //  m_Vignette.intensity.Override(1f);
    //    m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);

    }

    private void Start()
    {
      //  m_Vignette.intensity = minIntenisty;
    }

   
    void Update()
    {
      //  m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
    }
    void OnDestroy()
    {
       // RuntimeUtilities.DestroyVolume(m_Volume, true, true);
    }
}
