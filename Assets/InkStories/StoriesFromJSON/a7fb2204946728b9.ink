VAR StoryTittle = ""
VAR StoryQuestion = "He doesn't see me. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 22
VAR NPC0OccupationSc = "Colleague"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 30

VAR Character0HealthCh = 0
VAR Character0WisdomCh = 0
VAR Character0PopularityCh = 0
VAR NPC0SympathyCh = 0
VAR Character0HappinessCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0

I'm at work and I see some guy with a gun robbing the store.
He doesn't see me. What should I do?
* [Charge him.]
    -> res1
* [Put my hands up and don't move.]
    -> res2
* [Drop to the floor with my hands out.]
    -> res3

=== res1 === 
I run at the guy, try to tackle him, he turns and shoots me!
~TextForLog = "I charged this guy and before I could get to him, he shot me! Luckily, the bullet didn't hit any organs or anything and the guy ended up running out of the store. I am rushed to the hospital and was worried I was going to die, but I make it out alright. That was so stupid of me. I am not ever trying to be the hero ever again!"
~Character0HealthCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:3:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0SympathyCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res2 === 
The guy turns around, sees me with my hands up and shoots at me, but ends up getting tackled by %FullName:NPC:1% in the process.
~TextForLog = "I guess the guy thought I was attacking and shot at me. Luckily he missed right past my head but as he was distracted, %FullName:NPC:1% tackled him to the ground and the cops came and took him away. And everyone thanks me because they think I was purposely distracting him. I'm just still in shock after a bullet passed right by me!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:2:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res3 === 
Everyone wonders why I dropped to the floor even if the guy didn't see me and they think I am a coward.
~TextForLog = "%FullName:NPC:1% says I did the right thing and made the right choice but so many other people are making fun of me for how I acted. All I care about is being safe. Someone is in there with a gun, I am taking NO chances."
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END
