using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CoreAnimation))]
[CanEditMultipleObjects]
public class CoreAnimationEditor : Editor
{
    SerializedProperty enterAnimation;
    SerializedProperty exitAnimation;

    SerializedProperty enterDuration;
    SerializedProperty exitDuration;

    SerializedProperty positionInFrom;
    SerializedProperty rotationInFrom;
    SerializedProperty scaleInFrom;

    SerializedProperty positionOutTo;
    SerializedProperty rotationOutTo;
    SerializedProperty scaleOutTo;

    SerializedProperty autoRotate;
	SerializedProperty rotateSpeedX;
	SerializedProperty rotateSpeedY;
    SerializedProperty rotateSpeedZ;

    SerializedProperty autoVibrate;
    SerializedProperty frequencyX;
	SerializedProperty frequencyY;
    SerializedProperty frequencyZ;

    SerializedProperty magnitudeX;
	SerializedProperty magnitudeY;
    SerializedProperty magnitudeZ;

    SerializedProperty phaseX;
	SerializedProperty phaseY;
    SerializedProperty phaseZ;

    void OnEnable()
    {
        enterAnimation = serializedObject.FindProperty("enterAnimation");
        exitAnimation = serializedObject.FindProperty("exitAnimation");

        enterDuration = serializedObject.FindProperty("m_EnterDuration");
        exitDuration = serializedObject.FindProperty("m_ExitDuration");

        positionInFrom = serializedObject.FindProperty("m_PositionInFrom");
        rotationInFrom = serializedObject.FindProperty("m_RotationInFrom");
        scaleInFrom = serializedObject.FindProperty("m_ScaleInFrom");

        positionOutTo = serializedObject.FindProperty("m_PositionOutTo");
        rotationOutTo = serializedObject.FindProperty("m_RotationOutTo");
        scaleOutTo = serializedObject.FindProperty("m_ScaleOutTo");

        autoRotate = serializedObject.FindProperty("m_AutoRotate");
        rotateSpeedX = serializedObject.FindProperty("m_RotateSpeedX");
	    rotateSpeedY = serializedObject.FindProperty("m_RotateSpeedY");
        rotateSpeedZ = serializedObject.FindProperty("m_RotateSpeedZ");

        autoVibrate = serializedObject.FindProperty("m_AutoVibrate");
        frequencyX = serializedObject.FindProperty("m_FrequencyX");
        frequencyY = serializedObject.FindProperty("m_FrequencyY");
        frequencyZ = serializedObject.FindProperty("m_FrequencyZ");

        magnitudeX = serializedObject.FindProperty("m_MagnitudeX");
        magnitudeY = serializedObject.FindProperty("m_MagnitudeY");
        magnitudeZ = serializedObject.FindProperty("m_MagnitudeZ");

        phaseX = serializedObject.FindProperty("m_PhaseX");
        phaseY = serializedObject.FindProperty("m_PhaseY");
        phaseZ = serializedObject.FindProperty("m_PhaseZ");

    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(enterAnimation);
        if(enterAnimation.enumValueIndex != (int)CoreAnimation.EnterAnimation.None && 
            enterAnimation.enumValueIndex != (int)CoreAnimation.EnterAnimation.Appear)
        {
            EditorGUILayout.Slider(enterDuration, 0f, 10f, new GUIContent(" Enter Duration"));
        }

        if (enterAnimation.enumValueIndex == (int)CoreAnimation.EnterAnimation.TransformIn)
        {
            GUILayout.Label(" From Transform");
            EditorGUILayout.PropertyField(positionInFrom, new GUIContent("  Position"));
            EditorGUILayout.PropertyField(rotationInFrom, new GUIContent("  Rotation"));
            EditorGUILayout.PropertyField(scaleInFrom,    new GUIContent("  Scale"));
        }


        EditorGUILayout.PropertyField(exitAnimation);
        if (exitAnimation.enumValueIndex != (int)CoreAnimation.ExitAnimation.None &&
            exitAnimation.enumValueIndex != (int)CoreAnimation.ExitAnimation.Disappear)
        {
            EditorGUILayout.Slider(exitDuration, 0f, 10f, new GUIContent(" Exit Duration"));
        }

        if (exitAnimation.enumValueIndex == (int)CoreAnimation.ExitAnimation.TransformOut)
        {
            GUILayout.Label(" To Transform");
            EditorGUILayout.PropertyField(positionOutTo, new GUIContent("  Position"));
            EditorGUILayout.PropertyField(rotationOutTo, new GUIContent("  Rotation"));
            EditorGUILayout.PropertyField(scaleOutTo,    new GUIContent("  Scale"));
        }

        GUILayout.Label("Rest Animation");
        EditorGUILayout.PropertyField(autoRotate, new GUIContent(" Auto Rotate"));
        if (autoRotate.boolValue)
        {
            EditorGUILayout.Slider(rotateSpeedX, -50f, 50f, new GUIContent("  Rotation X"));
            EditorGUILayout.Slider(rotateSpeedY, -50f, 50f, new GUIContent("  Rotation Y"));
            EditorGUILayout.Slider(rotateSpeedZ, -50f, 50f, new GUIContent("  Rotation Z"));
        }

        EditorGUILayout.PropertyField(autoVibrate, new GUIContent(" Auto Vibrate"));
        if (autoVibrate.boolValue)
        {
            EditorGUILayout.Slider(frequencyX, 0f, 10f, new GUIContent("  Frequency X"));
            EditorGUILayout.Slider(magnitudeX, 0f, 10f, new GUIContent("  Magnitude X"));
            EditorGUILayout.Slider(phaseX, -Mathf.PI, Mathf.PI, new GUIContent("  Phase X"));

            EditorGUILayout.Slider(frequencyY, 0f, 10f, new GUIContent("  Frequency Y"));
            EditorGUILayout.Slider(magnitudeY, 0f, 10f, new GUIContent("  Magnitude Y"));
            EditorGUILayout.Slider(phaseY, -Mathf.PI, Mathf.PI, new GUIContent("  Phase Y"));

            EditorGUILayout.Slider(frequencyZ, 0f, 10f, new GUIContent("  Frequency Z"));
            EditorGUILayout.Slider(magnitudeZ, 0f, 10f, new GUIContent("  Magnitude Z"));
            EditorGUILayout.Slider(phaseZ, -Mathf.PI, Mathf.PI, new GUIContent("  Phase Z"));
        }

        serializedObject.ApplyModifiedProperties();
    }
}
