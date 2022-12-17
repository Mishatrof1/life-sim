VAR StoryTittle = ""
VAR StoryQuestion = "'Which of the following big cats cannot roar?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18

VAR Character0IntelligenceCh = 0

The last question on my Science quiz
'Which of the following big cats cannot roar?'
* [Lion]
    -> res1
* [Tiger]
    -> res2
* [Jaguar]
    -> res3
* [Cheetah]
    -> res4

=== res1 === 
Lion is the wrong answer.
~TextForLog = "Lion was the wrong answer and I feel stupid. Everyone knows lions can roar, why did I choose that one?"
~Character0IntelligenceCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
Tiger is the wrong answer.
~TextForLog = "Well, got that one wrong. And I'm pretty sure I did know tigers could roar. But I was just guessing."
* [Ok]
-> END

=== res3 === 
Jaguar is the wrong answer.
~TextForLog = "Jaguar was a wrong guess, I wasn't really sure but it seemed like it might be the right answer."
* [Ok]
-> END

=== res4 === 
Cheetah is the right answer!
~TextForLog = "Cheetah was the right answer! I remember reading that cheetahs can only purr and they cannot roar. Glad I retained that bit of information!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END
