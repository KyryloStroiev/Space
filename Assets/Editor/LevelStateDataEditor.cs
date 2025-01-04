using CodeBase.Gameplay.Levels;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LevelData))]
    public class LevelStateDataEditor: UnityEditor.Editor
    {
        private const string InitialPlayerPoint = "InitialPlayerPoint";
        private const string InitialMeteoritePoint = "InitialMeteoritePoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelData levelData = (LevelData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.PointPlayerInitialize = GameObject.FindWithTag(InitialPlayerPoint).transform.position;

                levelData.CenterPoitnEnemyInitialize = GameObject.FindWithTag(InitialMeteoritePoint).transform.position;
            }
        }
    }
}