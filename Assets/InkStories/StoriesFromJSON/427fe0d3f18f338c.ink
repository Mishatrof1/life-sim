VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 12
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"
VAR NPC0MinAgeSc = 12
VAR NPC0MaxAgeSc = 18
VAR NPC1RelationshipSc = "Crush"
VAR NPC1GenderSc = "Opposite"

VAR Character0HappinessCh = 0
VAR Character0AthleticismCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0
VAR NPC1SympathyCh = 0
VAR NPC0SympathyCh = 0

I'm playing in a school basketball game in front of all my classmates and I can feel my shorts are sliding down.
What should I do?
* [Just ignore it and keep playing]
    -> res1
* [Grab my shorts and hold on]
    -> res2
* [Grab my shorts and run to the bathroom]
    -> res3

=== res1 === 
%FullName:NPC:1% passes the ball to me, my shorts fall down but I score the game-winning shot.
~TextForLog = "I'm so embarrassed, my shorts fell down in front of everyone! But I still caught the ball and made the game-winning shot. So, everyone is cheering me on for that and because they found it hilarious when my shorts dropped. I still just cannot believe it."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I hold onto my shorts so they don't fall but %FullName:NPC:1% passes the ball to me and hits me in the face and we end up losing the game.
~TextForLog = "Well, %FullName:NPC:1% and everyone else at the school is mad at me, but I talk to %FullName:NPC:2% later on and explain to %Pron:2:2% what happened and %Pron:2:1% understands and comforts and consoles me. It does make me feel much better."
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC1SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
I run to the bathroom in hopes I can fix my shorts but running off the court in the middle of the game loses us the game.
~TextForLog = "Everyone thinks I ran t the bathroom because I had to use the toilet and now they're all laughing at me and making fun of me. Even %FullName:NPC:2% thinks this is the case. I'm so embarrassed. I explain the situation to %FullName:NPC:1% and %Pron:1:1% gets it and tries to comfort me and make me feel better."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
