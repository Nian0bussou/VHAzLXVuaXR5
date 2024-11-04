using UnityEngine;
using GraphLib;
using System;
using UnityEditor;

public class PositionGraphBuilder : MonoBehaviour
{
    public enum Representation { Matrix, List };

    [SerializeField]
    private Representation representation;

    [SerializeField]
    private GridAsset grid;

    public Vector3[] positions;
    public IGraph Graph { get; private set; }

    private void Awake()
    {
        //COMPLÉTEZ À PARTIR D'ICI

        //1. Créez la bonne sorte d'IGraph selon la valeur de `representation`
        
        //2. Ajoutez les liens ("edges") au IGraph

    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;


        Gizmos.color = Color.green; //set la couleur pour les sphères et lignes à vert
        GUIStyle textStyle = new GUIStyle(); //créer un style pour le texte
        textStyle.normal.textColor = Color.black; //écrire le texte en noir

        //COMPLÉTEZ À PARTIR D'ICI

        //1. Affichez une sphère pour chaque noeud à sa position associée
        //   - Utilisez la méthode `Gizmos.DrawSphere(.)`
        //   - Utilisez un rayon de 0.2f
        
        //2. Affichez une ligne entre les noeuds connectés par un lien
        //   - Utilisez la méthode `Gizmos.DrawLine(.)`
        
        //3. Affichez le coût de chaque lien au centre de leur ligne
        //   - Utilisez `Vector3.Lerp(a, b, t)`
        //   - Utilisez `Handles.Label(position, texte, textStyle)

        //4. Affichez une petite sphère verte pour représenter une pointe de flèche
        //   - Utilisez `Gizmos.DrawSphere(.)
        //   - Utilisez un rayon de 0.1f
       
    }

    //OnValidate pourrait sans doute être optimisée un peu, mais bon...
    private void OnValidate()
    {
        if (grid == null || grid.Size == 0)
        {
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
