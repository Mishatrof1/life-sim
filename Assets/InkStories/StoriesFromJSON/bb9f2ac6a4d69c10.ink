VAR StoryTittle = ""
VAR StoryQuestion = "What do I do?"
VAR StoryCategory = "Love:Violence"
VAR TextForLog = ""

VAR Character0OccupationSc = "College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 21
VAR Character0MaxAgeSc = 30
VAR Character0GenderSc = "Male"
VAR NPC0RelationshipSc = "SignificantOther"
VAR NPC0GenderSc = "Female"
VAR NPC0MinAgeSc = 21
VAR NPC0MaxAgeSc = 30

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0WisdomCh = 0
VAR Character0HealthCh = 0
VAR Character0StrengthCh = 0
VAR NPC0SympathyCh = 0

I'm at a bar with %FullName:NPC:1% and some random guy insults her.
What do I do?
* [Tell her we should just ignore him.]
    -> res1
* [Go up to the guy and tell him to apologize.]
    -> res2
* [Go yell at the guy and insult him back.]
    -> res3
* [Go punch the guy in the eye.]
    -> res4

=== res1 === 
%FullName:NPC:1% gets angry with me for not standing up for her.
~TextForLog = "Not only did %FullName:NPC:1% get angry with me for doing nothing and not standing up for her, but she tells a bunch of our friends too and now they all think I'm lame and like I was scared of the guy. I just didn't want to start anything with some random guy, who knows what he may have been capable of?"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
The guy listens to me and actually does go apologize to %FullName:NPC:1%.
~TextForLog = "%FullName:NPC:1% is so proud of me for standing up to the guy and telling him to apologize. She even tells all our friends what a great guy I am. I was a little nervous telling the guy to do that, but I was firm and honest with him and he seemed to respect that and agreed. I guess it was a good lesson in how to handle situations like that."
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
The guy immediately starts to fight me and I have to fight him off along with his friend.
~TextForLog = "So, I yelled at this guy and insulted him and he attacked me! We get into a fight in the middle of the bar and then his friend even comes in and attacks me too. Luckily, some people pulled them off of me because I wasn't going to be able to handle both of them. I got pretty banged up but at least I stood up for %FullName:NPC:1%. And she loves that I did it and tells EVERYONE."
~Character0HealthCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:1:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0HappinessCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
* [Ok]
-> END

=== res4 === 
His reaction to me punching him is to leave. Later when we leave the bar, the guy is waiting with his friend and they shoot me and drive off.
~TextForLog = "I thought I was so cool, punching this guy in the eye and sending him off. It turns out, him and his friend just waited for me outside with their guns. It was such a scary experience. I had to go to the emergency room, the doctors said had one of the bullets been an inch to the left I would've died. I definitely learned a lesson, do NOT engage with strangers."
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0HealthCh = "%ValueRef:3:-%"
~Character0StrengthCh = "%ValueRef:1:-%"
~Character0WisdomCh = "%ValueRef:3:+%"
~Character0PopularityCh = "%ValueRef:1:+%"
~NPC0RelationshipCh = "%ValueRef:1:+%"
~NPC0SympathyCh = "%ValueRef:2:+%"
* [Ok]
-> END
