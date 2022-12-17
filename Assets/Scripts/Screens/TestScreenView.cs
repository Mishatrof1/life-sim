using System;
using Modules;
using Spine.Unity;
using UnityEngine;
using Random = System.Random;

namespace Screens
{
    public class TestScreenView : MonoBehaviour
    {
        // public GameObject FacePrefab;
        // public GameObject FacePrefab2;
        // public Transform Face1Parent;
        // public Transform Face2Parent;
        //
        // private GameObject Face1;
        // private GameObject Face2;
        // private float timeLeft = 0;
        //
        // private void Start()
        // {
        //     var app1 = GeneratePersonApperance();
        //     Face1 = Instantiate(FacePrefab, Face1Parent, false);
        //     Face1.GetComponent<FaceAnim>().Setup(app1);
        //     timeLeft = 2f;
        // }
        //
        // private void Update()
        // {
        //     if (timeLeft > 0)
        //     {
        //         timeLeft -= Time.deltaTime;
        //     }
        //
        //     if (timeLeft < 0)
        //     {
        //         timeLeft = 0;
        //         var app2 = GeneratePersonApperance();
        //         Face2 = Instantiate(FacePrefab2, Face2Parent, false);
        //         Face2.GetComponent<FaceAnim>().Setup(app2);
        //     }
        //     
        //     if (Input.GetKeyDown(KeyCode.Q))
        //     {
        //         var Sa = Face1.GetComponent<MeshRenderer>();
        //         foreach (var mat in Sa.materials)
        //         {
        //             if (mat.name.Contains("emotions_anim_hair_front"))
        //             {
        //                 mat.SetColor("_Color", Color.green);
        //             }
        //         }
        //     }
        // }
        //
        // public Appearance GeneratePersonApperance()
        // {
        //     ApperanceAge Age = ApperanceAge.Baby;
        //     
        //     Random rnd = new Random();
        //     int value = rnd.Next(0, 3);
        //     ApperanceRace Race = ApperanceRace.Asian;
        //     if (value == 1)
        //     {
        //         Race = ApperanceRace.Black;
        //     }
        //     if (value == 2)
        //     {
        //         Race = ApperanceRace.European;
        //     }
        //
        //     ApperanceSex Sex = ApperanceSex.Male;
        //
        //     int LipsType = rnd.Next(0, 2);
        //     int EyesType = rnd.Next(0, 2);
        //     int HairType = rnd.Next(0, 2);
        //     int FaceType = rnd.Next(0, 2);
        //     int BrowsType = rnd.Next(0, 2);
        //     
        //     Color EyesColor = GetRandomColor(rnd);
        //     Color HairColor = GetRandomColor(rnd);
        //     Color LipsColor = GetRandomColor(rnd);
        //     Color SkinColor = GetRandomColor(rnd);
        //     
        //     return new Appearance(Age, Race, Sex, LipsType, EyesType, HairType, FaceType, BrowsType, null, null, null, null, null, EyesColor, HairColor, LipsColor, SkinColor);
        // }
        //
        // public Color GetRandomColor(Random rnd)
        // {
        //     int Red = rnd.Next(0, 255);
        //     int Green = rnd.Next(0, 255);
        //     int Blue = rnd.Next(0, 255);
        //     return new Color(Red / 255f, Green / 255f, Blue / 255f);
        // }
    }
}