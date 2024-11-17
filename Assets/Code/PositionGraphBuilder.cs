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

                //2. Ajoutez les liens ("edges") au IGraph

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
                Gizmos.DrawSphere(new(0, 0, 0), 0.2f);


                //2. Affichez une ligne entre les noeuds connect�s par un lien
                //   - Utilisez la m�thode `Gizmos.DrawLine(.)`

                //3. Affichez le co�t de chaque lien au centre de leur ligne
                //   - Utilisez `Vector3.Lerp(a, b, t)`
                //   - Utilisez `Handles.Label(position, texte, textStyle)

                //4. Affichez une petite sph�re verte pour repr�senter une pointe de fl�che
                //   - Utilisez `Gizmos.DrawSphere(.)
                //   - Utilisez un rayon de 0.1f

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
