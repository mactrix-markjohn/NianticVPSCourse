using System.Collections;
using System.Collections.Generic;
using Niantic.ARDK.AR.WayspotAnchors;
using Niantic.ARDKExamples.RemoteAuthoring;
using TMPro;
using UnityEngine;

public class AutoLoadLocationScript : MonoBehaviour
{
    
    public LocationManifestManager _locationManifestManager;
    public TextMeshProUGUI statusLog;
    public TextMeshProUGUI localizationStatus;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadWayspots());
        
        
        //subscribe to status tracking to present to user
        _locationManifestManager.StatusLogChangeEvent += StatusLogChanged;
        _locationManifestManager.AddLocalizationStatusListener(LocationStatusChanged);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator LoadWayspots()
    {
        yield return new WaitForSeconds(5f);
        //_locationManifestManager = LocationManifestManager.Instance;
        _locationManifestManager.LoadWayspotAnchors(0);
    }
    
    
    private void StatusLogChanged(string message)
    {
        statusLog.text = message;
    }

    private void LocationStatusChanged(LocalizationStateUpdatedArgs args)
    {
        string text = "Localization Status: ";
        if (args != null)
        {
            text += $"{args.State} " +
                    (args.State == LocalizationState.Failed ? $"(Reason: {args.FailureReason})" : "");
        }
        localizationStatus.text = text;
    }
}
