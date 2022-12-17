VAR StoryTittle = ""
VAR StoryQuestion = "I have this question on my Geography quiz, 'What is the capital of Germany?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 8
VAR Character0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0

Geography quiz
I have this question on my Geography quiz, 'What is the capital of Germany?'
* [Hamburg]
    -> res1
* [Munich]
    -> res2
* [Berlin]
    -> res3

=== res1 === 
Hamburg is the wrong answer
~TextForLog = "Hamburg is the wrong answer! It was Berlin! Agh, I am pretty sure I knew that! I'm so annoyed with myself!"
~Character0HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
Munich is the wrong answer.
~TextForLog = "Munich is the wrong answer! It was Berlin! Agh, I am pretty sure I knew that! I'm so annoyed with myself!"
~Character0HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
Berlin is the right answer!
~TextForLog = "Yes, Berlin is the right answer! I knew it! So glad I got that one right!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END
