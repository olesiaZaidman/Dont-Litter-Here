using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunbed : MonoBehaviour
{
    [SerializeField] GameObject umbrella_open;
    [SerializeField] GameObject umbrella_closed;
    [SerializeField] bool isUmbrellaOpen = true;

    public bool isInteractable = true;

    void Start()
    {
        umbrella_open.SetActive(!isUmbrellaOpen);
        umbrella_closed.SetActive(isUmbrellaOpen);
    }

    void Update()
    {
    //    ChangeUnbrella(isActive);

        if (Input.GetKey(KeyCode.Space))
        {
            //if (isActive)
            //{ 
            //    isActive = false;
            //}
            //else if (!isActive)
            //{ 
            //    isActive = true;
            //}
               
            ChangeUnbrellaState();
            
        }
    }

    public void ChangeUnbrellaState()
    {
        isUmbrellaOpen = !isUmbrellaOpen;
        SetUnbrellaState(isUmbrellaOpen);
    }

     void SetUnbrellaState(bool _isActive)
    {
        umbrella_open.SetActive(!_isActive);
        umbrella_closed.SetActive(_isActive);
    }

    public IEnumerator MakeSunbedAvailableRoutine()
    {
        yield return new WaitForSeconds(2f);
        isInteractable = false;
    }
}
