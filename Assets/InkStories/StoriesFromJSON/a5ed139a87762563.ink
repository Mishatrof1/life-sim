VAR StoryTittle = ""
VAR StoryQuestion = "I have this question on my test, 'Eyes are to sight as tongue is to what?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "HigherInPosition"

VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0

English test
I have this question on my test, 'Eyes are to sight as tongue is to what?'
* [Taste]
    -> res1
* [Speech]
    -> res2
* [Kiss]
    -> res3

=== res1 === 
Taste is the right answer and the "best" answer.
~TextForLog = "As my teacher %FullName:NPC:1% tells me this was one of two acceptable answers, but it was the best answer so it counted for more points on my test. Alright! I am happy with that."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
Speech is an acceptable answer.
~TextForLog = "As my teacher %FullName:NPC:1% explains to me, this counts as an acceptable answer. So, it is technically right, though the answer that was better than speech was taste. I guess that makes sense."
* [Ok]
-> END

=== res3 === 
Kiss is the wrong answer.
~TextForLog = "Kiss is the wrong answer and my teacher %FullName:NPC:1% even tells me it was the only unacceptable choice. So, that makes me feel even worse..."
~Character0IntelligenceCh = "%ValueRef:0:-%"
* [Ok]
-> END
