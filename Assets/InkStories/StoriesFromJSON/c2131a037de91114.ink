VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = "Blue"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 23
VAR NPC0RelationshipSc = "Friend"
VAR NPC0GenderSc = "Same"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AthleticismCh = 0
VAR Character0AppearanceCh = 0
VAR Character0StrengthCh = 0
VAR Character0WisdomCh = 0
VAR NPC0SympathyCh = 0

I'm at the gym with my friend %FullName:NPC:1% and we are about to do the bench press but I'm not sure of the amount that I can do.
What should I do?
* [75 pounds.]
    -> res1
* [100 pounds.]
    -> res2
* [130 pounds.]
    -> res3
* [175 pounds.]
    -> res4

=== res1 === 
%FullName:NPC:1% spends the whole time making fun of me for doing so little and I get really annoyed with %Pron:1:2%.
~TextForLog = "%FullName:NPC:1% was getting really annoying, making fun of how much weight I was benching. %Pron:1:1% was doing it loudly so everyone in the gym could hear too, so I was really mad at %Pron:1:2% by the end of it all. I wanted to start off easy! What's the crime here?!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
This ends up being a pretty good amount, but not too much. I get a decent workout from it but I feel like I could've done more.
~TextForLog = "100 pounds was a good place to start. It sounds like it's more than it really is, I could've done more. But I'm happy with my starting point. Got a pretty good workout in. Maybe next time I'll step up."
~Character0HealthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
This gives me such a good workout. I am sweating by the end of it and feel really good.
~TextForLog = "Yeah, I think this might be my sweet spot. It felt really good to lift all this weight and get in a really good workout. I can feel the effects already! And maybe it's just me, but do my arms already look bigger? I think so."
~Character0AppearanceCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res4 === 
This is too much weight and I cannot do more than a couple lifts and then I drop it on myself and it gets stuck on me and I need %FullName:NPC:1% to get it off of me.
~TextForLog = "Wow, if %FullName:NPC:1% wasn't there to spot me and help lift these weights off of me, I don't know what would've happened. I guess I would've been hoping someone else saw and helped me out but sheesh, I really learned a lesson there. Don't guess too high on your first try benching!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
