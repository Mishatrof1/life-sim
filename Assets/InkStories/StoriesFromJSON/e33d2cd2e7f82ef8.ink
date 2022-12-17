VAR StoryTittle = ""
VAR StoryQuestion = "Which hand do I choose?"
VAR StoryCategory = "Gold"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 17
VAR Character0MaxAgeSc = 55

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR Character0IntelligenceCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0

A homeless man runs up to me with both hands behind his back and tells me to pick a hand.
Which hand do I choose?
* [The left hand.]
    -> res1
* [The right hand.]
    -> res2
* [Neither]
    -> res3

=== res1 === 
He holds out his left hand and has $20 in it that he gives to me and runs off.
~TextForLog = "This was so weird. A homeless person gave ME money. Before I could say anything he ran off. An just left me with $20. But I have to say, it put a good start to my day."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WealthCh = "%20%"
* [Ok]
-> END

=== res2 === 
He holds out his right hand and has a small book philosopher's quotes. He gives it to me and runs off.
~TextForLog = "This was so weird. The homeless guy gave me this book and then ran away before I could say anything. So weird! But I actually started reading through the book later that night and there is a lot of insightful stuff in there."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0IntelligenceCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
The homeless man gets mad and swings a BOOK at my face and knocks me onto the ground.
~TextForLog = "Apparently, in one hand the homeless man had a book and he swung it right at my face, hit me in the eye and knocked me onto the ground. Now, I have a black eye and a bloody nose. What would have happened if I picked that hand?"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
* [Ok]
-> END
