using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallInvisibilityScript : MonoBehaviour
{

    public Transform _camera;
    [SerializeField]
    List<Material> invMats; //Förra uppdateringens material som är "gömda"
    [SerializeField]
    List<Material> newInvMats; // De materialen som göms när denna uppdatering är klar
    [SerializeField]
    List<Material> newMats; //Material som inte fanns med i förra uppdateringen
    Material hitMat;
    Ray ray;
    RaycastHit[] hits;
    Color tempColor;
    float rayYOffset = 1.0f;

    void Start()
    {
        invMats = new List<Material>();
        newInvMats = new List<Material>();
        newMats = new List<Material>();
    }

    void Update()
    {
        ray = new Ray(transform.position + new Vector3(0.0f, rayYOffset, 0.0f), _camera.position - transform.position);
        hits = Physics.RaycastAll(ray);
        //Debug.DrawRay(transform.position + new Vector3(0.0f, rayYOffset, 0.0f), _camera.position - transform.position); // Se raycasten i scene
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].transform.gameObject.tag == "Wall")
            {
                hitMat = hits[i].transform.gameObject.GetComponent<Renderer>().material;
                if (invMats.Contains(hitMat))
                {
                    newInvMats.Add(hitMat);
                }
                else
                {
                    newMats.Add(hitMat);
                }
            }

        }
        for (int i = 0; i < invMats.Count; i++)
        {
            if (!newInvMats.Contains(invMats[i]))
            {
                tempColor = invMats[i].color;
                tempColor.a = 1.0f;
                invMats[i].color = tempColor;
            }
        }
        foreach (Material mat in newMats)
        {
            tempColor = mat.color;
            tempColor.a = 0.2f;
            mat.color = tempColor;
            newInvMats.Add(mat);
        }
        invMats.Clear();
        for (int i = 0; i < newInvMats.Count; i++)
        {
            invMats.Add(newInvMats[i]);
        }
        newInvMats.Clear();
        newMats.Clear();

    }
}