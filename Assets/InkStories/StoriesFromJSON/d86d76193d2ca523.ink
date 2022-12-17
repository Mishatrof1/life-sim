VAR StoryTittle = ""
VAR StoryQuestion = "What town should we go to next?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 30
VAR Character0MaxAgeSc = 50
VAR NPC0RelationshipSc = "Partner"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 50

VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0StrengthCh = 0
VAR Character0WealthCh = 0

Me and %FullName:NPC:1% are on vacation in a new place and are exploring.
What town should we go to next?
* [Newcastle]
    -> res1
* [Dover]
    -> res2

=== res1 === 
We got o this town and we happen to go on the day when everything is closed.
~TextForLog = "Apparently, everything in Newcastle is closed on a Monday. Of course, we had no idea. But we both get mad and end up getting into a big argument with one another and the whole day is just ruined."
~Character0HappinessCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
We had to this town and it turns out there is a big fair and carnival that we attend and it's so much fun.
~TextForLog = "We had to pay money to get into this fair but it was totally worth it. I played one of those games where I had to keep swinging a sledgehammer and hitting a weight in order to try to ring the bell at the top and after many swings I finally did it and won a prize for %FullName:NPC:1% and we just have the best time."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-30%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
