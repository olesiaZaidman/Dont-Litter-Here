using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunbed : MonoBehaviour
{
    [SerializeField] GameObject umbrella_open;
    [SerializeField] GameObject umbrella_closed;
    [SerializeField] bool isUmbrellaClosed;

    public bool isInteractable = true;
   // [SerializeField] GameObject lastVisitor;
    void Start()
    {
        isUmbrellaClosed = true;
        umbrella_open.SetActive(!isUmbrellaClosed);
        umbrella_closed.SetActive(isUmbrellaClosed);
    }

    public void ChangeUnbrellaState()
    {
        isUmbrellaClosed = !isUmbrellaClosed;
        SetUnbrellaState(isUmbrellaClosed);
    }

    void SetUnbrellaState(bool _isActive)
    {
        umbrella_open.SetActive(!_isActive);
        umbrella_closed.SetActive(_isActive);
    }

    public IEnumerator MakeSunbedAvailableRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        isInteractable = true;
    }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Adult"))
    //    {
    //        lastVisitor = other.gameObject;
    //    }
    //}

    //bool GetIsFree()
    //{
    //    MoveForwardWithSunBathing visitorStatus = lastVisitor.GetComponent<MoveForwardWithSunBathing>();
    //    return visitorStatus.GetIsSunBathing();
    //}
}
