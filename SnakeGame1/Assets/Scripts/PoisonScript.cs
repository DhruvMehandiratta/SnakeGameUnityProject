using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyPoison", 20);
    }
    // Update is called once per frame
    void Update () {
	}
    void DestroyPoison()
    {
        Destroy(this.gameObject);
    }
}
