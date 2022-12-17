VAR StoryTittle = ""
VAR StoryQuestion = "Greenland is an autonomous territory belonging to which country?"
VAR StoryCategory = "Yellow"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 18

VAR Character0HappinessCh = 0
VAR Character0IntelligenceCh = 0

I'm taking a Geography quiz and am trying to answer this question.
Greenland is an autonomous territory belonging to which country?
* [Iceland]
    -> res1
* [United States]
    -> res2
* [Canada]
    -> res3
* [Denmark]
    -> res4

=== res1 === 
Iceland is the wrong answer.
~TextForLog = "Iceland was the wrong answer... but it sounded like it could've been right. Plus, they're right next to each other on the map. I'll have to go double check this one."
* [Ok]
-> END

=== res2 === 
United States is the wrong answer.
~TextForLog = "United States is the wrong answer and now I am annoyed because I actually did know it wasn't part of the U.S. and now I feel dumb for having guessed that over one of the other choices."
~Character0HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
Canada isn't technically right, but it also isn't technically wrong.
~TextForLog = "I get partial credit for this answer because, though Greenland actually belongs to Denmark, Canada has been trying to claim it as their own for a while. Hey, I'll take partial credit! Definitely alright with that!"
* [Ok]
-> END

=== res4 === 
Denmark is the right answer!
~TextForLog = "Denmark was the right answer! This was one of the tougher questions on the quiz so it was worth more which is great, because that really improved my overall score!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END
