using UnityEngine;
using System.Collections;
using UnityEditor;

namespace UnityPresentationFramework.Inspector{
	[CustomEditor(typeof(PlayerController))]
	public class PlayerEditor : Editor {

		SerializedProperty allSlides;
		SerializedProperty enabledSlides;
		SerializedProperty lookAt;
		SerializedProperty initialSlide;

		SerializedProperty cameraRig;

		private string[] m_SlideNames;
		private string[] m_SlideNamesEnabled;

		void OnEnable(){
			allSlides = serializedObject.FindProperty("m_AllSlides");
			enabledSlides = serializedObject.FindProperty("m_EnabledSlides");
			lookAt = serializedObject.FindProperty ("m_PreviewAt");
			initialSlide = serializedObject.FindProperty ("m_InitialSlide");
			cameraRig = serializedObject.FindProperty ("m_CameraRig");
		}

		public override void OnInspectorGUI(){
			
			serializedObject.Update ();

			m_SlideNames = new string[allSlides.arraySize];
			for(int i=0; i < allSlides.arraySize; i++){
				m_SlideNames [i] = allSlides.GetArrayElementAtIndex (i).objectReferenceValue.name;
			}
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField(cameraRig);
			EditorGUILayout.PropertyField (allSlides, true);
			GUILayout.Label("Look At Slide ");
			lookAt.intValue = EditorGUILayout.Popup(lookAt.intValue, m_SlideNames);


			if(EditorGUI.EndChangeCheck())
				serializedObject.ApplyModifiedProperties();
		}
	}
}
