using UnityEngine;
using XNode;
using XNodeEditor;

namespace DialogSystem.Editor
{
    [CustomNodeEditor(typeof(DialogNode))]
    public class StartNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            serializedObject.Update();

            DialogNode node = target as DialogNode;
         
            if (node.Responses.Count == 0)
            {
                GUILayout.BeginHorizontal();
                NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("Enter"), GUILayout.MinWidth(0));
                NodeEditorGUILayout.PortField(GUIContent.none, target.GetOutputPort("output"), GUILayout.MinWidth(0));
                GUILayout.EndHorizontal();
            }
            else
            {
                NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("Enter"));
            }
            GUILayout.Space(-30);

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Label"), GUIContent.none); 
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("MessageText"), GUIContent.none);
         
            GUILayout.BeginVertical();
        
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("ListConditions"));

            if (node.ListConditions.Contains(ConditionType.Age))
            {
                GUILayout.BeginHorizontal();
                NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("AgeCondition"));
                GUILayout.EndHorizontal();
            }

            GUILayout.Space(10);

            var propResults = serializedObject.FindProperty("Results");
            if (propResults != null)
            {
                NodeEditorGUILayout.PropertyField(propResults, includeChildren:false);
            }

            NodeEditorGUILayout.InstancePortList("Responses", typeof(Node), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override);

            GUILayout.EndVertical();
            serializedObject.ApplyModifiedProperties();
        }
        public override int GetWidth()
        {
            return 300;
        }

        public override Color GetTint()
        {
            DialogNode node = target as DialogNode;
            Color col = Color.gray;
            return col;
        }

    }
}
