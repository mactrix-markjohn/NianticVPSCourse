using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivatePlantTimeline : MonoBehaviour
{

    public PlayableDirector playableDirector;
    public GameObject Flowers;

    private void Awake()
    {
        
        Flowers.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GardinifyActivateTimeline()
    {
        Flowers.SetActive(true);
        playableDirector.Play();
        if (playableDirector.playableGraph.IsValid())
        {
            playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1f);
        }
        
    }
}
