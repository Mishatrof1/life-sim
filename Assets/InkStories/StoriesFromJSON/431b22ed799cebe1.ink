VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 11
VAR Character0MaxAgeSc = 18
VAR NPC0RelativesSc = "Parent"
VAR NPC0GenderSc = "Female"
VAR NPC1RelativesSc = "Parent"
VAR NPC1GenderSc = "Male"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0HealthCh = 0
VAR NPC0SympathyCh = 0
VAR NPC1SympathyCh = 0
VAR Character0EnduranceCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0WealthCh = 0
VAR Character0WisdomCh = 0

I'm home alone and suddenly I hear the pots and pans fall out of the cabinet in the kitchen and then I hear the stove turn on.
What do I do?
* [Ignore it, my mind must be playing tricks on me.]
    -> res1
* [Go in the kitchen and turn the stove off.]
    -> res2
* [Leave the house]
    -> res3
* [Go in the kitchen and watch]
    -> res4

=== res1 === 
I ignore it and go nowhere near the kitchen. My parents come home later and thank me for making food.
~TextForLog = "This is unsettling. I was alone in the house. But I was not alone in the house. My mind was not playing tricks on me. I didn't make any food, yet there was food prepared that my parents ate when they got home and they thanked me for it. Do we have a cooking ghost in the house?!"
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I turn the stove off and it turns back on. I get so scared, I turn to run but trip and hurt myself.
~TextForLog = "My parents come home and find I injured myself and ask what happened. I lie and say I slipped and fell. I don't want to actually tell them what happened. They take care of me but I am more concerned with whatever was happening in the kitchen."
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC1SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I run out of the house and go to the library. My parents come home to find a fire in the kitchen.
~TextForLog = "My parents are so mad when they come home to find a fire. They blame me! They think I left the stove on and left! I was just getting the heck out of there! I was not about to spend another second alone in our haunted house! That's ghost stuff happening! I just read books in the library until they came home, but they yelled at me and made me pay for the damages."
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-100%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
I watch by the kitchen doorway to see pots and pans moving around on their own and cooking food.
~TextForLog = "My parents come home and thank me for making food. But I wasn't the one who made the food. It was the strangest thing. There was no one there but I kept seeing flashes of arms and legs moving around. And food being prepared... on its own? I can't even explain, I think there is a ghost in our house... that likes to cook?"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
