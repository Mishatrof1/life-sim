VAR StoryTittle = ""
VAR StoryQuestion = "Only one of the following sentences is grammatically correct, which one is it?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 11
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "HigherInPosition"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 64
VAR NPC1RelationshipSc = "Crush"
VAR NPC1GenderSc = "Opposite"

VAR NPC0RelationshipCh = 0
VAR NPC1SympathyCh = 0
VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC1HappinessCh = 0
VAR NPC1RelationshipCh = 0

I am taking an English test and this last question is really tough.
Only one of the following sentences is grammatically correct, which one is it?
* [I have traveled further than you.]
    -> res1
* [I have traveled further then you.]
    -> res2
* [I have traveled farther than you.]
    -> res3
* [I have traveled farther then you.]
    -> res4

=== res1 === 
This is the wrong answer.
~TextForLog = "This sentence is wrong. 'Than' is correct but 'Further' is not correct in this case."
* [Ok]
-> END

=== res2 === 
This is the wrong answer.
~TextForLog = "This choice is definitely wrong. 'Further' is wrong and so is 'Then'. Apparently, I was the only one in class to choose this answer and my teacher %FullName:NPC:1% makes me feel bad about it but :FullName:NPC:2% makes me feel better about it and tries to comfort me."
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC1SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
This is the right answer!
~TextForLog = "I chose correctly because 'Farther' is used when describing a distance and 'Than' is used when comparing. My teacher %FullName:NPC:1% is proud of me, especially since I was one of only two students to get this tough question right. Me and %FullName:NPC:2% and so we're both happy for one another."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
~NPC1HappinessCh = "%ValueRef:0:+%"
~NPC1RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
This is the wrong answer.
~TextForLog = "This answer was wrong. I guess 'Farther' was right but 'Then' is wrong. In this scenario it should have been 'Than.' It was a tough one though, at least I was only wrong on portion of the question."
* [Ok]
-> END
