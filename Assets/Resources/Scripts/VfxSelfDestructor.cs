using UnityEngine;
                                            /*By Erik Qvarnström, Björn Andersson && Timmy Alvelöv*/
public class VfxSelfDestructor : MonoBehaviour
{
    [SerializeField]
    float delay;

    void Start()
    {
        Destroy(this.gameObject, GetComponent<ParticleSystem>().main.duration + delay);             //Förstör fotstegspartiklar efter en viss tid
    }
}