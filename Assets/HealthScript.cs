using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

	// Use Singleton pattern to keep a single instance of HealthScript
	// All objects in the game will access this instance for health management
	public static HealthScript _Instance;

	public static HealthScript Instance {
		get{
			if (_Instance == null)
				_Instance = GameObject.FindObjectOfType<HealthScript> ();
			return _Instance;
		}
	}

	// Ace health and setter/getter
	// When health changes, update Healthbars
    private int aceHealth;
	public int AceHealth
	{
		get{ return aceHealth;}
		set{aceHealth = value;
			HandleHealth();}
	}
	// Jack health and setter/getter
	// When health changes, update Healthbars
	private int jackHealth;
	public int JackHealth{
		get{ return jackHealth;}
		set{ jackHealth = value;
			HandleHealth();}
	}
	// King health and setter/getter
	// When health changes, update Healthbars
	private int kingHealth;
	public int KingHealth{
		get{ return kingHealth;}
		set{kingHealth = value;
			HandleHealth();}
	}
	// Queen health and setter/getter
	// When health changes, update Healthbars
	private int queenHealth;
	public int QueenHealth{
		get{ return queenHealth;}
		set{queenHealth = value;
			HandleHealth();}
	}

	// Variable for characters' max health -- Initial values are set in Unity
    public int aceMaxHealth;
	public int jackMaxHealth;
	public int kingMaxHealth;
    public int queenMaxHealth;

	// Variable for characters' healthbar images. Used to show amount of health
	public Image aceHealthImage;
	public Image jackHealthImage;
	public Image kingHealthImage;
    public Image queenHealthImage;

	// Cooldowns for characters taking damage and Queen's special move -- Initial values are set in Unity
	public float aceHealthCooldown;
	public float jackHealthCooldown;
	public float kingHealthCooldown;
	public float queenHealthCooldown;
	public float queenSpecialCooldown;

	// Booleans for checking if a character is on cooldown (and thus can't take damage/use a special move)
	public bool aceOnCooldown;
	public bool jackOnCooldown;
	public bool kingOnCooldown;
	public bool queenOnCooldown;
	public bool queenOnSpecialCooldown;

	// Boolean for checking if a character is alive. Used for displaying victory canvas
	public bool aceAlive;
	public bool jackAlive;
	public bool kingAlive;
	public bool queenAlive;

	// Boolean for checking that the game has ended
	private bool gameOver;

	// Use this for initialization
	void Start () {

		// Set health to max
		aceHealth = aceMaxHealth;
        jackHealth = jackMaxHealth;
        queenHealth = queenMaxHealth;
        kingHealth = kingMaxHealth;

		// Set cooldowns to false and characters to alive
		aceOnCooldown = jackOnCooldown = kingOnCooldown = queenOnCooldown = queenOnSpecialCooldown = gameOver = false;
		aceAlive = jackAlive = kingAlive = queenAlive = true;
	}
	
	// Update is called once per frame -- Unused
	void Update () {}

	private void HandleHealth(){

		// Image's fillAmount is set depending on percentage of health
		aceHealthImage.fillAmount = (1.0f * aceHealth / aceMaxHealth);
		jackHealthImage.fillAmount = (1.0f * jackHealth / jackMaxHealth);
		kingHealthImage.fillAmount = (1.0f * kingHealth / kingMaxHealth);
		queenHealthImage.fillAmount = (1.0f * queenHealth / queenMaxHealth);

		// Color of health bar is set based on percentage of health (Green->Yellow->Red)
		if (aceHealth > aceMaxHealth / 2)
			aceHealthImage.color = new Color32 ((byte)(255.0f * (aceMaxHealth - aceHealth) /  (float) aceMaxHealth ),255,0,255);
		else
			aceHealthImage.color = new Color32 (255, (byte)(255.0f * aceHealth / aceMaxHealth),0,255);
	
		if (jackHealth > jackMaxHealth / 2)
			jackHealthImage.color = new Color32 ((byte)(255.0f * (jackMaxHealth - jackHealth) /  (float) jackMaxHealth ),255,0,255);
		else
			jackHealthImage.color = new Color32 (255, (byte)(255.0f * jackHealth / jackMaxHealth),0,255);

		if (kingHealth > kingMaxHealth / 2)
			kingHealthImage.color = new Color32 ((byte)(255.0f * (kingMaxHealth - kingHealth) /  (float) kingMaxHealth ),255,0,255);
		else
			kingHealthImage.color = new Color32 (255, (byte)(255.0f * kingHealth / kingMaxHealth),0,255);

		if (queenHealth > queenMaxHealth / 2)
			queenHealthImage.color = new Color32 ((byte)(255.0f * (queenMaxHealth - queenHealth) /  (float) queenMaxHealth ),255,0,255);
		else
			queenHealthImage.color = new Color32 (255, (byte)(255.0f * queenHealth / queenMaxHealth),0,255);

		// Check if either team has been defeated (team members dead). If so, show victory screen for that team
		if (!gameOver && !queenAlive && !kingAlive) {
			gameOver = true;
			GameObject.Find("VictorySpadeCanvas").GetComponent<AudioSource>().Play ();
			GameObject.Find ("VictorySpadeCanvas").GetComponent<CanvasGroup> ().alpha = 1;
		} else if (!gameOver && !jackAlive && !aceAlive) {
			gameOver = true;
			GameObject.Find("VictoryHeartCanvas").GetComponent<AudioSource>().Play();
			GameObject.Find ("VictoryHeartCanvas").GetComponent<CanvasGroup> ().alpha = 1;
		}
	}

	// Do damage to Ace
	public void hitAce(int damage){
		// Check if Ace is on cooldown
		if (!aceOnCooldown) {
			// If not, deincrement health by damage amount, set cooldown, and play hit animation
			AceHealth -= damage;
			aceDamageCooldown();
			GameObject.Find ("AceModel").GetComponent<Animation> ().Play("AceHit");
			GameObject.Find ("AceModel").GetComponent<ParticleSystem> ().Play();
			// GameObject.Find ("AceModel").GetComponent<Animation> ().PlayQueued("AceIdle");
		}
		// If health is below 0, set it to 0, set Alive flag to false, and play Death animation
		if (aceAlive && aceHealth <= 0) {
			aceAlive = false;
			aceHealth = 0;
			GameObject.Find ("AceModel").GetComponent<Animation> ().Play("AceDie");
		}
		Debug.Log ("<<< AceHealth: " + aceHealth);
	}
	
	// Do damage to Jack
	public void hitJack(int damage){
		// Check if Jack is on cooldown
		if (!jackOnCooldown) {
			// If not, deincrement health by damage amount, set cooldown, and play hit animation
			JackHealth -= damage;
			jackDamageCooldown();			
			GameObject.Find ("JackModel").GetComponent<Animation> ().Play("JackHit");
			GameObject.Find ("JackModel").GetComponent<ParticleSystem> ().Play();
			// GameObject.Find ("JackModel").GetComponent<Animation> ().PlayQueued("JackIdle");
		}
		// If health is below 0, set it to 0, set Alive flag to false, and play Death animation
		if (jackAlive && jackHealth <= 0) {
			jackAlive = false;
			jackHealth = 0;
			GameObject.Find ("JackModel").GetComponent<Animation> ().Play("JackDie");
		}
		Debug.Log ("<<< JackHealth: " + jackHealth);
	}
	
	// Do damage to King
	public void hitKing(int damage){
		// Check if King is on cooldown
		if (!kingOnCooldown) {
			// If not, deincrement health by damage amount, set cooldown, and play dodge animation
			KingHealth -= damage;
			kingDamageCooldown();
			GameObject.Find ("KingModel").GetComponent<Animation> ().Play("KingAttack2");
			GameObject.Find ("KingModel").GetComponent<ParticleSystem> ().Play();
		}
		// If health is below 0, set it to 0, set Alive flag to false, and play Death animation
		if (kingAlive && kingHealth <= 0) {
			kingAlive = false;
			kingHealth = 0;
		}
		Debug.Log ("<<< KingHealth: " + kingHealth);
	}
	
	// Do damage to Queen
	public void hitQueen(int damage){
		// Check if King is on cooldown
		if (!queenOnCooldown) {
			// If not, deincrement health by damage amount, set cooldown, and play dodge animation
			QueenHealth -= damage;
			queenDamageCooldown();
			GameObject.Find ("QueenModel").GetComponent<Animation> ().Play("QueenHit");
			GameObject.Find ("QueenModel").GetComponent<ParticleSystem> ().Play();
			// GameObject.Find ("QueenModel").GetComponent<Animation> ().PlayQueued("QueenIdle");
		}
		// If health is below 0, set it to 0, set Alive flag to false, and play Death animation
		if (queenAlive && queenHealth <= 0) {
			queenHealth = 0;
			queenAlive = false;
			GameObject.Find ("QueenModel").GetComponent<Animation> ().Play("QueenDie");
		}
		Debug.Log ("<<< QueenHealth: " + queenHealth);
	}

	// Queen's special move -- If she's alive and not on cooldown, heal the King and Queen
	public void healSpecial(){
		if (queenAlive && !queenOnSpecialCooldown) {
			if (kingAlive){
				if (KingHealth >= kingMaxHealth / 2)
					KingHealth = kingMaxHealth;
				else
					KingHealth += kingMaxHealth / 2;
			}
			if (queenAlive){
				if (QueenHealth >= queenMaxHealth / 2)
					QueenHealth = queenMaxHealth;
				else
					QueenHealth += queenMaxHealth / 2;
			}
			queenSpecial();
		}
	}

	// Set a timer for Ace's hit cooldown
	public IEnumerator aceDamageCooldown(){
		aceOnCooldown = true;
		yield return new WaitForSeconds (aceHealthCooldown);
		aceOnCooldown = false;
	}
	
	// Set a timer for Jack's hit cooldown
	public IEnumerator jackDamageCooldown(){
		jackOnCooldown = true;
		yield return new WaitForSeconds (jackHealthCooldown);
		jackOnCooldown = false;
	}
	
	// Set a timer for King's hit cooldown
	public IEnumerator kingDamageCooldown(){
		kingOnCooldown = true;
		yield return new WaitForSeconds (kingHealthCooldown);
		kingOnCooldown = false;
	}
	
	// Set a timer for Queen's hit cooldown
	public IEnumerator queenDamageCooldown(){
		queenOnCooldown = true;
		yield return new WaitForSeconds (queenHealthCooldown);
		queenOnCooldown = false;
	}
	
	// Set a timer for Queen's special cooldown
	public IEnumerator queenSpecial(){
		queenOnSpecialCooldown = true;
		yield return new WaitForSeconds (queenSpecialCooldown);
		queenOnSpecialCooldown = false;
	}

}
