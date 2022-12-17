VAR StoryTittle = ""
VAR StoryQuestion = "I have this question on my History test, 'Who was the 16th president of the United States?'"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18

VAR Character0IntelligenceCh = 0

History test
I have this question on my History test, 'Who was the 16th president of the United States?'
* [James Buchanan]
    -> res1
* [Abraham Lincoln]
    -> res2
* [Ulysses S. Grant]
    -> res3

=== res1 === 
James Buchanan is the wrong answer
~TextForLog = "James Buchanan was the wrong answer, it turns out he was the 15th president. So close!"
* [Ok]
-> END

=== res2 === 
Abraham Lincoln is the right answer!
~TextForLog = "Abraham Lincoln is the right answer! I guess my studying paid off."
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
Ulysses S. Grant is the wrong answer.
~TextForLog = "So, Ulysses S. Grant was the wrong answer, but I checked afterwards. He was the 18th president. Close enough! "
* [Ok]
-> END
