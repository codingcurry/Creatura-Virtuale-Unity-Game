using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Awake()
    {
        GameObject[] sound = GameObject.FindGameObjectsWithTag("music");
        if (sound.Length > 1)
        {
            if (sound[0] == sound[1])
            {
                Destroy(sound[1]);

            }
            else
            {
                Destroy(sound[0]);
                sound[0] = sound[1];
            }
        }
        DontDestroyOnLoad(sound[0]);
    }

}
