using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallInvisibilityScript : MonoBehaviour {

    public Transform _camera;

    private List<Renderer> renderers = new List<Renderer>();

	void Start () {

	}
	
	
	void Update () {
        Ray ray = new Ray(transform.position, _camera.position - transform.position);

        RaycastHit[] hits;

        hits = Physics.RaycastAll(ray);

        Renderer[] renders = new Renderer[hits.Length];

        for(int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            if (rend)
            {
                rend.enabled = false;
                renders[i] = rend;

                if (!renderers.Contains(rend))
                {
                    renderers.Add(rend);
                }
            }

        }

        for (int i = 0; i < renderers.Count; i++)
        {
            if(!renders.Contains(renderers[i]))
            {
                renderers[i].transform.GetComponent<Renderer>().enabled = true;
                renderers.Remove(renderers[i]);
            }
        }
	}
}
