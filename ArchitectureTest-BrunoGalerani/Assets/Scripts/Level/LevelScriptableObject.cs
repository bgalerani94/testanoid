using Array2DEditor;
using UnityEngine;

namespace Level
{
    /// <summary>
    /// This class represents the LevelScriptableObjectData
    /// </summary>
    [CreateAssetMenu(fileName = "New Level", menuName = "Testanoid/Level")]
    public class LevelScriptableObject : ScriptableObject
    {
        public Array2DBool levelGrid;

        public uint GetBricksCount()
        {
            uint bricks = 0;
            var grid = levelGrid.GetCells();
            for (var i = 0; i < grid.GetLength(0); i++)
            {
                for (var j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j])
                    {
                        bricks++;
                    }
                }
            }

            return bricks;
        }
    }
}