using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallInvisibilityScript : MonoBehaviour
{

    public Transform _camera;
    List<Material> mats;
    bool flag;

    void Start()
    {
        mats = new List<Material>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, _camera.position - transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        List<Material> dontChangeBack = new List<Material>();

        for (int i = 0; i < hits.Length; i++)
        {
            flag = false;
            RaycastHit hit = hits[i];
            if (hit.transform.gameObject.tag == "Wall")
            {
                GameObject wall = hit.transform.gameObject;
                Material mat = wall.GetComponent<Renderer>().material;
                for (int j = 0; j < mats.Count; j++)
                {
                    if (mats[j] == mat)
                    {
                        dontChangeBack.Add(mat);
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Color invisColor = wall.GetComponent<Renderer>().material.color;
                    invisColor.a = 0.2f;
                    mats.Add(wall.GetComponent<Renderer>().material);
                    mats[mats.Count - 1].color = invisColor;
                }
            }
        }
            RestoreMaterials(dontChangeBack);
    }
    void RestoreMaterials(List<Material> dCB)
    {
        for (int i = 0; i < mats.Count; i++)
        {
            for (int j = 0; j < dCB.Count; j++)
            {
                if (mats[i] == dCB[j])
                    break;
                if (j == dCB.Count - 1)
                {
                    Color originalColor = mats[i].color;
                    originalColor.a = 1.0f;
                    mats[i].color = originalColor;
                    mats.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
