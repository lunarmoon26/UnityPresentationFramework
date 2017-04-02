using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UnityPresentationFramework.Helpers
{
    public static class SlideHelper
    {
        /// <summary>
        /// Create a new slide from prefab
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prefab"></param>
        /// <param name="focus"></param>
        /// <returns></returns>
        static public AbstractSlideController CreateNewSlide(int id, GameObject prefab, bool focusOn = false)
        {
            GameObject slide = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            slide.name = "New Slide " + id;
            slide.transform.SetAsLastSibling();
            // Register new gameobject in the undo system
            Undo.RegisterCreatedObjectUndo(slide, "Created New Slide");
            if(focusOn) Selection.activeObject = slide;

            return slide.GetComponent<AbstractSlideController>();
        }
    }
}

