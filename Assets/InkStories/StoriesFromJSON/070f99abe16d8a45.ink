VAR StoryTittle = ""
VAR StoryQuestion = "What rental care should I pick out?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 55
VAR NPC0OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0WealthCh = 0

I am going to my eccentric boss's place for a work party but my car is in the shop.
What rental care should I pick out?
* [Green sedan]
    -> res1
* [Blue hatchback]
    -> res2
* [A red truck]
    -> res3

=== res1 === 
My boss sees the green car and tells me geniuses pick green. %Pron:1:1% becomes impressed with me.
~TextForLog = "%FullName:NPC:1% is so impressed with my green car. %Pron:1:1% thinks I am some sort of genius now and spends much of the night talking to me."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
My boss immediately tells me that %Pron:1:1% doesn't like my car.
~TextForLog = "%FullName:NPC:1% doesn't like my rental car and holds it against me for some reason. %Pron:1:1% barely talks to me all night. However, I find an interesting philosophy book in the back seat which I read through later on and find $20 inside of it also! My boss may not like my rental car, but I do!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%20%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
The truck winds up being the same one my boss used to have.
~TextForLog = "%FullName:NPC:1% loves that I have %Pron:1:3% old truck and talks to me ALL night. %Pron:1:1% is even telling me that %Pron:1:1% is going to give me a promotion and a riase! This was my lucky truck!"
~Character0HappinessCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END
