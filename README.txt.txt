================================== Sailor Moon: Cosmic Champions
Character Descriptions
Sailor Moon (PlayerName (Sailor Moon))

Max Health: 120

Shape: Circle (Visually represented as a pink circle)

Description: The leader of the Sailor Scouts, balanced in her abilities. She can deal reliable damage with her "Moon Tiara Action," heal herself with "Moon Healing Escalation," and protect herself with "Moonlight Veil" to boost her defense.

Sailor Mercury (PlayerName (Sailor Mercury))

Max Health: 110

Shape: Rounded Rectangle (Visually represented as a blue rounded rectangle)

Description: The strategist of the group, Sailor Mercury excels at disrupting opponents. "Shine Aqua Illusion" can damage and lower the opponent's accuracy. "Bubble Spray" increases her own evasion, making her harder to hit. "Mercury Aqua Mirage" can lower an opponent's defense, making them more susceptible to damage.

Sailor Mars (PlayerName (Sailor Mars))

Max Health: 95

Shape: Triangle (Visually represented as a crimson triangle)

Description: A powerful offensive fighter with fire-based attacks. "Fire Soul" is a straightforward strong attack. "Fire Soul Bird" is a high-damage move with a chance to burn (poison) the opponent. Her spiritual chant, "Akuryo Taisan," weakens the opponent's attack power.

Sailor Jupiter (PlayerName (Sailor Jupiter))

Max Health: 105

Shape: Square (Visually represented as a dark green square)

Description: Known for her strength and electric attacks. "Supreme Thunder" deals significant lightning damage. "Flower Hurricane" is a multi-hit attack with petals. She can also power up with "Jupiter Power, Make Up!" to boost her own attack strength.

Application of OOP Principles
Encapsulation:

The SailorScout class encapsulates the common properties (like Name, Health, MaxHealth, ActiveStatusEffects, Moves) and behaviors (like ApplyStatusEffect, HandleTurnStartStatusEffects, TickDownStatusEffects, ExecuteChosenAttack, IsDefeated) of all playable characters.

The Health property has a public getter but its setter ensures health doesn't go below 0 or above MaxHealth, demonstrating data protection and controlled access.

The AttackMove class encapsulates all information related to a specific attack (Name, Description, Damage range, Accuracy, EffectDetails, and the execution logic via a Func delegate).

Internal logic for how status effects are applied, ticked down, or how damage is calculated based on stats and effects is hidden within the respective methods, exposing only the necessary interfaces.

Abstraction:

The SailorScout class is an abstract class. This provides a blueprint for all specific Sailor Scout characters. It defines common functionalities that all scouts must have (like InitializeMoves, which is an abstract method) but leaves the specific implementation details of those moves and character-specific properties (like CharacterShape and CharacterBrush) to the derived classes.

Users of the SailorScout objects (e.g., in Form1.cs) interact with them through their common interface (e.g., calling ExecuteChosenAttack or accessing Health) without needing to know the specific internal workings of each individual scout type.

The AttackMove.ExecuteAction uses a Func<SailorScout, SailorScout, Tuple<int, string>> delegate, abstracting the specific logic of what an attack does. Each move defines its own unique action through this delegate.

Inheritance:

Specific character classes like SailorMoon, SailorMercury, SailorMars, and SailorJupiter all inherit from the base SailorScout class.

They inherit common attributes (e.g., Name, Health) and methods (e.g., ApplyStatusEffect, ExecuteChosenAttack).

Each derived class provides its own specific implementation for the abstract InitializeMoves method, populating its unique list of AttackMove objects. They also override CharacterShape and CharacterBrush to define their unique visual representation.

Polymorphism:

The pnlBattleScene_Paint method in Form1.cs uses a SailorScout type variable to draw characters. When DrawCharacter is called, the actual CharacterShape and CharacterBrush used are determined at runtime based on the specific object type (e.g., SailorMoon or SailorMars) being passed. This is an example of polymorphism, where a single interface (the SailorScout reference) can represent different underlying forms (the specific scout types).

The currentPlayer variable in Form1.cs is of type SailorScout. It can hold an instance of SailorMoon, SailorMercury, etc. When methods like currentPlayer.Moves or currentPlayer.ExecuteChosenAttack are called, the correct version of these (or the data they access) for the specific scout type is used.

The Activator.CreateInstance(p1Type, txtPlayer1Name.Text) line in InitializeBattle demonstrates polymorphism by creating different types of SailorScout objects based on user selection, all assignable to a SailorScout reference.

Challenges Faced
Initial Design and Structure:

Deciding on the base class structure (SailorScout) and what properties/methods should be abstract versus concrete took some planning to ensure flexibility and avoid code duplication.

Structuring the AttackMove class, particularly how to handle the diverse effects of different moves (damage, healing, status effects), led to using a Func delegate for ExecuteAction, which provided good flexibility.

Status Effect Management:

Implementing the logic for applying status effects, tracking their durations, and having them interact correctly with attacks (e.g., AttackUp boosting damage, Poison dealing damage at turn start) required careful handling of dictionaries and ensuring effects ticked down and expired correctly.

Ensuring that status effects were visually represented on the UI (the small icons) and updated dynamically.

Turn-Based Logic and UI Synchronization:

Managing the game state (whose turn it is, enabling/disabling controls appropriately, updating UI elements like health bars and battle logs) in Form1.cs was complex.

Ensuring the UI refreshed correctly after each action (e.g., pnlBattleScene.Invalidate()) to show changes in health, status effects, and hit animations.

Graphics and Visuals (GDI+):

Drawing the characters, health bars, status icons, and the themed background in the pnlBattleScene_Paint event required working with GDI+ drawing tools.

Implementing the "hit flash" effect using a timer and boolean flags (player1IsHit, player2IsHit) added a bit of visual feedback but needed careful timing.

Creating the space theme with a gradient background, stars, and a crescent moon, and ensuring it looked good and performed reasonably. The initial attempt to draw the moon outside the bgBrush scope caused a runtime error ('bgBrush' does not exist in the current context) which had to be debugged and fixed by moving the moon drawing logic.

Balancing Gameplay:

Deciding on health points, attack damage ranges, accuracy, and the impact/duration of status effects for each character and move was an iterative process. While not a coding challenge per se, it's a game design challenge to make the game feel fair and fun. The addition of non-damaging strategic moves was part of this balancing and depth-adding process.

User Experience and Interactivity:

Making the UI intuitive (e.g., attack descriptions updating on selection, clear indication of whose turn it is).

Adding hover effects to buttons to make the application feel more responsive and modern within the WinForms limitations.