using System;
using Array2DEditor;
using JetBrains.Annotations;
using UnityEngine;

namespace Game
{
    public class BrickCreator : MonoBehaviour
    {
        [Header("Assignments")] [SerializeField]
        private BrickController brickPrefab;

        [SerializeField] private Transform leftLimit;
        [SerializeField] private Transform rightLimit;
        [SerializeField] private Transform bricksStartPoint;
        [SerializeField] private Transform bricksParent;

        [Header("Set in Editor")]
        [Tooltip("The distance between the rows")]
        [Range(.5f, 1.5f)]
        [SerializeField]
        private float rowsDistance;

        [Tooltip(
            "The default number of columns that will be used to rescale the bricks when needed")]
        [SerializeField]
        private uint defaultColumnsCount;

        /// <summary>
        /// Creates all the bricks of the level and also assign the OnDestroyed event to them.
        /// </summary>
        /// <param name="bricksLayout">The current bricks layout</param>
        /// <param name="onBrickDestroyed">The callback for when a brick is destroyed.</param>
        public void CreateBricks(Array2DBool bricksLayout, [NotNull] Action onBrickDestroyed)
        {
            var bricks = bricksLayout.GetCells();
            var rows = bricks.GetLength(0);
            var columns = bricks.GetLength(1);

            var (left, right) = (leftLimit.position.x, rightLimit.position.x);
            var gameArea = right - left;
            var columnsDistance = gameArea / columns;
            var distanceFromWall = left + columnsDistance / 2;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (bricks[i, j])
                    {
                        var brickPos = new Vector2(distanceFromWall + columnsDistance * j,
                            bricksStartPoint.transform.position.y - rowsDistance * i);
                        InstantiateBrick(brickPos, columns, onBrickDestroyed);
                    }
                }
            }
        }

        private void InstantiateBrick(Vector2 pos, int columnsCount,
            [NotNull] Action onBrickDestroyed)
        {
            var brick = Instantiate(brickPrefab, pos, Quaternion.identity, bricksParent);
            var scale = brick.transform.localScale;
            scale.x *= GetSizeByColumnsCount(columnsCount);
            brick.transform.localScale = scale;
            brick.OnDestroyed += onBrickDestroyed;
        }

        private float GetSizeByColumnsCount(int columnsCount)
        {
            return defaultColumnsCount / (float) columnsCount;
        }
    }
}