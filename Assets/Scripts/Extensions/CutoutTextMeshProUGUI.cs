using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Extensions
{
    public class CutoutTextMeshProUGUI : TextMeshProUGUI
    {
        public override Material materialForRendering
        {
            get
            {
                var material = new Material(base.materialForRendering);
                material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
                return material;
            }
        }
    }
}