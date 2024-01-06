using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class UnlitForestInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string _requiredItem;

    [SerializeField] private GameObject _blackOverlay;
    [SerializeField] private GameObject _boxCutterItem;

    private Animator _overlayAnimator;
    private void Awake()
    {
        _overlayAnimator = _blackOverlay.GetComponent<Animator>();
    }
    public void TryExecuteInteraction()
    {
        if (InventoryManager.instance.TryToFindAndUseItem(_requiredItem))
        {
            StartCoroutine(PlayCameraFlashSequenceCoroutine());
        }
    }
    private IEnumerator PlayCameraFlashSequenceCoroutine()
    {
        _overlayAnimator.Play("UnlitAreaBlackOverlay");
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.ItemUsedCamera);
        SoundsManager.instance.PlaySound(SoundsManager.Sounds.GhostImpactUnlitForest);
        yield return new WaitForSeconds(1f);
        _boxCutterItem.SetActive(true);

        Destroy(gameObject);
    }
}
