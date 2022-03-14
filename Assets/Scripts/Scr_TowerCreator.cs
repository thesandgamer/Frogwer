using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_TowerCreator : MonoBehaviour
{
    [Header("Batracien Prefab")]
    [SerializeField] private GameObject frogPrefab;
    [SerializeField] private GameObject toadPrefab;
    [SerializeField] private GameObject toadShieldLeftPrefab;
    [SerializeField] private GameObject toadShieldRightPrefab;
    
    //Liste des batraciens à créer
    [SerializeField] private List<BatracienType> batraciensForConstruction;

    //Liste de batraciens créer
   [HideInInspector] public List<GameObject> batraciensInTower;

    private Batracien batracienOnGround;

    [SerializeField] private Transform baseLocation;

    [SerializeField] [Range(0, 1)] public float hauteurOffset;


    public void CreateTower()
    {
        if (baseLocation != null)
        {
            baseLocation = GameObject.Find("BaseLocation").transform;
        }
        
        Vector3 loc = baseLocation.position;//Location de base où créer
        
        Debug.Log("Position " + loc);

        
        for (int i = 0; i < batraciensForConstruction.Count; i++)
        {
            //Décide de quel batracien on va créer
            GameObject batracienToCreate = null;
            switch (batraciensForConstruction[i])
            {
                case BatracienType.Frog:
                    batracienToCreate = frogPrefab;
                    break;
                case BatracienType.Toad:
                    batracienToCreate = toadPrefab;
                    break;
                case BatracienType.ToadShieldLeft:
                    batracienToCreate = toadShieldLeftPrefab;
                    break;
                case BatracienType.ToadShieldRight:
                    batracienToCreate = toadShieldRightPrefab;
                    break;
                
            }
            
            //Hauteur où créer
            float haut = (loc.y ) //Loaction de base
                         + (batracienToCreate.GetComponent<MeshFilter>().sharedMesh.bounds.size.y * i) //Hauteur du mesh
                                                 + (hauteurOffset * i) ;//Offset

            //Créer le batracien
            GameObject batracienCreate = Instantiate(batracienToCreate, new Vector3(loc.x, haut, loc.z), baseLocation.rotation, baseLocation);
            batraciensInTower.Add(batracienCreate);
        }
    }


    public void CleanTower()
    {
        
        foreach (GameObject batracien in batraciensInTower) 
        {
            DestroyImmediate(batracien);
        }
        batraciensInTower.Clear();

        for (int i = 0; i < baseLocation.childCount; i++)
        {
            GameObject go = baseLocation.GetChild(i).gameObject;
            DestroyImmediate(go);
        }
    }
    
    
}