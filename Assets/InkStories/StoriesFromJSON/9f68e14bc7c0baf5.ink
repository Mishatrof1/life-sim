VAR StoryTittle = ""
VAR StoryQuestion = "Suddenly, a big wooden sign just falls over. What should I do?"
VAR StoryCategory = ""
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 15
VAR Character0MaxAgeSc = 30
VAR NPC0RelationshipSc = "Friend"
VAR NPC0MinAgeSc = 15
VAR NPC0MaxAgeSc = 30

VAR Character0HappinessCh = 0
VAR Character0EnduranceCh = 0
VAR Character0PopularityCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0HealthCh = 0
VAR NPC0SympathyCh = 0
VAR Character0StrengthCh = 0
VAR NPC0HappinessCh = 0
VAR Character0WisdomCh = 0

I am with %FullName:NPC:1% in a graveyard but %Pron:1:1% doesn't believe in ghosts.
Suddenly, a big wooden sign just falls over. What should I do?
* [Run away]
    -> res1
* [Go pick the sign up]
    -> res2
* [Tell %FullName:NPC:1% to go pick it up.]
    -> res3
* [Say that we should go pick it up together.]
    -> res4

=== res1 === 
I get out of that haunted graveyard as fast as possible but %FullName:NPC:1% finds this hilarious and tells all our friends.
~TextForLog = "%FullName:NPC:1% still doesn't believe in ghosts even after a big wooden sign inexplicably fell over once we got near it. I wasn't about to stick around and mess with any spirits but of course, when I run off, %FullName:NPC:1% says I'm too scared. %Pron:1:1% tells all our friends too and now everyone is making fun of me and I get mad at %Pron:1:2% and we get in a big argument."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0EnduranceCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res2 === 
As I pick the sign up I feel a whoosh of air and the sign falls back and knocks me down.
~TextForLog = "This was definitely the work of a ghost, I know it! %FullName:NPC:1% still doesn't believe it, %Pron:1:1% thinks it was the wind. But %Pron:1:1% helps me get the sign off of me and helps me out of the graveyard because I am somewhat injured now. %Pron:1:1% may still not believe but I absolutely do, especially after that."
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0SympathyCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% tries to pick it up when suddenly the sign is pushed back down onto %Pron:1:2%.
~TextForLog = "The sign falls on %FullName:NPC:1% and I  help %Pron:1:2% get it off. %Pron:1:1% still doesn't think it's the work of ghosts. %Pron:1:1% thinks I pranked %Pron:1:2% or something and is angry with me. %FullName:NPC:1% tells our friends and of course, they all think I played a great prank. I did nothing! Except pull the sign off of %FullName:NPC:1% and drag %Pron:1:2% out of the graveyard!"
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0PopularityCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END

=== res4 === 
We both are trying to lift the sign when something is forcing it back towards us.
~TextForLog = "As %FullName:NPC:1% and I are trying to lift the sign we feel something forcing the sign back towards us. It's as if someone is one the other side pushing the sign back down. We struggle with it for over a minute and finally the force stops and we get the sign up. And we both know at that moment, nothing else could've been doing that except for a ghost!"
~Character0HappinessCh = "%ValueRef:0:+%"
~Character0StrengthCh = "%ValueRef:0:+%"
~Character0WisdomCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END
