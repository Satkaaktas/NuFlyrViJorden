using UnityEngine;

public class VfxManager : MonoBehaviour
{

    [SerializeField]
    Transform vfxTargetLeft, vfxTargetRight;

    [SerializeField]
    GameObject vfx;

    public void PlayVfxOnStep(int foot)
    {
        if (foot == 0)
            Instantiate(vfx, vfxTargetLeft.position, Quaternion.identity);
        else
            Instantiate(vfx, vfxTargetRight.position, Quaternion.identity);
    }
}
