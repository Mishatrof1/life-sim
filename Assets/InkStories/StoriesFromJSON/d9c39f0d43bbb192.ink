VAR StoryTittle = ""
VAR StoryQuestion = "What should we do?"
VAR StoryCategory = "Love"
VAR TextForLog = ""

VAR Character0OccupationSc = "PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 25
VAR Character0MaxAgeSc = 55
VAR NPC0RelationshipSc = "Partner"
VAR NPC0MinAgeSc = 25
VAR NPC0MaxAgeSc = 55

VAR Character0HappinessCh = 0
VAR Character0WealthCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0

It's nice out today, %FullName:NPC:1% wants to do something outside.
What should we do?
* [Have a picnic in the park]
    -> res1
* [Play basketball down at the park]
    -> res2
* [Ride bikes on the trails at the park]
    -> res3

=== res1 === 
This ends up being really nice, really romantic. And we really connect.
~TextForLog = "I'm glad %FullName:NPC:1% did a picnic in the park, we haven't done anything like that in so long. And it reminded us of the last time and we were reminiscing over shared memories. It was an amazing afternoon. We may have to do this more often!"
~Character0HappinessCh = "%ValueRef:1:+%"
~Character0WealthCh = "%-50%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% and I play basketball together and have an awesome time.
~TextForLog = "I forgot how much the two of us like playing basketball together. It's been a little while. But %FullName:NPC:1% and I enjoyed ourselves and hey, that was a healthy way to spend an afternoon. Can't complain if it's fun and good for my overall well being!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
We got for a nice, long bike ride and actually come across some money!
~TextForLog = "%FullName:NPC:1% and I always enjoy riding bikes together so this was a lot of fun as always. But we got lucky too! We came around a corner and there was a bunch of cash on the ground underneath a park bench. It was so weird, no one was around and it was just loose cash. So... it became our cash! This was a profitable bike ride!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0WealthCh = "%50%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
