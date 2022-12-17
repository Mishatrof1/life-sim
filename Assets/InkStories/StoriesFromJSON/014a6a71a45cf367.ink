VAR StoryTittle = ""
VAR StoryQuestion = "I have this question on my quiz, 'What is the capital of Mexico?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18

VAR Character0IntelligenceCh = 0

Geography quiz
I have this question on my quiz, 'What is the capital of Mexico?'
* [Tijuana]
    -> res1
* [Cancun]
    -> res2
* [Mexico City]
    -> res3

=== res1 === 
Tijuana is the wrong answer.
~TextForLog = "Tijuana is the wrong answer, but I really wasn't sure, I was just guessing."
* [Ok]
-> END

=== res2 === 
Cancun is the wrong answer.
~TextForLog = "Cancun is the wrong answer, I think that's actually the big vacation spot. So, I probably shouldn't have chosen that."
* [Ok]
-> END

=== res3 === 
Mexico City s the right answer!
~TextForLog = "Mexico City is the right answer! It almost seemed like a fake answer, which made me hesitate but hey, I picked the right one. I'm happy!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END
