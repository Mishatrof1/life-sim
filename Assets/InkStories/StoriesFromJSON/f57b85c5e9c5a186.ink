VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 22
VAR NPC1OccupationSc = "Colleague"
VAR NPC2OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0
VAR NPC2HappinessCh = 0
VAR NPC2RelationshipCh = 0
VAR Character0WealthCh = 0
VAR Character0IntelligenceCh = 0

My coworkers %FullName:NPC:1% and %FullName:NPC:2% want to go drink beers in the back room and invite me.
What do I do?
* [Say no thanks, I don't want to get in trouble.]
    -> res1
* [Say yes.]
    -> res2
* [Say yes, but suggest the back parking lot]
    -> res3

=== res1 === 
They both think I am lame and end up getting caught by our boss %FullName:NPC:3% and then they blame me!
~TextForLog = "%FullName:NPC:3% is glad I don't get caught up in any of this stuff. But %FullName:NPC:1% and %FullName:NPC:2% get mad at me. They seem to think it's my fault. Like I told someone. They're the idiots who went drinking where there are security cameras!"
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1HappinessCh = "%ValueRef:0:-%"
~NPC1RelationshipCh = "%ValueRef:0:-%"
~NPC2HappinessCh = "%ValueRef:0:+%"
~NPC2RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We all end up getting caught by our boss %FullName:NPC:3%.
~TextForLog = "We ended up having a pretty good time together. But then %FullName:NPC:3% caught us through the security cameras and we all get in trouble and have to pay money for the offense."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0WealthCh = "%-25%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
~NPC2HappinessCh = "%ValueRef:1:-%"
~NPC2RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res3 === 
I think there are cameras in the back room, but we drink beers in the back parking lot and no one finds out!
~TextForLog = "I am pretty sure there are cameras in the back room so we likely would've been caught. But when I suggest the back parking lot, it's a genius idea! No cameras back there, the three of us get to hang out and have a great time and then get back to work later on when we feel like it! What a day!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC1HappinessCh = "%ValueRef:1:+%"
~NPC1RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END
