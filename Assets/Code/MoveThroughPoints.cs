using System.Linq;
using UnityEngine;

public class MoveThroughPoints : MonoBehaviour {
        [SerializeField]
        private float displacementPerSecond = 1;

        private Vector3[] Points { get; set; }
        private int[] PathIndices { get; set; }
        private int CurrentPathIndex { get; set; }
        private float t { get; set; }
        private bool IsMoving { get; set; } = false;

        private void Start() {
                foreach (var r in Points) print(r);
                foreach (var r in PathIndices) print(r);
        }

        void Update() {
                if (!IsMoving || PathIndices.Length < 2) return;

                //COMPL�TEZ � PARTIR D'ICI

                // Get current start and end points based on path indices
                Vector3 start = Points[PathIndices[CurrentPathIndex]];
                Vector3 end = Points[PathIndices[CurrentPathIndex + 1]];

                // Calculate distance between points
                float distance = Vector3.Distance(start, end);

                t += ( displacementPerSecond / distance ) * Time.deltaTime;
                transform.position = Vector3.Lerp(start, end, t);

                // If we've reached the end point
                if (t >= 1f) {
                        t = 0f;
                        CurrentPathIndex++;

                        // Stop moving if we've reached the last point
                        if (CurrentPathIndex >= PathIndices.Length - 1) {
                                IsMoving = false;
                        }
                }


        }

        public void StartMove(Vector3[] points, int[] pathIndices) {
                Points = points;
                PathIndices = pathIndices;
                IsMoving = true;
                CurrentPathIndex = 0;
        }

        public void StartMove(Vector3[] points) {
                PathIndices = Enumerable.Range(0, points.Length).ToArray();
                StartMove(points, PathIndices);
        }
}
