using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallInvisibilityScript : MonoBehaviour
{

    public Transform _camera;

    List<Material> mats;

    void Start()
    {
        mats = new List<Material>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, _camera.position - transform.position);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            if (hit.transform.gameObject.tag == "Wall")
            {
                GameObject wall = hit.transform.gameObject;
                Material mat = wall.GetComponent<Renderer>().material;
                for (int j = 0; j < mats.Count; j++)
                {
                    if (mats[0] == mat)
                    {
                        
                    }
                }
                Color invisColor = wall.GetComponent<Renderer>().material.color;
                invisColor.a = 0.2f;
                mats.Add(wall.GetComponent<Renderer>().material);
                mats[mats.Count - 1].color = invisColor;
            }

        }
    }
}
