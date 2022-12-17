VAR StoryTittle = ""
VAR StoryQuestion = "'What does x equal if 3x = 2x + 8?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18
VAR NPC0OccupationSc = "Classmate"
VAR NPC0GenderSc = "Same"

VAR Character0IntelligenceCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HappinessCh = 0

I have this question on my math quiz
'What does x equal if 3x = 2x + 8?'
* [8]
    -> res1
* [4]
    -> res2
* [0]
    -> res3

=== res1 === 
8 is the right answer!
~TextForLog = "8 is the right answer and %FullName:NPC:1% told me after the test that %Pron:1:1% was copying off of me on that question because %Pron:1:1% didn't know so %Pron:1:1% is glad we both got it right and tells everyone I'm so smart."
~Character0IntelligenceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
4 is the wrong answer.
~TextForLog = "4 is the wrong answer and %FullName:NPC:1% tells me %Pron:1:1% was copying off of me and now is mad at me for getting the answer wrong because that means %Pron:1:1% also got it wrong. This is my fault??"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
0 is the wrong answer.
~TextForLog = "0 is the wrong answer but %FullName:NPC:1% tells me that %Pron:1:1% saw that I put 0 and %Pron:1:1% was thinking 0 was the right answer too. We both have a good laugh over the fact that we both got it wrong and that %Pron:1:1% even tried to confirm with me what I put, thinking I was going to get it right!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
