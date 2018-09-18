using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyFood", 20);
    }

    // Update is called once per frame
    void Update () {
	}
    void DestroyFood()
    {
        Destroy(this.gameObject);
    }
}
