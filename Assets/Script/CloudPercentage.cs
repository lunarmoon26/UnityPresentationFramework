using UnityEngine;
using System.Collections;

public class CloudPercentage : MonoBehaviour {

	[Range(0f, 1f)] [SerializeField] private float m_Percentage = 0.5f;

	private ParticleSystem m_InnerParticle;
	private ParticleSystem m_OuterParticle;

	private const float k_InnerEmissionRateMin = 0f;
	private const float k_InnerParticleSpeedMin = 0.1f;

	// Use this for initialization
	void Start () {
		m_InnerParticle = gameObject.transform.GetChild (0).GetComponent<ParticleSystem> ();
		m_OuterParticle = gameObject.transform.GetChild (1).GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (m_InnerParticle && m_OuterParticle) {
			m_InnerParticle.startLifetime = m_OuterParticle.startLifetime * Mathf.Sqrt (m_Percentage);
			m_InnerParticle.startSpeed = m_OuterParticle.startSpeed * Mathf.Sqrt ((1 - k_InnerParticleSpeedMin) * m_Percentage + k_InnerParticleSpeedMin);

			var emission = m_InnerParticle.emission;
			var emissionRate = emission.rate;
			emissionRate.constant = m_OuterParticle.emission.rate.constant * Mathf.Sqrt ((1 - k_InnerEmissionRateMin) * m_Percentage + k_InnerEmissionRateMin);
			emission.rate = emissionRate;
		}
	}
}
