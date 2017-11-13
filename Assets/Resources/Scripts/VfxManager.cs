using UnityEngine;

public class VfxManager : MonoBehaviour
{
                                                                        /*By Erik Qvarnström*/
    [SerializeField]
    Transform vfxTargetLeft, vfxTargetRight;

    [SerializeField]
    GameObject vfx;

    public void PlayVfxOnStep(int foot)                                 //Skapar partikeleffekter för att simulera fotsteg vid förutbestämda positioner
    {
        if (foot == 0)
            Instantiate(vfx, vfxTargetLeft.position, Quaternion.identity);
        else
            Instantiate(vfx, vfxTargetRight.position, Quaternion.identity);
    }
}
