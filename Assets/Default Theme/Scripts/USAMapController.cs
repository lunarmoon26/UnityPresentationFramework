using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class USAMapController : MonoBehaviour {

	[SerializeField] private string m_StatesEnabled = "";
	private Dictionary<string, int> m_StateDictionary;

	// Use this for initialization
	void Awake () {
		m_StateDictionary = new Dictionary<string, int> () {
			{"AK",	0 },
			{"AL",	1 },
			{"AR",	2 },
			{"AZ",	3 },
			{"CA",	4 },
			{"CO",	5 },
			{"CT",	6 },
			{"DE",	7 },
			{"FL",	8 },
			{"GA",	9 },
			{"HI",	10},
			{"IA",	11},
			{"ID",	12},
			{"IL",	13},
			{"IN",	14},
			{"KS",	15},
			{"KY",	16},
			{"LA",	17},
			{"MA",	18},
			{"MD",	19},
			{"ME",	20},
			{"MI",	21},
			{"MN",	22},
			{"MO",	23},
			{"MS",	24},
			{"MT",	25},
			{"NC",	26},
			{"ND",	27},
			{"NE",	28},
			{"NH",	29},
			{"NJ",	30},
			{"NM",	31},
			{"NV",	32},
			{"NY",	33},
			{"OH",	34},
			{"OK",	35},
			{"OR",	36},
			{"PA",	37},
			{"RI",	38},
			{"SC",	39},
			{"SD",	40},
			{"TN",	41},
			{"TX",	42},
			{"UT",	43},
			{"VA",	44},
			{"VT",	45},
			{"WA",	46},
			{"WI",	47},
			{"WV",	48},
			{"WY",	49},
			{"DC",	50}
		};
		for( int i = 0; i < transform.childCount; ++i )
		{
			transform.GetChild(i).gameObject.SetActive(false);
		}


	}

	void Start(){
		string[] enabledStatesArray = m_StatesEnabled.Split (',');
		for (int i = 0; i < enabledStatesArray.Length; i++) {
			ShowState (enabledStatesArray[i], true);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ShowState(string state, bool show){

		if (!string.IsNullOrEmpty (state)) {
		
			int childIndex;
			if (m_StateDictionary.TryGetValue(state, out childIndex))
			{
				transform.GetChild(childIndex).gameObject.SetActive(show);
			} 
		}
	}
}
