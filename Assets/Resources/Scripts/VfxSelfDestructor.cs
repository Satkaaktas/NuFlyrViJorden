using UnityEngine;

public class VfxSelfDestructor : MonoBehaviour {

    public float time = 0.25f;
    void Start()
    {
        Destroy(this.gameObject, time);
    }

    
}
