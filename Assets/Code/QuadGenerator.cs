using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuadGenerator : MonoBehaviour {
        public Mesh GenerateMesh() {
                Mesh m = new();

                //Créer les sommets
                Vector3[] quadVertices = new Vector3[4];
                quadVertices[0] = new Vector3(-.5f, .5f);
                quadVertices[1] = new Vector3(-.5f, -.5f);
                quadVertices[2] = new Vector3(.5f, -.5f);
                quadVertices[3] = new Vector3(.5f, .5f);

                //Créer les triangles
                int[] triangles =
                {
                    0,3,1,
                    3,2,1
                };

                m.vertices = quadVertices;
                m.triangles = triangles;
                m.RecalculateNormals();

                return m;
        }

        private void SaveMeshAsAsset(Mesh mesh, string assetName) {
                string path = $"Assets/{assetName}";
                AssetDatabase.CreateAsset(mesh, path);
                AssetDatabase.SaveAssets();
        }

        [ContextMenu("Generate quad")]
        public void GenerateAndSave()
            => SaveMeshAsAsset(GenerateMesh(), "quad.asset");
}
