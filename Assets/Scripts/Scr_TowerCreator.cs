using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
public class Scr_TowerCreator : MonoBehaviour
{
          [Header("Batracien Prefab")]
    [SerializeField] private GameObject frogPrefab;
    [SerializeField] private GameObject toadPrefab;
    [SerializeField] private GameObject toadShieldLeftPrefab;
    [SerializeField] private GameObject toadShieldRightPrefab;
         [Space(10)]
    
    //Liste des batraciens à créer
         [Header("   Tower data")]
    [SerializeField] private List<BatracienType> batraciensForConstruction;
    [SerializeField] private BatracienTower towerData;
    
    //Liste de batraciens créer
    [HideInInspector] public List<GameObject> batraciensInTower;
    private Batracien batracienOnGround;
    [Space(10)]
         [Header("   Tower")]
    [SerializeField] private Transform baseLocation;

    [SerializeField] [Range(0, 1)] public float hauteurOffset;
    
    public void CreateTower()
    {
        
        if (towerData)
        {
            batraciensForConstruction = towerData.batraciensForConstruction;
            towerData.batraciensForConstruction = batraciensForConstruction;
        }
        GetComponent<Scr_TowerManager>().offset = hauteurOffset;

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
            
           gameObject.GetComponent<Scr_TowerManager>().batraciensInTower=  batraciensInTower;

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

    public void SetLevelData()
    {
        if (towerData)
        {
            towerData.batraciensForConstruction = batraciensForConstruction;
        }
    }
    
    
}

#endif