using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public RectTransform aceHealthTrans;
    public RectTransform jackHealthTrans;
    public RectTransform queenHealthTrans;
    public RectTransform kingHealthTrans;

    public static bool drawAceHealth = false;   // Flag for Ace's presence
	public static bool drawJackHealth = false;  // Flag for Jack's presence
	public static bool drawKingHealth = false;  // Flag for King's presence
	public static bool drawQueenHealth = false; // Flag for Queen's presence

    // Save y-locations of each healthbar
    private float yPosAce;
    private float yPosJack;
    private float yPosKing;
    private float yPosQueen;

    // Values for minimum and maximum x-positions of each character's health
    // Note: Queen and King health operations are a reverse of Ace and Jack health operations.
    // As Ace/Jack health decreases, x decreases (xMax -> xMin). As King/Queen health decreases, x increases (xMin -> xMax).
    private float minXAce, maxXAce;
	private float minXJack, maxXJack;
	private float minXKing, maxXKing;
    private float minXQueen, maxXQueen;

    private int aceHealth;
	public int AceHealth
	{
		get{ return aceHealth;}
		set{ aceHealth = value;
			HandleHealth();}
	}
	private int jackHealth;
	public int JackHealth{
		get{ return jackHealth;}
		set{ jackHealth = value;
			HandleHealth();}
	}
	private int kingHealth;
	public int KingHealth{
		get{ return kingHealth;}
		set{ kingHealth = value;
			HandleHealth();}
	}
	private int queenHealth;
	public int QueenHealth{
		get{ return queenHealth;}
		set{ queenHealth = value;
			HandleHealth();}
	}

	// TODO : Set max health
    public int aceMaxHealth;
	public int jackMaxHealth;
	public int kingMaxHealth;
    public int queenMaxHealth;

    public Image aceHealthImage;
	public Image jackHealthImage;
	public Image kingHealthImage;
    public Image queenHealthImage;

	public float aceHealthCooldown;
	public float jackHealthCooldown;
	public float kingHealthCooldown;
	public float queenHealthCooldown;

	public bool aceOnCooldown;
	public bool jackOnCooldown;
	public bool kingOnCooldown;
	public bool queenOnCooldown;

	// Use this for initialization
	void Start () {

		// TODO : initialize RectangleTransforms for each character
		// TODO : initialize healthimages for each character
		// TODO : Set healthimage for 

        // Save y-position of each healthbar
        yPosAce = aceHealthTrans.position.y;
        yPosJack = jackHealthTrans.position.y;
        yPosQueen = queenHealthTrans.position.y;
        yPosKing = kingHealthTrans.position.y;

        // Set max x values for the healthbars (starting position)
        maxXAce = aceHealthTrans.position.x;
        maxXJack = jackHealthTrans.position.x;
        maxXQueen = queenHealthTrans.position.x;
        maxXKing = kingHealthTrans.position.x;

        // Set min x values -- Note: Ace/Jack min is xMax - width, Queen/King min is xMax + width
        minXAce = aceHealthTrans.position.x - aceHealthTrans.rect.width;
        minXJack = jackHealthTrans.position.x - jackHealthTrans.rect.width;
        minXQueen = queenHealthTrans.position.x + queenHealthTrans.rect.width;
        minXKing = kingHealthTrans.position.x + kingHealthTrans.rect.width;

        aceHealth = aceMaxHealth;
        jackHealth = jackMaxHealth;
        queenHealth = queenMaxHealth;
        kingHealth = kingMaxHealth;

        // Initialize all draw health flags to false. Change to true when the camera sees the target
        drawAceHealth = drawJackHealth = drawKingHealth = drawQueenHealth = false;
		aceOnCooldown = jackOnCooldown = kingOnCooldown = queenOnCooldown = false;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

    // Calculate health bar's postion as a ratio of currentHealth/maxHealth : currentPosiition/maxPosition, x decreases as health decreases
    private float TranslateHealth(float currentHealth, float minHealth, float maxHealth, float minXPos, float maxXPos, bool heartTeam)
    {
       // Get current health percentage
       float healthPercentage = currentHealth / (maxHealth - minHealth);

       // If translating health for Hearts team, invert the percentage as health moves left to right as it decreases
       if (heartTeam)
          healthPercentage = 1 - healthPercentage;

       // Get appropriate x translation in regards to x-span of health bar
       float xTranslation = healthPercentage * (maxXPos - minXPos);

       // Result is minimum x of health bar + ratio of health percentage to x span 
       return minXPos + xTranslation;
    }

	private void HandleHealth(){

		float currentXAce = TranslateHealth(aceHealth,0,aceMaxHealth,minXAce,maxXAce,false);
		float currentXJack = TranslateHealth(jackHealth,0,jackMaxHealth,minXJack,maxXJack,false);
		float currentXKing = TranslateHealth(kingHealth,0,kingMaxHealth,minXKing,maxXKing,true);
		float currentXQueen = TranslateHealth(queenHealth,0,queenMaxHealth,minXQueen,maxXQueen,true);

		aceHealthTrans.localPosition = new Vector3 (currentXAce, yPosAce);
		jackHealthTrans.localPosition = new Vector3 (currentXJack, yPosJack);
		kingHealthTrans.localPosition = new Vector3 (currentXKing, yPosKing);
		queenHealthTrans.localPosition = new Vector3 (currentXQueen, yPosQueen);

		if (aceHealth > aceMaxHealth / 2)
			aceHealthImage.color = new Color32 ((byte)TranslateHealth(aceHealth, aceMaxHealth / 2, aceMaxHealth, 255, 0, false), 255, 0, 255);
		else
			aceHealthImage.color = new Color32 (255, (byte)TranslateHealth(aceHealth, 0, aceMaxHealth/2, 0, 255, false), 0, 255);

		if (jackHealth > jackMaxHealth / 2)
			jackHealthImage.color = new Color32 ((byte)TranslateHealth(jackHealth, jackMaxHealth / 2, jackMaxHealth, 255, 0, false), 255, 0, 255);
		else
			jackHealthImage.color = new Color32 (255, (byte)TranslateHealth(jackHealth, 0, jackMaxHealth/2, 0, 255, false), 0, 255);

		if (kingHealth > kingMaxHealth / 2)
			kingHealthImage.color = new Color32 ((byte)TranslateHealth(kingHealth, kingMaxHealth / 2, kingMaxHealth, 255, 0, true), 255, 0, 255);
		else
			kingHealthImage.color = new Color32 (255, (byte)TranslateHealth(kingHealth, 0, kingMaxHealth/2, 0, 255, true), 0, 255);

		if (queenHealth > queenMaxHealth / 2)
			queenHealthImage.color = new Color32 ((byte)TranslateHealth(queenHealth, queenMaxHealth / 2, queenMaxHealth, 255, 0, true), 255, 0, 255);
		else
			queenHealthImage.color = new Color32 (255, (byte)TranslateHealth(queenHealth, 0, queenMaxHealth/2, 0, 255, true), 0, 255);
	}

	public void hitAce(int damage){
		if (!aceOnCooldown) {
			AceHealth -= damage;
			aceDamageCooldown();
		}
		if (aceHealth < 0)
			AceHealth = 0;
	}

	public void hitJack(int damage){
		if (!jackOnCooldown) {
			JackHealth -= damage;
			jackDamageCooldown();
		}
		if (jackHealth < 0)
			JackHealth = 0;
	}

	public void hitKing(int damage){
		if (!aceOnCooldown) {
			KingHealth -= damage;
			kingDamageCooldown();
		}
		if (kingHealth < 0)
			KingHealth = 0;
	}

	// If the queen is not on damage cooldown, register the hit and start the cooldown
	public void hitQueen(int damage){
		if (!aceOnCooldown) {
			QueenHealth -= damage;
			queenDamageCooldown();
		}
		if (queenHealth < 0)
			QueenHealth = 0;
	}

	// Set a timer for Ace's hit cooldown
	IEnumerator aceDamageCooldown(){
		aceOnCooldown = true;
		yield return new WaitForSeconds (aceHealthCooldown);
		aceOnCooldown = false;
	}
	
	// Set a timer for Jack's hit cooldown
	IEnumerator jackDamageCooldown(){
		jackOnCooldown = true;
		yield return new WaitForSeconds (jackHealthCooldown);
		jackOnCooldown = false;
	}
	
	// Set a timer for King's hit cooldown
	IEnumerator kingDamageCooldown(){
		kingOnCooldown = true;
		yield return new WaitForSeconds (kingHealthCooldown);
		kingOnCooldown = false;
	}
	
	// Set a timer for Queen's hit cooldown
	IEnumerator queenDamageCooldown(){
		queenOnCooldown = true;
		yield return new WaitForSeconds (queenHealthCooldown);
		queenOnCooldown = false;
	}
}
