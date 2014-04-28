using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StripeScript : MonoBehaviour {
	Mesh mesh;
	Vector3[] vertices;
	Vector2[] uvs;
	Vector3[] normals;
	int[] triangles;
	List<int> trianglesList;
	Color[] colors;


	int length = 12;
	int height = 4;

	// Use this for initialization
	void Start () {
		trianglesList = new List<int>();

		mesh = new Mesh();
		vertices = new Vector3[length*height];
		uvs = new Vector2[length*height];
		normals = new Vector3[length*height];
		triangles = new int[ 2 * 3 * (height-1)*(length-1) ]; // 2 triangles for every point except the ends
		colors = new Color[length*height];


		GetComponent<MeshFilter>().mesh = mesh;
		for(int i = 0; i < length; i++){ // For each row
			for(int j = 0; j < height; j++){ // For each column
				vertices[ height * i + j ] = new Vector3( i , j, 0.0F );
				Vector2 uv = new Vector2();
				uv.x = (i%2 == 0) ? 1.0F : 0.0F;
				uv.y = (j%2 == 0) ? 1.0F : 0.0F;
				uvs[height*i + j] = uv;
				normals[height*i + j] = Vector3.forward;

				colors[height*i + j] = Color.red;

				if(i<length-1 && j<height-1){
					trianglesList.Add(height*i);
					trianglesList.Add(height*i+1);
					trianglesList.Add(height*i+height);

					trianglesList.Add(height*i + height);
					trianglesList.Add(height*i+height+1);
					trianglesList.Add(height*i+1);
////
//					triangles[6 * ((height-1)*i + j)] = height*i+1;
//					triangles[6 * ((height-1)*i + j) + 1] = height*i;
//					triangles[6 * ((height-1)*i + j) + 2] = height*i+height; // clockwise
//					
//					triangles[6 * ((height-1)*i + j) + 3] = height*i+height;
//					triangles[6 * ((height-1)*i + j) + 4] = height*i+height+1;
//					triangles[6 * ((height-1)*i + j) + 5] = height*i+1;

				}
			}


		}
		mesh.vertices = vertices;
		mesh.uv = uvs;
		mesh.normals = normals;
		mesh.triangles = triangles;
		mesh.triangles = trianglesList.ToArray ();
		mesh.colors = colors;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
