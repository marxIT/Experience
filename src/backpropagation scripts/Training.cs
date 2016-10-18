
using UnityEngine;
using System.Collections;

public class Training : MonoBehaviour {
	public bool trained = false;
	int NumInput = 5;
	int NumHidden = 350;
	int NumOutput = 1;
	double[] feedin1 = new double[]{150,30,60,4,138};
	double[] ActualOutput;
	BackPropagation backpro;
	
	void Start () {
		backpro = new BackPropagation (NumInput, NumHidden, NumOutput);
		if (trained == false) {

			Train ();

		}
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	
	//start training given the ff inputs and corresponding target outputs. 
	void Train(){
		double[][] InputValues =new double[18][]{new double[]{150,30,60,4,138},	new double[]{220,58,43,2,208},new double[]{341,61,27,9,336},

			new double[]{168,28,75,2,152},	new double[]{258,49,56,4,2460},new double[]{298,78,13,6,280},

			new double[]{146,36,70,3,143},new double[]{276,62,24,3,261},new double[]{326,57,22,8,316},

			new double[]{136,39,64,2,121}, new double[]{242,54,65,4,232},new double[]{274,88,31,5,258},

			new double[]{169,27,24,3,152},new double[]{256,41,53,2,24},new double[]{331,58,35,2,318},

			new double[]{157,37,66,4,138},	new double[]{278,31,47,4,257},	new double[]{381,74,29,6,352}};


		double[][] TargetOutput = new double[18][]{new double[]{0.1},new double[]{0.3},	new double[]{0.5},

			new double[]{0.1},	new double[]{0.3},new double[]{0.5},

			new double[]{0.1},new double[]{0.3},new double[]{0.5},

			new double[]{0.1},new double[]{0.3},new double[]{0.5},

			new double[]{0.1},new double[]{0.3},new double[]{0.5},

			new double[]{0.1},	new double[]{0.3},	new double[]{0.5}};

	
		
		int NumWeights = (NumInput * NumHidden) + (NumHidden * NumOutput) + NumHidden + NumOutput;

		
		double LearningRate = 0.02;
		int MaxIterations = 1200; 
		double error = double.MaxValue;
		double mingloberror = 0.00000000000000000000000000000001;
		double err = double.MaxValue;
		
		

		
		backpro.InitializeWeight (NumWeights);
		//	backpro.GetWeights();
		int i = 0;
		int Iteration = 0;
		double sum = 0.0;
		
		
		while (err > mingloberror){ // (err > mingloberror)(Iteration < MaxIterations)
			double globalerror;
			
			//Debug.Log("iteration number " + Iteration);
			//Debug.Log("pattern number " + i);
			double[] IntputVal = InputValues[i];
			double[] TargetOut = TargetOutput[i];
			
			ActualOutput = backpro.FeedForward(IntputVal);
			backpro.ComputeError(TargetOut);
			backpro.UpdateWeights(LearningRate);
			//backpro.GetWeights();
			//Debug.Log("the new weights are");
			//backpro.GetWeights();
			i++;
			Iteration++;
			for(int j =0; j < TargetOut.Length; j++){
				double p = (TargetOut [j] - ActualOutput [j]);
				double o = (TargetOut [j] - ActualOutput [j]);
				double n = p * o;
				error = n;
				//Debug.Log("target out is " + TargetOut[j] + " Actual out is " + ActualOutput[j]);
				
				System.Math.Abs (error);
				sum += error;
				
				//	Debug.Log("the global error is " + sum);
				if(i == 3){
					err = sum * 0.5;
					i = 0;
					sum = 0.0;
					
					Debug.Log("the global error for " + Iteration/3 + " iteration is " + err);
					//Debug.Log ("The iteration is " + Iteration);
					
				}
			}
			
			//Iteration++;
			
			
		}//while
		

		trained = true;
		backpro.GetWeights ();
		ActualOutput = backpro.FeedForward(feedin1);

		Debug.Log ("Final Output is " + ActualOutput[0]);
//
//		ActualOutput = backpro.FeedForward(feedin2);
//		
//		Debug.Log (ActualOutput[0]);
//
//		ActualOutput = backpro.FeedForward(feedin3);
//		
//		Debug.Log (ActualOutput[0]);



	

		
	}//train

}
