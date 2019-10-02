using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace QNT.ExtensionUtil
{
    public static class UIExtensionUtils
    {
        public static bool LayerInLayerMask(int layer, LayerMask layerMask)
        {
            return ((1 << layer) & layerMask) != 0;
        }

        public static LayerMask AddLayerMask(this LayerMask mask, string layer)
        {
            mask = mask | (1 << LayerMask.NameToLayer(layer));
            return mask;
        }

        public static LayerMask RemoveLayerMask(this LayerMask mask, string layer)
        {
            mask = mask & ~(1 << LayerMask.NameToLayer(layer));
            return mask;
        }

        public static void SetSafeEnable(this SpriteRenderer sp, bool value)
        {
            if (sp.enabled != value)
            {
                sp.enabled = value;
            }
        }

        public static void SetSafeActive(this GameObject obj, bool value)
        {
            if (obj == null) return;

            if (obj.activeSelf != value)
            {
                obj.SetActive(value);
            }
        }

        public static bool IsPointerOverUiObject(Vector2 screenPosition)
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current) {position = Input.mousePosition};
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].gameObject.GetComponent<Image>())
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}