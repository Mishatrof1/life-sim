VAR StoryTittle = ""
VAR StoryQuestion = "'What is the most populated country in the world?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0IntelligenceCh = 0
VAR NPC0RelationshipCh = 0

I have this question on my geography quiz
'What is the most populated country in the world?'
* [China]
    -> res1
* [India]
    -> res2
* [United States]
    -> res3

=== res1 === 
China is the right answer!
~TextForLog = "China was the right answer! I knew that one, so glad I nailed it... or at least guessed right. Either way, I picked right on the quiz."
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
India is the wrong answer.
~TextForLog = "India is the wrong answer but it's the second most populated country and is just behind China... so I was close. Not a bad guess, I suppose."
* [Ok]
-> END

=== res3 === 
United States is the wrong answer.
~TextForLog = "So, United States was the wrong answer, it's the third most populated country and %FullName:NPC:1% laughs at me and makes fun of me for picking that. %Pron:1:1% thinks I'm an idiot and we end up getting into a big argument. I don't need to take %Pron:1:3% crap about one wrong answer. What a jerk!"
~Character0IntelligenceCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
