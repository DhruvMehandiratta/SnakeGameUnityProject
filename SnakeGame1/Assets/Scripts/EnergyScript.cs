using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyEnergy", 10);
	}
	// Update is called once per frame
	void Update () {
	}
    void DestroyEnergy()
    {
        Destroy(this.gameObject);
    }
}
