VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 45
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0HappinessCh = 0
VAR Character0EnduranceCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0

%FullName:NPC:1% and I want to do a race this weekend and are trying to decide which one we should sign up for.
What should we do?
* [Do the 5K.]
    -> res1
* [Do the half marathon.]
    -> res2
* [Run a full marathon.]
    -> res3

=== res1 === 
We run the 5K and both place really well, it isn't too bad since it's not all that long.
~TextForLog = "Me and %FullName:NPC:1% both place really well in the 5K and because of this we win prizes and win our money back and break even. Plus, it was a good workout. 5K's might be right up my alley for the future!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
We run the half marathon and it is a lot, but we make it and we do pretty well. It is such an amazing workout.
~TextForLog = "Well, running a half marathon was a bit more than I had ever done all at once but it went really well. We both managed to make it and place decently, it only cost about $30 but it was definitely an excellent workout."
~Character0HealthCh = "%ValueRef:1:+%"
~Character0EnduranceCh = "%ValueRef:1:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-30%"
* [Ok]
-> END

=== res3 === 
Some point after halfway through I can't do it anymore. I collapse and pass out. Maybe it was the heat or just that it was too much for me.
~TextForLog = "After collapsing doing this marathon, %FullName:NPC:1% helps me out, but apparently this full marathon was too much for %Pron:1:2% as well. We realized we have to start much smaller next time. We can't just go right into a marathon... so stupid!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-50%"
~NPC0RelationshipCh = "%%"
* [Ok]
-> END
