using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MajorGenerator : MonoBehaviour
{

    private string[] MajorSubjectList = { "Dance", "Fitness", "Golf", "Health", "Outdoor", "Martial Arts", "Lifetime", "Varsity", "Religious", "Exercise", "Music", "Art", "Theatre" };
    private string[] MajorActionList = { "Awareness", "Studies", "Science", "Theory", "History", "Education", "Training" };
    private string Major;
    public GameObject CanvasObject;

    // Use this for initialization
    void Start()
    {
        GetNewMajor();
    }

    // Gets a new major
    public void GetNewMajor()
    {
        Major = MajorSubjectList[Random.Range(0, MajorSubjectList.Length - 1)] + " " + MajorActionList[Random.Range(0, MajorActionList.Length - 1)];
        CanvasObject.GetComponent<Text>().text += Major;
    }

    // Changes your current major
    public void ChangeMajor()
    {
        Major = MajorSubjectList[Random.Range(0, MajorSubjectList.Length - 1)] + " " + MajorActionList[Random.Range(0, MajorActionList.Length - 1)];
    }

    // Gets current major
    public string GetMajor()
    {
        return Major;
    }
}
