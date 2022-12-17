VAR StoryTittle = ""
VAR StoryQuestion = "What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "HigherInPosition"
VAR NPC0MinAgeSc = 30
VAR NPC0MaxAgeSc = 60

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR NPC0SympathyCh = 0

I get to work and realize I am almost 30 minutes late.
What should I do?
* [Walk in the front door and rush off to start working.]
    -> res1
* [Walk in the back door and rush off to start working.]
    -> res2
* [Climb the side of the building and enter through the fire escape.]
    -> res3

=== res1 === 
No one even notices me come in and I am able to get to work undetected.
~TextForLog = "Dodged a bullet there! Luckily, no one was really near the front door so I just snuck right in, started working and started working really hard so that no one would have any reason to think I was later or am not doing a good job."
~Character0HappinessCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res2 === 
I go in the back door and my boss %FullName:NPC:1% is back there, sees me and I get in trouble.
~TextForLog = "Well, that was dumb! I should've just gone through the front door. I thought I'd be sneaking in the back way but %FullName:NPC:1% is right next to the back door and I get in big trouble. But everyone thinks I am hilarious as I try to sneak in past the boss."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res3 === 
As I am climbing up the side of the building, I slip on a rung of the ladder and fall down and hurt myself.
~TextForLog = "My boss %FullName:NPC:1% finds me and ends up taking me to the hospital. I have a lot of cuts and bruises and a twisted ankle. %Pron:1:1% is mad at me for being late but also feels badly for me since I am pretty badly hurt. Everyone else at work thinks I'm hilarious and calls me James Bond now. I'll tell you what, next time I'm late, I'm just walking in the front door."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
