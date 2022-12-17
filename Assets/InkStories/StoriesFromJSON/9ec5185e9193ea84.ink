VAR StoryTittle = ""
VAR StoryQuestion = "I have to answer this problem. '50 + 100 x 0 - 13 = ' What is the answer?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0

Math quiz
I have to answer this problem. '50 + 100 x 0 - 13 = ' What is the answer?
* [-13]
    -> res1
* [37]
    -> res2
* [137]
    -> res3
* [0]
    -> res4

=== res1 === 
This is the wrong answer.
~TextForLog = "-13 was the wrong answer, but I definitely arrived there and di some kind of math. I wonder where I went wrong."
* [Ok]
-> END

=== res2 === 
This is the right answer!
~TextForLog = "My teacher %FullName:NPC:1% is proud of me for getting this one right since it tripped up a lot of people in class. And I'm glad I figured it out!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
This is the wrong answer.
~TextForLog = "I realize a lot of people in class chose 137 for this question and many of us are confused how this wasn't the right answer."
* [Ok]
-> END

=== res4 === 
This is the wrong answer.
~TextForLog = "%FullName:NPC:1% is confused why I even thought this was the answer. %Pron:1:1% tells me this was the 'joke option.' Alright, so I got it wrong. You don't have to make me feel worse about it!"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
