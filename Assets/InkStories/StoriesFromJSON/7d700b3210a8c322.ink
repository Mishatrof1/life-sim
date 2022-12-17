VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "MiddleSchool:HighSchool:College"
VAR Character0MinAgeSc = 13
VAR Character0MaxAgeSc = 23
VAR Character0GenderSc = "Male"
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Female"

VAR Character0HappinessCh = 0
VAR Character0HealthCh = 0
VAR Character0EnduranceCh = 0
VAR Character0AthleticismCh = 0
VAR NPC0HappinessCh = 0
VAR Character0StrengthCh = 0
VAR Character0WisdomCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0
VAR NPC0SympathyCh = 0

Me and %FullName:NPC:1% are walking through the city together when we come across a gang of five guys who are getting ready to jump us.
What do I do?
* [Tell %FullName:NPC:1% we need to both run as fast as we can.]
    -> res1
* [Tell %FullName:NPC:1% to run off and I am going to try to fight off this gang.]
    -> res2

=== res1 === 
We take off running and the gang chases us but we run as fast as we can and they eventually give up and we get away.
~TextForLog = "%FullName:NPC:1% and I are both happy to have gotten away but we were both so scared for a minute. That was too close! We were both just about out of breath when the gang finally gave up. We're not walking that way anymore!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0HealthCh = "%ValueRef:0:+%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0AthleticismCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
%FullName:NPC:1% runs off and gets help. Thankfully she did because I stood no match for the five guys who pummeled me and even knocked me unconscious.
~TextForLog = "I wake up in the hospital with a concussion, broken ribs, cuts and bruises all over, the doctors say I was fairly close to death. If %FullName:NPC:1% hadn't gotten help immediately, I could've died. She is so thankful I saved her and stays with me in the hospital as I recover. We grow closer but wow am I in massive pain!"
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0HealthCh = "%ValueRef:2:-%"
~Character0StrengthCh = "%ValueRef:0:-%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:2:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC0SympathyCh = "%ValueRef:1:+%"
* [Ok]
-> END
