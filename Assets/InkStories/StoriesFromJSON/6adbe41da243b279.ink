VAR StoryTittle = ""
VAR StoryQuestion = "I'm taking a math quiz and the question is, 'If 5x + 3 = 33, then what does x equal?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18

VAR Character0IntelligenceCh = 0

Math quiz
I'm taking a math quiz and the question is, 'If 5x + 3 = 33, then what does x equal?'
* [5]
    -> res1
* [6]
    -> res2
* [7]
    -> res3

=== res1 === 
5 is the wrong answer.
~TextForLog = "5 is the wrong answer, and I realize I do not get algebra."
* [Ok]
-> END

=== res2 === 
6 is the right answer.
~TextForLog = "6 is the right answer! I knew it! My studying paid off... or I am a good guesser!"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
7 is the wrong answer.
~TextForLog = "7 is the wrong answer and I realize that I have guessed wrong. I wish I were a better guesser... or just knew more of this material."
* [Ok]
-> END
