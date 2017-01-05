using UnityEngine;
using System.Collections;
using UnityEditor;

namespace UnityPresentationFramework.Inspector{
	//[CustomEditor(typeof(PlayerController))]
	public class PlayerEditor : Editor {

		SerializedProperty allSlides;
		SerializedProperty initialSlide;

		void OnEnable(){
			allSlides = serializedObject.FindProperty("m_AllSlides");
			initialSlide = serializedObject.FindProperty ("m_InitialSlide");
		}
		
		public override void OnInspectorGUI(){
			serializedObject.Update ();

			//EditorGUI.BeginChangeCheck();
			//EditorGUILayout.Popup(initialSlide, allSlides);
			//if(EditorGUI.EndChangeCheck())
				//serializedObject.ApplyModifiedProperties();
		}
	}
}
