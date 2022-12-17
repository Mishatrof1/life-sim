VAR StoryTittle = ""
VAR StoryQuestion = "'What is the fifth largest country by area?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18

VAR Character0IntelligenceCh = 0
VAR Character0HappinessCh = 0

I have this question on my quiz
'What is the fifth largest country by area?'
* [Russia]
    -> res1
* [United States]
    -> res2
* [Brazil]
    -> res3
* [Australia]
    -> res4

=== res1 === 
Russia is the wrong answer.
~TextForLog = "Russia is not only the wrong answer but it is also the biggest country in the world so I feel a little dumb for picking that answer. So mad at myself!"
~Character0IntelligenceCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
United States is the wrong answer
~TextForLog = "Well, I thought it was a pretty good guess but the United States was the wrong answer."
* [Ok]
-> END

=== res3 === 
Brazil is the right answer!
~TextForLog = "Brazil was the right answer and I'm so happy because I was a little unsure of this one, but this question literally was the deciding factor of whether I got a B+ or an A-... and this right answer gets me a good ol' A-!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
Australia is the wrong answer.
~TextForLog = "Australia is the wrong answer... but it seemed like a good guess. I must have been close. You should get some points if you're close to the right answer. That's what I think."
* [Ok]
-> END
