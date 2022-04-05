using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gates
{
    public class GateView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private MeshRenderer _meshRenderer;

        [SerializeField] private Material _trueMaterial, _falseMaterial;

        public void InitView(TypeGate typeGate, int count)
        {
            switch (typeGate)
            {
                case TypeGate.Addition:
                    _meshRenderer.material = _trueMaterial;
                    _text.SetText("+" + count);
                    
                    break;
                
                case TypeGate.Division:
                    _meshRenderer.material = _falseMaterial;
                    _text.SetText("/" + count);
                    break;
                
                case TypeGate.Multiplication:
                    _meshRenderer.material = _trueMaterial;
                    _text.SetText("*" + count);
                    break;
                
                case TypeGate.Subtraction:
                    _meshRenderer.material = _falseMaterial;
                    _text.SetText("-" + count);
                    break;
            }
        }
    }
}
