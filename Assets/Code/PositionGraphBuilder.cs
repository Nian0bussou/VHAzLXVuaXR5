using UnityEngine;
using GraphLib;
using System;
using UnityEditor;

public class PositionGraphBuilder : MonoBehaviour {
        public enum Representation { Matrix, List };

        [SerializeField]
        private Representation representation;

        [SerializeField]
        private GridAsset grid;

        public Vector3[] positions;
        public IGraph Graph { get; private set; }

        private void Awake() {
                //COMPL�TEZ � PARTIR D'ICI

                //1. Cr�ez la bonne sorte d'IGraph selon la valeur de `representation`
                switch (representation) {
                        case Representation.Matrix:
                                Graph = new AdjacencyMatrix(grid.Size);
                                break;
                        case Representation.List:
                                Graph = new AdjacencyList(grid.Size);
                                break;
                }

                //2. Ajoutez les liens ("edges") au IGraph
                for (int i = 0;i < grid.Size;i++) {
                        for (int j = 0;j < grid.Size;j++) {
                                if (grid[i, j] != -1) {
                                        Graph.AddEdge(i, j, grid[i, j]);
                                }
                        }
                }
        }

        private void OnDrawGizmos() {
                if (!Application.isPlaying) return;

                Gizmos.color = Color.green; //set la couleur pour les sph�res et lignes � vert
                GUIStyle textStyle = new(); //cr�er un style pour le texte
                textStyle.normal.textColor = Color.black; //�crire le texte en noir

                //COMPL�TEZ � PARTIR D'ICI

                //1. Affichez une sph�re pour chaque noeud � sa position associ�e
                //   - Utilisez la m�thode `Gizmos.DrawSphere(.)`
                //   - Utilisez un rayon de 0.2f
                foreach (var p in positions) Gizmos.DrawSphere(p, 0.2f);

                //2. Affichez une ligne entre les noeuds connect�s par un lien
                //   - Utilisez la m�thode `Gizmos.DrawLine(.)`

                for (int i = 0;i < Graph.Count;i++) {
                        for (int j = 0;j < Graph.Count;j++) {
                                if (Graph[i, j] != -1) {
                                        Gizmos.DrawLine(positions[i], positions[j]);
                                }
                        }
                }

                //3. Affichez le co�t de chaque lien au centre de leur ligne
                //   - Utilisez `Vector3.Lerp(a, b, t)`
                //   - Utilisez `Handles.Label(position, texte, textStyle)
                for (int i = 0;i < Graph.Count;i++) {
                        for (int j = 0;j < Graph.Count;j++) {
                                if (Graph[i, j] != -1) { // Only show label if there's an edge
                                        var c = Vector3.Lerp(positions[i], positions[j], 0.5f);
                                        var msg = Graph[i, j].ToString();
                                        Handles.Label(c, msg);
                                }
                        }
                }
                //4. Affichez une petite sph�re verte pour repr�senter une pointe de fl�che
                //   - Utilisez `Gizmos.DrawSphere(.)
                //   - Utilisez un rayon de 0.1f

                for (int i = 0;i < Graph.Count;i++) {
                        for (int j = 0;j < Graph.Count;j++) {
                                if (Graph[i, j] != -1) {
                                        // Calculate the direction of the arrow
                                        Vector3 direction = ( positions[j] - positions[i] ).normalized;
                                        // Determine the position of the arrow tip (slightly before the node)
                                        Vector3 arrowTip = positions[j] - direction * 0.2f;
                                        Gizmos.DrawSphere(arrowTip, 0.1f);
                                }
                        }
                }
        }

        //OnValidate pourrait sans doute �tre optimis�e un peu, mais bon...
        private void OnValidate() {
                if (grid == null || grid.Size == 0) {
                        positions = new Vector3[0];
                        return;
                }

                int previousN = positions.Length;
                var previousPositions = new Vector3[previousN];

                Array.Copy(positions, previousPositions, previousN);

                positions = new Vector3[grid.Size];

                int min = Mathf.Min(grid.Size, previousN);
                Array.Copy(previousPositions, positions, min);
        }
}
