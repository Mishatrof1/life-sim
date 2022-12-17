VAR StoryTittle = ""
VAR StoryQuestion = "The dog comes over and starts licking it. What do I do?"
VAR StoryCategory = "Pink"
VAR TextForLog = ""

VAR Character0OccupationSc = "HighSchool:College:PartTimeJob:FullTimeJob"
VAR Character0MinAgeSc = 16
VAR Character0MaxAgeSc = 35
VAR NPC0RelationshipSc = "Crush"
VAR NPC0GenderSc = "Opposite"
VAR NPC0MinAgeSc = 16
VAR NPC0MaxAgeSc = 35

VAR Character0HappinessCh = 0
VAR Character0PopularityCh = 0
VAR NPC0HappinessCh = 0
VAR NPC0RelationshipCh = 0
VAR Character0AppearanceCh = 0
VAR Character0HealthCh = 0

I'm at %FullName:NPC:1%'s place and drop food on the crotch of my pants.
The dog comes over and starts licking it. What do I do?
* [Do nothing, the dog will finish soon.]
    -> res1
* [Move away from the dog]
    -> res2
* [Push the dog away from me]
    -> res3

=== res1 === 
%FullName:NPC:1% sees me letting the dog do this and thinks I'm a weirdo and kicks me out.
~TextForLog = "Not only does %FullName:NPC:1% think I am weird and kicks me out, but %Pron:1:1% tells a bunch of our mutual friends so now everyone thinks I'm a freak. I was just trying to let the dog finish and hoping it would eventually stop!"
~Character0HappinessCh = "%ValueRef:1:-%"
~Character0PopularityCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:1:-%"
* [Ok]
-> END

=== res2 === 
The dog keeps following me and eventually %FullName:NPC:1% realizes what's going on and gets the dog for me.
~TextForLog = "%FullName:NPC:1% finds the whole thing funny and eventually helps me get the dog away. %Pron:1:1% gets me something to clean my pants and we have a laugh over the whole thing."
~Character0HappinessCh = "%ValueRef:0:+%"
~NPC0HappinessCh = "%ValueRef:0:+%"
~NPC0RelationshipCh = "%ValueRef:0:+%"
* [Ok]
-> END

=== res3 === 
%FullName:NPC:1% gets mad at me for pushing %Pron:1:2% dog like I do.
~TextForLog = "%FullName:NPC:1% gets mad at me because it looks like I'm just pushing the dog. %Pron:1:1% actually slaps me in the face and gives me a bruise. I explain what happened but just end up leaving. This was too much for me."
~Character0HappinessCh = "%ValueRef:0:-%"
~Character0AppearanceCh = "%ValueRef:0:-%"
~Character0HealthCh = "%ValueRef:0:-%"
~NPC0HappinessCh = "%ValueRef:0:-%"
~NPC0RelationshipCh = "%ValueRef:0:-%"
* [Ok]
-> END
