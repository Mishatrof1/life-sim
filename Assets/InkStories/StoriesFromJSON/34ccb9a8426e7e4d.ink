VAR StoryTittle = ""
VAR StoryQuestion = "Where should we choose?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 23
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR NPC0HappinessCh = 0
VAR Character0AthleticismCh = 0
VAR Character0WealthCh = 0
VAR NPC0RelationshipCh = 0

My friend %FullName:NPC:1% are trying to decide where to play basketball.
Where should we choose?
* [The basketball court closest to us.]
    -> res1
* [The basketball court close to the school.]
    -> res2
* [Go to the basketball court on the other side of town.]
    -> res3

=== res1 === 
This court is in such bad shape, it has cracks and holes in the pavement and we both end up hurting ourselves.
~TextForLog = "We totally forgot that the court closest to us is always in bad condition, but this time it seemed even worse. We only got a little bit into our first game before we both got caught up in a hole in the pavement and hurt ourselves. What a bust!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
It costs money to come use this court but they keep it in good shape and there are a lot of people to play with and we have a good time.
~TextForLog = "Me and %FullName:NPC:1% have to pay to get in to this court but it's worth it. We team up and play games against some of the other people there and we play really well together! Ended up winning all of our games!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~Character0WealthCh = "%-10%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
No one else is at this court so me and %FullName:NPC:1% have the court all to ourselves and play some great one-on-one.
~TextForLog = "This is a good court to keep in mind if me and %FullName:NPC:1% want to play one-on-one in the future and not be bothered by anyone else. We had the court all to ourselves, didn't have to wait for other people, the court is in good shape, not a bad day at all!"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
* [Ok]
-> END
