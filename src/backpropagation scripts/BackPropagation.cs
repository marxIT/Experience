using UnityEngine;
using System.Collections;

public class BackPropagation : MonoBehaviour {

	
	public int NumInput; 
	public int NumHidden;
	public int NumOutputs;
	
	private double[] Inputs;
	private double [,] InputToHiddenWeights;
	
	private double[] BiasesToHiddenNode;
	private double[] HiddenNodeNetInput;
	private double[] HiddenNodeOutput;
	private double[,] HiddenToOutputWeights;
	
	private double[] BiasesToOutputNode;
	private	double[] OutputNodeNetInput;
	private double[] Output;
	
	private double[] OutputSignalError;
	private	double[] HiddenSignalError;
	
	private double[,]InputToHiddenPrevWeights;
	private double[] HiddenNodePrevBias;
	private double[,] HiddenToOutputPrevWeights;
	private double[] OutputNodePrevBias;
	
	//create instance of the class
	public BackPropagation(int NumInput, int NumHidden, int NumOutputs){
		
		this.NumInput = NumInput;
		this.NumHidden = NumHidden;
		this.NumOutputs = NumOutputs;
		
		Inputs = new double[NumInput];
		InputToHiddenWeights = new double[NumInput, NumHidden];
		
		BiasesToHiddenNode = new double[NumHidden];
		HiddenNodeNetInput = new double[NumHidden];
		HiddenNodeOutput = new double[NumHidden];
		HiddenToOutputWeights = new double[NumHidden, NumOutputs];
		
		BiasesToOutputNode = new double[NumOutputs];
		OutputNodeNetInput = new double[NumOutputs];
		Output = new double[NumOutputs];
		
		HiddenSignalError = new double[NumHidden];
		OutputSignalError = new double[NumOutputs];
		
		
	}//backproRev constructor
	
	////initialize weights
	public void InitializeWeight(int NumWeights){
		//random weights
		float x;
		double y;
		double z;
		
		double[] Weights = new double[NumWeights];
		
		for (int p = 0; p < Weights.Length; p++) {
			x = UnityEngine.Random.Range(-0.5f,0.5f);
			y = System.Convert.ToDouble(x);
			z = System.Math.Round(x * 10000) / 10000;
			Weights[p] = z;
		}
		
		//initialize weights
		int k = 0;
		for (int i = 0; i < NumInput; ++i) {
			for (int j = 0; j < NumHidden; ++j){
				InputToHiddenWeights [i, j] = Weights [k++];
				
			}
		}
		
		for (int i = 0; i < NumHidden; ++i)
			BiasesToHiddenNode [i] = Weights [k++];
		
		for (int i = 0; i < NumHidden; ++i) {
			for (int j = 0; j < NumOutputs; ++j){
				HiddenToOutputWeights [i, j] = Weights [k++];
			}
		}
		for (int i = 0; i < NumOutputs; ++i)
			BiasesToOutputNode [i] = Weights [k++];
		
		/*	for(int a = 0; a < Weights.Length; ++a){
			Debug.Log(Weights[a]);
		}*/
		
	}//setWeight



	////initialize Final weights
	public void InitializeFinalWeight(double[] Weights){

					
		//initialize weights
		int k = 0;
		for (int i = 0; i < NumInput; ++i) {
			for (int j = 0; j < NumHidden; ++j){
				InputToHiddenWeights [i, j] = Weights [k++];
				
			}
		}
		
		for (int i = 0; i < NumHidden; ++i)
			BiasesToHiddenNode [i] = Weights [k++];
		
		for (int i = 0; i < NumHidden; ++i) {
			for (int j = 0; j < NumOutputs; ++j){
				HiddenToOutputWeights [i, j] = Weights [k++];
			}
		}
		for (int i = 0; i < NumOutputs; ++i)
			BiasesToOutputNode [i] = Weights [k++];

		
	}//set Final Weights
	


	
	//activationfunction
	private static double SigmoidFunction(double NetInput){
		return (2.0/(1 + System.Math.Exp(-NetInput))) - 1;
	}
	
	
	
	
	//feed forward
	public double[] FeedForward(double[] InputValues){
		//initialize netInput to 0
		for (int i = 0; i < NumHidden; ++i)
			HiddenNodeNetInput [i] = 0.0;
		for (int i = 0; i < NumOutputs; ++i)
			OutputNodeNetInput [i] = 0.0;
		
		//give input node the input signals
		for (int i = 0; i < InputValues.Length; i++)
			this.Inputs [i] = InputValues[i];
		
		//calculate hidden node net input
		for (int i = 0; i < NumHidden; ++i)
			for (int j = 0; j < NumInput; ++j)
				HiddenNodeNetInput [i] += this.Inputs [j] * InputToHiddenWeights [j, i];
		for (int i = 0; i < NumHidden; ++i)
			HiddenNodeNetInput [i] += BiasesToHiddenNode[i];
		
		// apply activation function to hidden node
		for (int i = 0; i < NumHidden; ++i)
			HiddenNodeOutput [i] = SigmoidFunction (HiddenNodeNetInput [i]);
		
		//calculat outputnode net input
		for (int i = 0; i < NumOutputs; ++i)
			for (int j = 0; j < NumHidden; ++j)
				OutputNodeNetInput [i] += HiddenNodeOutput [j] * HiddenToOutputWeights [j, i];
		
		for (int i = 0; i < NumOutputs; ++i)
			OutputNodeNetInput [i] += BiasesToOutputNode [i];
		
		//calculate output
		for (int i = 0; i < NumOutputs; ++i)
			this.Output [i] = SigmoidFunction (OutputNodeNetInput[i]);
		
		//store and return the outputs
		double[] result = new double[NumOutputs];
		this.Output.CopyTo (result, 0);
		return result;
		
	}//feedforward
	
	//backpropagate of error
	public void ComputeError(double[] TargetOutput){
		//compute error in output nodes
		for (int i = 0; i < OutputSignalError.Length; ++i) {
			double g = TargetOutput [i] - Output [i];
			double h = (1 + Output [i]) * (1 - Output [i]);
			double j = 0.5 * h;
			OutputSignalError [i] = g * j;
			
			//	Debug.Log(OutputSignalError[i]);
			//Debug.Log(TargetOutput[i]);
			//	Debug.Log(Output[i]);
		}
		//sum delta input of hidden nodes
		for (int i = 0; i < HiddenSignalError.Length; ++i) {
			double sum = 0.0;
			//Debug.Log("sum is : " +sum);
			for (int j = 0; j <  NumOutputs; ++j) {
				sum += OutputSignalError [j] * HiddenToOutputWeights [i, j];
				
				double r = sum;
				double t = (1 + HiddenNodeOutput[i])*(1 - HiddenNodeOutput[i]);
				double y = 0.5 * r;
				HiddenSignalError[i] = r * y;
				//Debug.Log(HiddenSignalError[i]);
			}
		}
	}//computeError
	
	//update weights and biases
	public void UpdateWeights(double LearningRate){
		// calculate hidden to output weight correction term and update weight
		for (int i = 0; i < NumHidden; ++i) {
			for(int j = 0; j < NumOutputs; ++j){
				double DeltaWeight = LearningRate * OutputSignalError[j] * HiddenNodeOutput[i];
				//	Debug.Log("Learning rate is " + LearningRate);
				//	Debug.Log("Outputsignal error is " + OutputSignalError[j]);
				//	Debug.Log("HiddenNodeOutput is "+ HiddenNodeOutput[i]);
				//	Debug.Log(DeltaWeight);
				HiddenToOutputWeights[i,j] += DeltaWeight;
			}
		}
		
		//calculate output bias correction term and update weights
		for (int i = 0; i < BiasesToOutputNode.Length; ++i) {
			double DeltaBias = LearningRate* OutputSignalError[i];
			BiasesToOutputNode[i] += DeltaBias;
		}
		
		//calculate input to hidden weight correction term and update
		for(int i = 0; i < NumInput; ++i) {
			for(int j = 0; j < NumHidden; ++j){
				double DeltaWeight = LearningRate * HiddenSignalError[j] * Inputs[i];
				InputToHiddenWeights[i,j] += DeltaWeight;
				
			}
		}
		
		//calculate hidden bias correction term and update weights
		for (int i = 0; i < BiasesToHiddenNode.Length; ++i) {
			double DeltaBias = LearningRate * HiddenSignalError[i];
			BiasesToHiddenNode[i] += DeltaBias;
		}
		
	}//updateWeights
	
	
	public void GetWeights(){
		int NumWeights =(NumInput * NumHidden) + (NumHidden * NumOutputs) + NumHidden + NumOutputs;
		double[] results = new double[NumWeights];
		int k = 0;
		for (int i = 0; i < NumInput; ++i) 
			for (int j = 0; j < NumHidden; ++j)
				results [k++] = InputToHiddenWeights [i, j];
		
		for (int i = 0; i < NumHidden; ++i)
			results [k++] = BiasesToHiddenNode [i];
		
		
		for(int i = 0; i < NumHidden; ++i)
			for(int j = 0; j <NumOutputs; ++j)
				results [k++] = HiddenToOutputWeights [i,j] ;
		for (int i = 0; i <NumOutputs; ++i)
			results [k++] =	BiasesToOutputNode [i] ;

		//save weights.
		for (int i = 0; i < results.Length; i++) {
			PlayerPrefs.SetString("FinalWeights" + i, results[i].ToString("R"));
		}
//		for (int a = 0; a < results.Length; ++a) {
//			Debug.Log (results [a]);
//		}


		
		
	}//getweights
	
	public void InitNewWeights(double[] NewWeights){
		double[] Weights = NewWeights;
		
		int k = 0;
		for(int i = 0; i < NumInput; ++i)
			for(int j = 0; j < NumHidden; ++j)
				InputToHiddenWeights[i,j] = Weights[k++];
		
		
		for (int i = 0; i < NumHidden; ++i)
			BiasesToHiddenNode [i] = Weights [k++];
		
		for (int i = 0; i < NumHidden; ++i) 
			for (int j = 0; j < NumOutputs; ++j)
				HiddenToOutputWeights [i, j] = Weights [k++];
		
		for (int i = 0; i < NumOutputs; ++i)
			BiasesToOutputNode [i] = Weights [k++];
	}
	
}//backpro class