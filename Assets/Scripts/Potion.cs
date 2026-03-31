using UnityEngine;

public class Potion : MonoBehaviour
{

    /// <summary>
    /// Whats Needed:
    /// - Crafting potions
    /// - Potion effects
    /// 
    /// Potion effects:
    /// - Choose a player. Remove an ingredient from their inventory and add it to your own.
    /// - Freeze a 2x2 square of ingredients on the grid, preventing anything from affecting or interacting with them until your next turn
    /// - Flip over and shuffle the discard pile and draw one from the top. If you draw a perfect ingredient, put it at the bottom and draw again
    /// - Compete in a single round of rock-paper-scissors with each player. For each round, the winner earns 3 points. Ties yield no points. (Maybe Coin flips)
    /// - Cause one player to lose 5 points
    /// - For their next 3 turns, opponents must choose one ingredient to discard, or they lose 2 points each time
    /// - Until the end of your next turn earn the points any other player earns
    /// - Take any potion from an opponent, gain the effects and the points. That opponent gets nothing.
    /// - All brewing will be delayed by 2 turns
    /// 
    /// - Take the top ingredient from the draw pile and add it to your inventory.
    /// - For your next two turns, yellow ingredients are treated as colorless (wild)
    /// - On your next potion drank, that potion's effect(s) trigger twice (Non Advanced Potions)
    /// - For the next 3 rounds, anytime a player drinks a potion, take a card from the top of the draw pile
    /// - Every turn that you successfully make a match, take a ingredient from the top of the deck/Discard pile. (This potion gets replayed until you fail to make a match
    /// - Choose an ingredient out loud and draw the top ingredient from the deck. If you correctly guessed the ingredient, earn 10 points. If you correctly guessed the color, earn 3 points. Add the ingredient to your inventory.
    /// - For your next 3 turns, you may flip over one additional card when trying to make a match // HERE HERHEHRHEHREHRHEHRH
    /// - The next 5 non-Perfect ingredients you use to brew a potion can be used a second time.
    /// - Discard any amount of ingredients in your hand, gain 2 points for each discard ingredent.
    /// - Any potion you have currently brewed can be rebrewed as a different potion of same color and rarity
    /// 
    /// - When attempting to brew a potion this turn, you may replace any non-Perfect ingredient required to brew that potion with another ingredient of your choosing.
    /// - Regain up to 5 lost points or gain 2 points
    /// - Each ingredient you add to your inventory this turn earns you 2 points.
    /// - Once, when a player is brewing a potion, you can take 1 random ingredient from that potion, cancelling the brewing process
    /// - Cleanse any active negative potion effect on you
    /// - No players can drink a potion for one round
    /// - For the next 5 turns, you are immune to the negative effects of other player's potions
    /// - For the next 3 opponent's matches made, take one ingredient from those matches and add it to your inventory
    /// 
    /// - If you failed to make a match this turn, gain the ingredients anyways
    /// - Skips an opponents turn. Any potions brewed before are still completed
    /// - Choose a player. Both you and that player choose an ingredient tile on the grid. If a match is made, both players earn 5 points and you add the ingredients to your inventory.
    /// - Pick 3 tiles to "harden", making them unable to be flipped over until your next turn.
    /// - Replace a tile with a bomb tile. Whenever another player flips it, you add all adjacent tiles to your inventory (+) If you flip your own bomb, the adjacent ingredients are discarded
    /// - Pick a player. The next time they would gain points, they instead lose those points
    /// - If you play this potion, you obtain the effects of the next potion played.
    /// - Have all other players turn away and place trap tokens under 4 tiles in a square. If another player selects one of those tiles, they will have their turn skipped and lose 2 ingredients of their choice or 4 points (their choice). Each trap lasts for 3 turns.
    /// - Have all other players turn away and place trap tokens under 4 tiles anywhere on the grid. If a player selects one of these tiles, they lose 3 points. Each traps last for 3 turns.
    /// 
    /// - Gain points
    /// - if you gain no points this turn and next turn gain 8 points
    /// - Gain an item to take notes with, where you can write down placements of ingredients
    /// 
    /// - Peek at 2 tiles
    /// - Each player takes one ingredient from the person to their right, ending with you.
    /// - Takes away the ability to see the potion sheet for 1 person for 3 turns. If you get the recipe wrong you lose 1 point and cant brew anymore for that turn
    /// - Peek at 4 tiles. You can switch up to 4 ingredients in your hand with any of the 4 tiles.
    /// - Shuffle the grid every round for 3 rounds
    /// - On drink, choose a player. Add Parasite Hex to that player’s inventory. If this potion is in your inventory, you gain the ability to drink it, but you also lose 2 points per turn.
    /// - Earn 1+x points per each future potion you drink, but these potions' effects are nullified, with x being the number of nullified potions you have drank.
    /// 
    /// == Types of Effects ==
    /// - Inventory Effects: Add or remove ingredients from a player's inventory
    /// - Discard Effects: Take from discard pile
    /// - Random Effects: Randomly do stuff
    /// - Point Effects: Gain or lose points
    /// - Draw Effects: Take from the draw pile
    /// - Potion Effects: Affect the potions that players have brewed or will brew
    /// - 
    /// - Ongoing Effects: Effects that last for a certain number of turns or until a certain condition is met
    /// 
    /// 
    /// == Ideas ==
    /// - Potion dict of strings to Delegate functions
    /// </summary>

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Potion list and funtions.
    /// </summary>

    // Choose a player. Remove an ingredient from their inventory and add it to your own.
    void ThievesMark()
    {
        //Choose player function
        //Remove ingredient from their inventory
        //Add ingredient to your inventory
    }

    // Freeze a 2x2 square of ingredients on the grid, preventing anything from affecting or interacting with them until your next turn
    void GiantSnowball()
    {
        //Choose 2x2 square AREA function
        //Freeze those ingredients until your next turn
    }

    // Flip over and shuffle the discard pile and draw one from the top. If you draw a perfect ingredient, put it at the bottom and draw again
    void Scavenging()
    {
        //Take a random discard pile ingridient
        // if perfect, draw again
        //Add ingredient to inventory
    }

    // Compete in a single round of rock-paper-scissors with each player. For each round, the winner earns 3 points. Ties yield no points. (Maybe Coin flips)
    void TrialOfSkill()
    {
        //for each player, do some type of random generator to determine win/loss/tie or RPS
        //Award 3 points to winner of each round
    }

    // Cause one player to lose 5 points
    void InstantIcicle()
    {
        //Choose player function
        //Remove 5 points from that player
    }
}
