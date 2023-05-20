using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityUtility;

namespace UnityAssetRegistry
{
    public class AssetRefEditor<ASSET> : PropertyDrawer
        where ASSET : UnityEngine.Object
    {
        public override void OnGUI(
            Rect position, 
            SerializedProperty property, 
            GUIContent label)
        {
            EditorGUI.BeginChangeCheck();

            var prop = (AssetRef)property.GetTargetObjectOfProperty();

            if (prop != null)
                prop.SetGuid(AssetField($"{label.text} [ref]", prop.Guid, position));
            else
                AssetField($"{label.text} [ref]", null, position);

            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(property.serializedObject.targetObject);

                if (property.serializedObject.targetObject is Component)
                {
                    var comp = property.serializedObject.targetObject as Component;

                    if (comp.gameObject != null &&
                        comp.gameObject.scene != null)
                        EditorSceneManager.MarkSceneDirty(comp.gameObject.scene);
                }
            }
        }

        public override float GetPropertyHeight(
            SerializedProperty property, 
            GUIContent label)
        {
            return 16;
        }

        string AssetField(
            string label, 
            string guid, 
            Rect position)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<ASSET>(path);

            asset = (ASSET)EditorGUI.ObjectField(position, label, asset, typeof(ASSET), false);
            path = AssetDatabase.GetAssetPath(asset);

            return AssetDatabase.AssetPathToGUID(path);
        }
    }
}