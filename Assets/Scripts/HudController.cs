using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using System.Collections;

public class HudController : MonoBehaviour
{
	public float newWaveDisplayDuration = 2f;

	[SerializeField] private TextMeshProUGUI winText;
	[SerializeField] private TextMeshProUGUI loseText;
	[SerializeField] private TextMeshProUGUI pauseText;
	[SerializeField] private TextMeshProUGUI waveCompleteText;
	[SerializeField] private TextMeshProUGUI waveCounterText;

	public static Action<bool> OnToggleWinText;
	public static Action<bool> OnToggleLoseText;
	public static Action<bool> OnTogglePauseText;
	public static Action<bool> OnToggleWaveCompleteText;
	public static Action<bool, int> OnToggleNewWaveText;

	public void OnEnable()
	{
		OnToggleWinText += ToggleWinText;
		OnToggleLoseText += ToggleLoseText;
		OnTogglePauseText += TogglePauseText;
		OnToggleWaveCompleteText += ToggleWaveCompleteText;
		OnToggleNewWaveText += ToggleNewWaveText;
	}

	private void OnDisable()
	{
		OnToggleWinText -= ToggleWinText;
		OnToggleLoseText -= ToggleLoseText;
		OnTogglePauseText -= TogglePauseText;
		OnToggleWaveCompleteText -= ToggleWaveCompleteText;
		OnToggleNewWaveText -= ToggleNewWaveText;
	}

	private void ToggleWinText(bool setEnabled)
	{
		winText.gameObject.SetActive(setEnabled);
	}

	private void ToggleLoseText(bool setEnabled)
	{
		loseText.gameObject.SetActive(setEnabled);
	}

	private void TogglePauseText(bool setEnabled)
	{
		pauseText.gameObject.SetActive(setEnabled);
	}

	private void ToggleWaveCompleteText(bool setEnabled)
	{
		waveCompleteText.gameObject.SetActive(setEnabled);
	}

	private void ToggleNewWaveText(bool setEnabled, int waveIndex)
	{
		waveCounterText.gameObject.SetActive(setEnabled);
		waveCounterText.gameObject.GetComponentsInChildren<TextMeshProUGUI>()[1].text =
			(waveIndex + 1).ToString();

		StartCoroutine(HideNewWaveText());
	}

	private IEnumerator HideNewWaveText()
	{
		yield return new WaitForSeconds(newWaveDisplayDuration);
		waveCounterText.gameObject.SetActive(false);
	}
}

