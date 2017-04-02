using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityPresentationFramework.Control;
using UnityPresentationFramework.Helpers;
using System.IO;

namespace UnityPresentationFramework.Inspector{

	[CustomEditor(typeof(PlayerController))]
	public class PlayerEditor : Editor
    {

		SerializedProperty slides;
        SerializedProperty autoPlay;
		SerializedProperty cameraRig;

		private string[] m_SlideNames;
		private string[] m_SlideNamesEnabled;
        private ReorderableList reorderableSlides;

        private void OnEnable(){
            slides = serializedObject.FindProperty("m_AllSlides");
			cameraRig = serializedObject.FindProperty ("m_CameraRig");
            autoPlay = serializedObject.FindProperty("m_AutoPlay");

            reorderableSlides = new ReorderableList(serializedObject, slides, true, true, true, true);
            reorderableSlides.drawHeaderCallback += DrawHeader;
            reorderableSlides.drawElementCallback += DrawElement;
            reorderableSlides.onAddDropdownCallback += AddItem;
            reorderableSlides.onRemoveCallback += RemoveItem;
            reorderableSlides.onSelectCallback += SelectItem;
        }

        private void OnDisable()
        {
            reorderableSlides.drawHeaderCallback -= DrawHeader;
            reorderableSlides.drawElementCallback -= DrawElement;
            reorderableSlides.onAddDropdownCallback -= AddItem;
            reorderableSlides.onRemoveCallback -= RemoveItem;
            reorderableSlides.onSelectCallback -= SelectItem;
        }

        /// <summary>
        /// Draws the header of the list
        /// </summary>
        /// <param name="rect"></param>
        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Slides");
        }

        /// <summary>
        /// Draws one element of the list (ListItemExample)
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="index"></param>
        /// <param name="active"></param>
        /// <param name="focused"></param>
        private void DrawElement(Rect rect, int index, bool active, bool focused)
        {
            var slide = slides.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, 
                slide, new GUIContent("Slide " + index));
            //new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight)
        }

        [MenuItem("Slides/New Slide 1", false, 1)]
        private void AddItem(Rect buttonRect, ReorderableList list)
        {
            var menu = new GenericMenu();

            var themePath = "Assets/Themes";
            var themes = Directory.GetDirectories(themePath);
            foreach (string theme in themes)
            {
                var guids = AssetDatabase.FindAssets("", new[] { string.Format("{0}/Templates", theme) });
                foreach (var guid in guids)
                {
                    var path = AssetDatabase.GUIDToAssetPath(guid);
                    menu.AddItem(new GUIContent(string.Format("{0}/{1}", theme.Remove(0, themePath.Length + 1), Path.GetFileNameWithoutExtension(path))),
                    false, addkHandler,
                    new SlideCreationParams()
                    {
                        Path = path
                    });
                }
            }


            
            menu.AddSeparator("");
            menu.AddItem(new GUIContent("Empty Slide"), false, addkHandler, null);
            menu.ShowAsContext();
        }

        private void RemoveItem(ReorderableList list)
        {
            if (EditorUtility.DisplayDialog("Warning!",
                "Are you sure to delete selected slide?", "Yes", "No"))
            {
                var controller = slides.GetArrayElementAtIndex(list.index).objectReferenceValue as AbstractSlideController;
                if (controller)
                {
                    if (EditorUtility.DisplayDialog("Warning!",
                    "Remove GameObject in scene?", "Yes", "No"))
                    {
                        DestroyImmediate(controller.gameObject);
                    }
                }
                slides.GetArrayElementAtIndex(list.index).objectReferenceValue = null;
                ReorderableList.defaultBehaviours.DoRemoveButton(list);
                Repaint();
            }
            
        }

        private void SelectItem(ReorderableList list)
        {
            var slideController = list.serializedProperty.GetArrayElementAtIndex(list.index).objectReferenceValue as AbstractSlideController;
            if (slideController)
            {
                EditorGUIUtility.PingObject(slideController.gameObject);
                (target as PlayerController).PreviewAtSlide(list.index);
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(cameraRig, new GUIContent("Presentation Camera"));
            EditorGUILayout.PropertyField(autoPlay);
            reorderableSlides.DoLayoutList();
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Changed Slides");
                serializedObject.ApplyModifiedProperties();
            }
        }

        private struct SlideCreationParams
        {
            public string Path; // Path to template prefab
        }

        private void addkHandler(object data)
        {
            
            var index = slides.arraySize;
            slides.arraySize++;
            reorderableSlides.index = index;

            if (data != null)
            {
                var p = (SlideCreationParams)data;
                var templatePrefab = AssetDatabase.LoadAssetAtPath(p.Path, typeof(GameObject)) as GameObject;
                slides.GetArrayElementAtIndex(index).objectReferenceValue = SlideHelper.CreateNewSlide(index, templatePrefab, true);
            }
            else
            {
                slides.GetArrayElementAtIndex(index).objectReferenceValue = null;
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
