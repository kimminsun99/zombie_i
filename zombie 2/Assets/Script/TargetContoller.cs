using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetContoller : MonoBehaviour
{

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "PicKaxe")
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
