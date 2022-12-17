VAR StoryTittle = ""
VAR StoryQuestion = "'What is the capital of South Dakota?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "HigherInPosition"

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

I'm taking a Geography quiz in school and I am trying to figure out the answer to this last question.
'What is the capital of South Dakota?'
* [Pierre]
    -> res1
* [Sioux Falls]
    -> res2
* [Rapid City]
    -> res3
* [Bastien]
    -> res4

=== res1 === 
That's the right answer! And my teacher %FullName:NPC:1% is happy with me because %Pron:1:1% is from South Dakota and talks about it all the time.
~TextForLog = "%FullName:NPC:1% was happy I got that one right since %Pron:1:1% always talks about South Dakota. I'm glad I got it right because it helped my grade!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
This is the wrong answer and my teacher %FullName:NPC:1% is upset I didn't remember because %Pron:1:1% talks about being from South Dakota all the time.
~TextForLog = "Well, %FullName:NPC:1% felt like I should've gotten that one right, since %Pron:1:1% always talks about being from South Dakota. Oh well."
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
This is the wrong answer and my teacher %FullName:NPC:1% is upset I didn't remember because %Pron:1:1% talks about being from South Dakota all the time.
~TextForLog = "Well, %FullName:NPC:1% felt like I should've gotten that one right, since %Pron:1:1% always talks about being from South Dakota. Oh well."
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
My teacher %FullName:NPC:1% is really upset with me because this isn't even a city in South Dakota.
~TextForLog = "%FullName:NPC:1% tells me I am lucky that %Pron:1:1% can't mark me down a whole letter grade for choosing that answer because I wasn't only wrong... I was very wrong. Whoops!"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END
