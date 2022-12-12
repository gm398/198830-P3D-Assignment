using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PerlinScript : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] int width = 10;
    [SerializeField] int length = 10;
    [SerializeField] float offset = 1f;
    [SerializeField] float perlinMulti = 10f;

    [Range (0.0f, .5f)]
    [SerializeField] float perlinScale = .01213f;

    [SerializeField] float changeSpeed = 10f;
    bool done = false;
    GameObject[,] cubes;
    MeshCollider collider;

    Mesh mesh;
    Vector3[] verticies;
    int[] triangles;
    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        cubes = new GameObject[width, length];

        verticies = new Vector3[(width + 1) * (length + 1)];
         
        int i = 0;
        for (int z = 0; z <= length; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                Vector3 pos = new Vector3(x, GetNoise(x, z), z);
                //cubes[x, z] = Instantiate(block, pos, Quaternion.identity);
                verticies[i] = pos;
                i++;
                
            }
        }

        triangles = new int[width * length * 6];

        int tris = 0;
        int vert = 0;
        for (int z = 0; z < length; z++)
        {
            for (int x = 0; x < width; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                tris += 6;
                vert++;
            }
            vert++;
        }

        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        collider = GetComponent<MeshCollider>();
        
        collider.sharedMesh = mesh;

    }
    // Update is called once per frame
    void Update()
    {
        
        Perlin();
        done = true;
        
        //perlinScale += changeSpeed * Time.deltaTime;
        if(perlinScale > 1) { changeSpeed *= -1; perlinScale = 1; }
        if(perlinScale < 0) { changeSpeed *= -1; perlinScale = 0; }
        offset += changeSpeed * Time.deltaTime;
    }

    void Perlin()
    {
        int i = 0;
        for (int z = 0; z <= length; z++)
        {
            for (int x = 0; x <= width; x++)
            {
                Vector3 pos = new Vector3(x, GetNoise(x, z), z);
                //cubes[x, z] = Instantiate(block, pos, Quaternion.identity);
                verticies[i] = pos;
                i++;

            }
        }
        int tris = 0;
        int vert = 0;
        for (int z = 0; z < length; z++)
        {
            for (int x = 0; x < width; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + width + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + width + 1;
                triangles[tris + 5] = vert + width + 2;

                tris += 6;
                vert++;
            }
            vert++;
        }

        mesh.Clear();
        mesh.vertices = verticies;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        collider.sharedMesh = mesh;
    }

    float GetNoise(float x, float z)
    {
        
        //x += perlinScale;
        //z += perlinScale;
        float noise = Mathf.PerlinNoise((x + offset) * perlinScale, (z + offset) * perlinScale);
        //float noise = Mathf.Sin((x * z + offset)* perlinScale);
        return noise * perlinMulti;
    }
}
