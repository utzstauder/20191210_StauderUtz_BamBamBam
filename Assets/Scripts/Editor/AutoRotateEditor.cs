using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoRotateInput))]
public class AutoRotateEditor : Editor
{
    private void OnSceneGUI()
    {
        AutoRotateInput autoRotateInput = target as AutoRotateInput;

        Vector3 fromVector = Quaternion.AngleAxis(
            angle: -autoRotateInput.rotationAngle / 2f,
            axis: autoRotateInput.transform.up
            ) * autoRotateInput.transform.forward;

        Handles.color = new Color(0, 1f, 0, 0.05f);
        Handles.DrawSolidArc(
            center: autoRotateInput.transform.position,
            normal: autoRotateInput.transform.up,
            from: fromVector,
            angle: autoRotateInput.rotationAngle,
            radius: autoRotateInput.radius * HandleUtility.GetHandleSize(autoRotateInput.transform.position)
            );

        Handles.color = Color.green;
        for (float r = 0; r < autoRotateInput.radiusThickness; r += autoRotateInput.radiusThickness * 0.01f)
        {
            Handles.DrawWireArc(
                center: autoRotateInput.transform.position,
                normal: autoRotateInput.transform.up,
                from: fromVector,
                angle: autoRotateInput.rotationAngle,
                radius: (autoRotateInput.radius + r) * HandleUtility.GetHandleSize(autoRotateInput.transform.position)
                );
        }

        //Handles.BeginGUI();
        //{
        //    GUILayout.BeginHorizontal();
        //    {
        //        GUILayout.BeginVertical();
        //        {
        //            for (int i = 0; i < 5; i++)
        //            {
        //                if (GUILayout.Button("Hallo, ich bin Buton " + i))
        //                {
        //                    Debug.Log("Klick!");
        //                }
        //            }
        //        }
        //        GUILayout.EndVertical();

        //        if (GUILayout.Button("Hallo, ich bin ein Button."))
        //        {
        //            Debug.Log("Klick!");
        //        }
        //    }
        //    GUILayout.EndHorizontal();
        //}
        //Handles.EndGUI();
    }
}
