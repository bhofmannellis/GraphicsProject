using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public RectTransform aceHealthTrans;
    public RectTransform jackHealthTrans;
    public RectTransform queenHealthTrans;
    public RectTransform kingHealthTrans;

    public static bool drawAceHealth;    // Flag for Ace's presence
    public static bool drawJackHealth;   // Flag for Jack's presence
    public static bool drawKingHealth;   // Flag for King's presence
    public static bool drawQueenHealth;  // Flag for Queen's presence

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
    private float minXQueen, maxXQueen;
    private float minXKing, maxXKing;

    public int aceHealth;
    public int jackHealth;
    public int queenHealth;
    public int kingHealth;

    public int aceMaxHealth;
    public int jackMaxHealth;
    public int queenMaxHealth;
    public int kingMaxHealth;

    public Image aceHealthImage;
    public Image jackHealthImage;
    public Image queenHealthImage;
    public Image kingHealthImage;

	// Use this for initialization
	void Start () {

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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Calculate health bar's postion as a ratio of currentHealth/maxHealth : currentPosiition/maxPosition, x decreases as health decreases
    private float translateHealth(float currentHealth, float minHealth, float maxHealth, float minXPos, float maxXPos, bool heartTeam)
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
}
