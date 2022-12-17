VAR StoryTittle = ""
VAR StoryQuestion = "Which of the following animals is NOT a mammal?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "PrimarySchool:MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 7
VAR Character0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0

I am taking a quiz in Science class and am trying to figure out this question.
Which of the following animals is NOT a mammal?
* [Bear]
    -> res1
* [Bat]
    -> res2
* [Eagle]
    -> res3
* [Human]
    -> res4

=== res1 === 
Bear is the wrong answer.
~TextForLog = "Bear is the wrong answer and it was also probably the most obvious choice to not pick... but I chose it anyway. And now I am mad at myself. No one else in class picked Bear. Why did I pick BEAR?!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0IntelligenceCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
Bat is the wrong answer.
~TextForLog = "Agh! Bat was the wrong answer? I don't know, I could've sworn those things were birds or... something else! I don't know what, but I did not think they were mammals! I wasn't the only one in class to choose this answer though. It was tricky."
* [Ok]
-> END

=== res3 === 
Eagle is the right answer!
~TextForLog = "Eagle was the right answer! Of course! Because eagles are birds and birds are entirely different from mammals. Still proud of myself for getting this one right."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
Human is the wrong answer.
~TextForLog = "Human is the wrong answer, this was another tricky option on the test. A few of us guessed this. I always think of us humans as different, but I suppose we are mammals just like bears and... bats too? Really? Hm, guess the right answer was eagle."
* [Ok]
-> END
