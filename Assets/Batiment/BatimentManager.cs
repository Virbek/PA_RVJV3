using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.UIElements;

namespace Batiment
{
    public enum PlacementMode
    {
        Fixed,
        Valid,
        Invalid
    }

    public class BatimentManager : MonoBehaviour
    {
        public Material validPlacementMaterial;
        public Material invalidPlacementMaterial;

        public MeshRenderer[] meshComponents;
        private Dictionary<MeshRenderer, List<Material>> _initialMaterials;

        [HideInInspector] public bool hasValidPlacement;
        [HideInInspector] public bool isFixed;

        [SerializeField] private GameObject unit;
        private int _nObstacles;

        private void Awake()
        {
            hasValidPlacement = true;
            isFixed = true;
            _nObstacles = 0;

            _InitializeMaterials();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isFixed) return;

            // ignore ground objects
            if (_IsGround(other.gameObject)) return;

            _nObstacles++;
            SetPlacementMode(PlacementMode.Invalid);
        }

        private void OnTriggerExit(Collider other)
        {
            if (isFixed) return;

            // ignore ground objects
            if (_IsGround(other.gameObject)) return;

            _nObstacles--;
            if (_nObstacles == 0)
                SetPlacementMode(PlacementMode.Valid);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _InitializeMaterials();
        }
#endif

        public void SetPlacementMode(PlacementMode mode)
        {
            if (mode == PlacementMode.Fixed)
            {
                isFixed = true;
                hasValidPlacement = true;
            }
            else if (mode == PlacementMode.Valid)
            {
                hasValidPlacement = true;
            }
            else
            {
                hasValidPlacement = false;
            }
            SetMaterial(mode);
        }

        private void SetMaterial(PlacementMode mode)
        {
            if (mode == PlacementMode.Fixed)
            {
                foreach (MeshRenderer r in meshComponents)
                    r.sharedMaterials = _initialMaterials[r].ToArray();
                if (gameObject.CompareTag("maison"))
                {
                    gameObject.GetComponent<InvokeUnit>().enabled = true;
                }
            }
            else
            {
                Material matToApply = mode == PlacementMode.Valid
                    ? validPlacementMaterial : invalidPlacementMaterial;

                Material[] m; int nMaterials;
                foreach (MeshRenderer r in meshComponents)
                {
                    nMaterials = _initialMaterials[r].Count;
                    m = new Material[nMaterials];
                    for (int i = 0; i < nMaterials; i++)
                        m[i] = matToApply;
                    r.sharedMaterials = m;
                }
            }
        }

        private void _InitializeMaterials()
        {
            if (_initialMaterials == null)
                _initialMaterials = new Dictionary<MeshRenderer, List<Material>>();
            if (_initialMaterials.Count > 0)
            {
                foreach (var l in _initialMaterials) l.Value.Clear();
                _initialMaterials.Clear();
            }

            foreach (MeshRenderer r in meshComponents)
            {
                _initialMaterials[r] = new List<Material>(r.sharedMaterials);
            }
        }

        private bool _IsGround(GameObject o)
        {
            return ((1 << o.layer) & PlacerBatiment.Instance.groundLayerMask.value) != 0;
        }

    }
}