using UnityEngine;
using System.Collections;

public class ForwardPass : MonoBehaviour {

	BackPropagation bpro;

	int NumInput = 5;
	int NumHidden = 350;
	int NumOutput = 1;
	double[] ActualOutput;
	throwinputs tint;
	public double[] feedin1;
//	new double[]{150,30,60,4,138};
	public double[] weights;

	bool pass;



	//creates an instance of the backpropagation with corresponding number of nodes and weights
	void Start () {
		bpro = new BackPropagation (NumInput, NumHidden, NumOutput);
		pass = false;
		weights = new double[2451];
		tint = GameObject.Find("playerInputs").GetComponent<throwinputs>();

		Debug.Log ("tssss");
	}
	
	// Update is called once per frame
	void Update () {

		// stops the engine from calling the method more than once
		if (pass == false) {
			if(tint.passed == true){
			FeedForward();
			pass = true;
			}
		}

	
	}


	void FeedForward(){

		//grabs the saved weights from training and stores it in the array
		for (int i = 0; i < 2451; i++) {
			weights[i] = double.Parse( PlayerPrefs.GetString("FinalWeights" + i));
			
		}
		//initialize the networks weights with the weights array
		bpro.InitializeFinalWeight (weights);
		//passes the users input to the network and gets the output
		ActualOutput = bpro.FeedForward (feedin1);

		Debug.Log (" the output is " + ActualOutput [0]);

	}
}
