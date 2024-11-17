using GraphLib;
using UnityEngine;

public class Enemy : MonoBehaviour {
        //� COMPL�TER � PARTIR D'ICI


        [SerializeField] int n1;
        [SerializeField] int n2;

        [SerializeField]
        PositionGraphBuilder graphBuilder;

        [SerializeField]
        MoveThroughPoints mvtp;

        private void Start() {
                // Get path indices from A* search
                var pathIndices = Pathfinding.GetPathAStar(graphBuilder.Graph, n1, n2,
                        (a, b) => {
                                Vector3 posA = graphBuilder.positions[a];
                                Vector3 posB = graphBuilder.positions[b];
                                return Vector3.Distance(posA, posB);
                        });

                // Get positions for each node in the path
                Vector3[] pathPositions = new Vector3[pathIndices.Count];
                for (int i = 0;i < pathIndices.Count;i++) {
                        pathPositions[i] = graphBuilder.positions[pathIndices[i]];
                }

                // Start moving through the positions
                mvtp.StartMove(pathPositions);
        }
}
