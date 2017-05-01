using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteInEditMode]
public class SectionController : MonoBehaviour
{


    List<Vector3> positions;
    public GameObject SitdownStudent;
    public GameObject StandupStudent;
    private int[] studentsMap;

    public int[] StudentsMap
    {
        get
        {
            return studentsMap;
        }

        set
        {
            studentsMap = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        this.positions = new List<Vector3>();
        var positionObjects = GameObject.FindGameObjectsWithTag("StudentPosition");

        //This need to be sorted by name as the positions will be mapped to an index of the studentsMap
        foreach (var position in positionObjects.OrderBy(x => x.name))
        {
            if (position.transform.IsChildOf(this.transform))
                positions.Add(position.transform.position);
        }
        

        Debug.Log(positions.ToString());

        InitStudents();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InitStudents()
    {
        for (int i = 0; i < studentsMap.Length; i++)
        {
            var typeStudent = studentsMap[i] == 0 ? SitdownStudent : StandupStudent;
            var obj = Instantiate(typeStudent) as GameObject;
            obj.transform.parent = this.gameObject.transform;

            obj.transform.position = positions[i];
            obj.transform.Translate(0, obj.GetComponent<Renderer>().bounds.size.y/2, 0);
        }
    }


}
