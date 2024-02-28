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
         [Space(10)]
    
    //Liste des batraciens à créer
         [Header("   Tower data")]
    [SerializeField] private List<BatracienType> batraciensForConstruction;
    [SerializeField] public BatracienTower towerData;
    
    //Liste de batraciens créer
    [HideInInspector] public List<GameObject> batraciensInTower;
    private Batracien batracienOnGround;
    [Space(10)]
         [Header("   Tower")]
    [SerializeField] private Transform baseLocation;

    [SerializeField] [Range(-1, 1)] public float hauteurOffset;

    
    private void Start()
    {
        CleanTower();
        CreateTower();
    }

    public void CreateTower()
    {
        
        if (towerData)
        {
            batraciensForConstruction = towerData.batraciensForConstruction;
          //  towerData.batraciensForConstruction = batraciensForConstruction;
        }
        GetComponent<Scr_TowerManager>().offset = hauteurOffset;

        if (baseLocation != null)
        {
            baseLocation = GameObject.Find("BaseLocation").transform;
        }
        
        Vector3 loc = baseLocation.position;//Location de base où créer
        
        Debug.Log("Position " + loc);

        float oldHaut = loc.y;
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

            float spriteSize = 0;

            float haut = (oldHaut ) + (spriteSize) ; //Set une hauteur de base pour le premier
            //Calcul de la hauteur en fonction du batracien à rajouter
            if (batracienToCreate.GetComponentInChildren<SpriteRenderer>())
            {
                if (i > 0)
                {
                    spriteSize = batraciensInTower[i-1].GetComponentInChildren<SpriteRenderer>().bounds.size.y;
                    haut = (oldHaut ) //Loaction de base
                           + (spriteSize) //Hauteur du sprite
                           + (hauteurOffset ) ;//Offset
                    oldHaut = haut;
                }
                   
            }
   

            //Créer le batracien
            GameObject batracienCreate = Instantiate(batracienToCreate, new Vector3(loc.x, haut, loc.z), baseLocation.rotation, baseLocation);
            batracienCreate.GetComponentInChildren<SpriteRenderer>().sortingOrder -= i;
            batraciensInTower.Add(batracienCreate);
            
           gameObject.GetComponent<Scr_TowerManager>().batraciensInTower = batraciensInTower;

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

#if UNITY_EDITOR
#endif