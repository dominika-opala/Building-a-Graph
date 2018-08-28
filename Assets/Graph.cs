using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    [Range(10, 100)]
    public int resolution = 10;
    public Transform pointPrefab;
    Transform[] points;

    private void Awake() {

        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step; // *function and variable*
        Vector3 position;
        position.y = 0f;
        position.z = 0f;
        // int i = 0 helps keep track of how many times the code was repeated in the loop.
        points = new Transform[resolution];
        for (int i = 0; i < points.Length; i++) {
            Transform point = Instantiate(pointPrefab);
            // (i = i + 1) -> (++ 1) each time the value is added to i until the "while-loop" expression evaluates false. 
            position.x = (i + 0.5f) * step - 1f;
            point.localPosition = position;
            point.localScale = scale; // here we reduce the scale of cubes, and bring them back together, by dividing the position by the same value
            point.SetParent(transform, false);
            points[i] = point;

        }
    }

    void Start () {
		
	}
	
	void Update () {
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            point.localPosition = position;
        }
    }
}
