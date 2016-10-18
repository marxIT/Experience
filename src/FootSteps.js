var Source1 : AudioSource;

function Start () {

}

function Update () {
if(Input.GetKeyDown(KeyCode.W || KeyCode.S || KeyCode.A || KeyCode.D)){
		Source1.Play();
	} else if (Input.GetKeyUp(KeyCode.W || KeyCode.S || KeyCode.A || KeyCode.D)) {
		Source1.Stop();
	} else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.A)){
		Source1.Play();
	} else if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D)){
		Source1.Play();
	} else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A)){
		Source1.Play();
	} else if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D)){
		Source1.Play();
	} else if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A)){
		Source1.Stop();
	} else if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.D)){
		Source1.Stop();
	} else if (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.A)){
		Source1.Stop();
	} else if (Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D)){
		Source1.Stop();
	} 
}